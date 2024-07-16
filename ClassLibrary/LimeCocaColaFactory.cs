namespace ClassLibrary;
using BaseClassLibrary;

public class LimeCocaColaFactory: IFactory
{
    public Drink NewDrink(string name)
    {
        var drink = new LimeCocaCola("cola.png");
        return drink;
    }
    
}