namespace BakeryAwesome.Helpers;
public static class JsonHelper
{
    public static bool IsJsonSchemaValid<TSchema>(string value)
    {
        JSchemaGenerator generator = new JSchemaGenerator();
        JSchema schema = generator.Generate(typeof(TSchema));
        schema.AllowAdditionalProperties = false;

        JObject obj = JObject.Parse(value);
        return obj.IsValid(schema);
    }
}