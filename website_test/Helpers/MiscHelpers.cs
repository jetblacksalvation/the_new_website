using System.Text.Json.Nodes;

namespace website_test.Helpers
{
    static public class MiscHelpers
    {
        static public T CoalesceException<T>(Func<T> func, T defaultValue = default(T))
        {
            try
            {
                return func();
            }
            catch{ return defaultValue; }
        
        }

        public static JsonNode CloneJsonNode(JsonNode original)
        {
            var json = original.ToString();
            return JsonNode.Parse(json);
        }
    }
}
