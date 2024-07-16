using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using BaseClassLibrary;


namespace lab2;

[Serializable]
public class Coffee : Drink
{
    private readonly DateTime _brewingTime;

    public override bool IsHot => (DateTime.Now - _brewingTime).TotalSeconds <= 5;

    public Coffee(string name, string img) : base(name, img)
    {
        _brewingTime = DateTime.Now;
    }

    [JsonConstructor]
    public Coffee(bool isHot, int sugars, bool milk, string name, string img): base(name, img)
    {
        (Sugars, Milk, Name, Img) = (sugars, milk, name, img);
        _brewingTime = DateTime.UnixEpoch;
    }
    
    public new static JsonDerivedType JsonDerivedData { get; } = new(typeof(Coffee), "coffee");

}