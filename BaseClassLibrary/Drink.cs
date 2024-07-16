namespace BaseClassLibrary;

using System.Text.Json.Serialization.Metadata;

// [JsonDerivedType(typeof(Tea), typeDiscriminator: "tea")]
// [JsonDerivedType(typeof(Coffee), typeDiscriminator: "coffee")]
// [JsonDerivedType(typeof(Chicory), typeDiscriminator: "chicory")]
[Serializable]
public class Drink : Fluid
{
    public virtual string HaveADrink()
    {
        return "клиент выпил " + Name;
    }

    protected int _sugars;

    public int Sugars
    {
        get => _sugars;
        set => _sugars = value >= _sugars ? value : throw new Exception();
    }

    protected bool _milk;

    public bool Milk
    {
        get => _milk;
        set => _milk = (!value && _milk) ? throw new Exception() : value;
    }

    public virtual bool IsHot { get; } = false;


    public Drink(string name, string img) : base(name, img)
    {
        _sugars = 0;
        _milk = false;
    }

    public static JsonDerivedType JsonDerivedData { get; } = new();
}