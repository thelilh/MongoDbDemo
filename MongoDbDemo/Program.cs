using DataAccess;
using DataAccess.Models;

var carManager = new CarManager();

ConsoleKey key = ConsoleKey.Enter;

while (key != ConsoleKey.Escape)
{
    Console.WriteLine("Enter Make:");
    var make = Console.ReadLine();
    Console.WriteLine("Enter Model:");
    var model = Console.ReadLine();
    Console.WriteLine("Enter Colour:");
    var colour = Console.ReadLine();
    Console.WriteLine("Enter Horse Power:");
    var horse = int.Parse(Console.ReadLine());
    Console.WriteLine("Press escape to stop entering car.");
    key = Console.ReadKey().Key;
    carManager.AddColour(new Colour { Name = colour });
    carManager.AddMake(new Make { Name = make });
    var newCar = new Car() { Horse = horse, Make = carManager.GetMake(make), Model = model, Colour = carManager.GetColour(colour) };
    carManager.Add(newCar);
}

var all = carManager.GetAll();
Console.WriteLine("==========================================");

foreach (var car in all)
{
    Console.WriteLine();
    Console.WriteLine($"Id: {car.Id}");
    Console.WriteLine($"Make: {car.Make.Name}");
    Console.WriteLine($"Model: {car.Model}");
    Console.WriteLine($"Colour: {car.Colour.Name}");
    Console.WriteLine($"Horse Power: {car.Horse}");
    Console.WriteLine();
}