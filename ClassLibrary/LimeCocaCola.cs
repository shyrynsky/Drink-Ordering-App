using System.Text.Json.Serialization.Metadata;

namespace ClassLibrary;
using BaseClassLibrary;


[Serializable]
public sealed class LimeCocaCola : Drink
{
    public override string HaveADrink()
    {
        base.HaveADrink();
        return "очень вкусно:)";
    }

    public LimeCocaCola(string img) : base("Coca-cola со вкусом лайма", img)
    {
    }
    
    public new static JsonDerivedType JsonDerivedData { get; } = new(typeof(LimeCocaCola), "limeCola");

}