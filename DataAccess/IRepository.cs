using DataAccess.Models;

namespace DataAccess;

public interface IRepository<T>
{
    void Add(T item);
    void AddColour(Colour item);
    void AddMake(Make item);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetByCar(Make make, string model, Colour colour);
    void UpdateMake(Make make);
    void UpdateModel(object id, string model);
    void UpdateColour(Colour colour);
    void UpdateHorse(object id, int horse);
    void Replace(object id, T item);
    void Delete(object id);
    Colour GetColour(string item);
    Make GetMake(string item);
}