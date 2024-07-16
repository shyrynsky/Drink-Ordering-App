namespace BaseClassLibrary;


public interface IFactory
{
    Drink NewDrink(string name);
}