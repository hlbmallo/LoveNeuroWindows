using Microsoft.Toolkit.Uwp.Helpers;
using Newtonsoft.Json;
using System.Text.Json;


namespace NerveCentreW10.Helpers

{
    public class JsonSerializer : IObjectSerializer
    {
        // Specify your serialization settings
        private readonly JsonSerializerSettings settings = new JsonSerializerSettings();

        object IObjectSerializer.Serialize<T>(T value)
        {
            var lol = JsonConvert.SerializeObject(value, typeof(T), Formatting.Indented, settings);
            return lol;
        }

        public T Deserialize<T>(object value)
        {
        var lol = JsonConvert.DeserializeObject<T>(value.ToString(), settings);
            return lol;


    }
}
}
