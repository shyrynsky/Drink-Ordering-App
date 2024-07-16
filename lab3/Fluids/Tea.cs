using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using BaseClassLibrary;



namespace lab2;

[Serializable]
public class Tea : Drink
{
    
    private readonly DateTime _brewingTime;

    public override bool IsHot => (DateTime.Now - _brewingTime).TotalSeconds <= 10;
    
    public override string HaveADrink()
    {
        return _sugars > 0 ? "клиент не любит чай с сахаром" : "клиент с удовольствием выпил " + Name;
    }

    public Tea(string name, string img) : base(name, img)
    {
        _brewingTime = DateTime.Now;
    }
    
    [JsonConstructor]
    public Tea(bool isHot, int sugars, bool milk, string name, string img): base(name, img)
    {
        (Sugars, Milk, Name, Img) = (sugars, milk, name, img);
        _brewingTime = DateTime.UnixEpoch;
    }
    
    public new static JsonDerivedType JsonDerivedData { get; } = new(typeof(Tea), "tea");

}