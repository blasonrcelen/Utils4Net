using System.Text.Json;

namespace Utils4Net.Json
{
    public class JsonHelper
    {
        public string ToJson()
        {
            return ToJson(new JsonSerializerOptions { WriteIndented = true });
        }

        public string ToJson(JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize<object>(this, options);
        }

        public override string ToString()
        {
            return ToJson();
        }
    }
}
