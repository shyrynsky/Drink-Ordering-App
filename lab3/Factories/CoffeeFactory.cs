namespace lab2.Factories;
using BaseClassLibrary;


public class CoffeeFactory: IFactory
{
    public Drink NewDrink(string name)
    {
        var drink = new Coffee($"кофе({name})", @"coffee.png");
        return drink;
    }
}