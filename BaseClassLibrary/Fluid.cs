namespace BaseClassLibrary;

[Serializable]
public abstract class Fluid
{
    public string Name { get; protected set; }

    public string Img { get; protected set; }
    
    protected Fluid(string name, string img)
    {
        Name = name;
        Img = img;
    }
}