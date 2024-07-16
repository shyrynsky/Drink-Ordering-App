namespace BaseClassLibrary;

public class Fuel : Fluid
{
    private bool _isBurning;


    public void Burn()
    {
        if (_isBurning)
        {
            Console.WriteLine("я не могу еще раз поджечь уже " + Name);
        }
        else
        {
            Console.WriteLine("я поджег " + Name);
            _isBurning = true;
            Name = "горящий " + Name;
        }
    }


    public Fuel(string name, string img) : base(name, img)
    {
        _isBurning = false;
    }
}