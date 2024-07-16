using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using BaseClassLibrary;


namespace lab2;


public class PolymorphicTypeResolver : DefaultJsonTypeInfoResolver
{

    public static List<JsonDerivedType> JsonDerivedTypes { get; private set; } = new();
    
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);
        
        Type basePointType = typeof(Drink);
        if (jsonTypeInfo.Type == basePointType)
        {
            jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
            };
            JsonDerivedTypes.ForEach(jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add);
        }

        return jsonTypeInfo;
    }
    
    public PolymorphicTypeResolver(List<JsonDerivedType> jsonDerivedTypesList)
    {
        JsonDerivedTypes = jsonDerivedTypesList;
    }
}