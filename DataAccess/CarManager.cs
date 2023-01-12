using DataAccess.Models;
using MongoDB.Driver;
using System.Drawing;

namespace DataAccess;

public class CarManager : IRepository<Car>
{
    private readonly IMongoCollection<Car> _collection;
    private readonly IMongoCollection<Make> _makeCollection;
    private readonly IMongoCollection<Colour> _colourCollection;
    public CarManager()
    {
        var hostname = "localhost";
        var databaseName = "demo";
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<Car>("car", new MongoCollectionSettings() { AssignIdOnInsert = true });
        _makeCollection = database.GetCollection<Make>("make", new MongoCollectionSettings() { AssignIdOnInsert = true });
        _colourCollection = database.GetCollection<Colour>("colour", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }

    public void Add(Car item)
    {
        _collection.InsertOne(item);
    }
    public void AddColour(Colour item)
    {
        _colourCollection.InsertOne(item);
    }

    public void AddMake(Make item)
    {
        _makeCollection.InsertOne(item);
    }

    public IEnumerable<Car> GetAll()
    {
        return _collection.Find(_ => true).ToEnumerable();
    }

    public IEnumerable<Car> GetByCar(Make make, string model, Colour colour)
    {
        return _collection
            .Find(p =>
                (make != null && p.Make == make)
                && (!string.IsNullOrEmpty(model) && p.Model == model)
                && (colour != null && p.Colour == colour))
            .ToEnumerable();
    }

    public void UpdateMake(Make make)
    {
        var filter = Builders<Make>.Filter.Eq("Id", make.Id);
        var update = Builders<Make>
            .Update
            .Set("Name", make.Name);

        _makeCollection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Make, Make>
                {
                    IsUpsert = true
                }
            );
    }

    public void UpdateModel(object id, string model)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Model", model);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void UpdateColour(Colour colour)
    {
        var filter = Builders<Colour>.Filter.Eq("Id", colour.Id);
        var update = Builders<Colour>
            .Update
            .Set("Name", colour.Name);

        _colourCollection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Colour, Colour>
                {
                    IsUpsert = true
                }
            );
    }


    public void UpdateHorse(object id, int horse)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Horse", horse);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void Replace(object id, Car item)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Horse", item.Horse)
            .Set("Model", item.Model)
            .Set("Make", item.Make)
            .Set("Colour", item.Colour);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }
    public void Delete(object id)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        _collection.FindOneAndDelete(filter);
    }

    public Colour GetColour(string item)
    {
        return _colourCollection
            .Find<Colour>(p => (item.ToLower() == p.Name.ToLower())).FirstOrDefault();
    }
    public Make GetMake(string item)
    {
        return _makeCollection
            .Find<Make>(p => (item.ToLower() == p.Name.ToLower())).FirstOrDefault();
    }

}