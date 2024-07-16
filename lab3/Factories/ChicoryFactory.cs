namespace lab2.Factories;
using BaseClassLibrary;


public class ChicoryFactory: IFactory
{
    public Drink NewDrink(string name)
    {
        var drink = new Chicory($"цикорий({name})", @"chicory.png");
        return drink;
    }
}