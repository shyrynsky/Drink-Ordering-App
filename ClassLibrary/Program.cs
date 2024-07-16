using System.Text.Json.Serialization.Metadata;
using BaseClassLibrary;

namespace ClassLibrary;

public static class Program
{
    public static ((string, IFactory)[], JsonDerivedType[]) Load()
    {
        return (
            [
                ("кока-кола лайм", new LimeCocaColaFactory())
            ],
            [
                LimeCocaCola.JsonDerivedData
            ]
        );
    }
}