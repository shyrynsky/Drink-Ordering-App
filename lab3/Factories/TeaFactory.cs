namespace lab2.Factories;
using BaseClassLibrary;


public class TeaFactory: IFactory
{
    public Drink NewDrink(string name)
    {
        var drink = new Tea($"чай({name})", @"tea.png");
        return drink;
    }
}