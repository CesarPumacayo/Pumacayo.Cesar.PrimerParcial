using System.Text.Json.Serialization;
using System.Text.Json;
using Entidades;

public class GaseosaConverter : JsonConverter<Gaseosa>
{
    public override Gaseosa? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            JsonElement root = doc.RootElement;
            string? type = root.GetProperty("Tipo").GetString();

            if (type == nameof(Sprite))
            {
                return JsonSerializer.Deserialize<Sprite>(root.GetRawText(), options);
            }
            else if (type == nameof(Manaos))// aca deserializa en caso de que el tipo de la lista sea Manaos ATENTO!!!
            {
                return JsonSerializer.Deserialize<Manaos>(root.GetRawText(), options);

            }
            else if (type == nameof(Fanta))// aca deserializa en caso de que el tipo de la lista sea Manaos ATENTO!!!
            {
                return JsonSerializer.Deserialize<Fanta>(root.GetRawText(), options);

            }


            throw new NotSupportedException($"Tipo {type} no soportado");
        }
    }

    public override void Write(Utf8JsonWriter writer, Gaseosa value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Tipo", value.GetType().Name); // Añade el tipo de gaseosa

        foreach (var property in value.GetType().GetProperties())
        {
            writer.WritePropertyName(property.Name);
            JsonSerializer.Serialize(writer, property.GetValue(value), property.PropertyType, options);
        }

        writer.WriteEndObject();
    }
}
