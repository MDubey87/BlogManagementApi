using Newtonsoft.Json;

namespace Blog.Management.Services.Helpers
{
    public static class JsonFileHelper
    {
        private static readonly string JsonFilePath = @"Data/blogpost.json";

        public static List<T> ReadFromJsonFile<T>()
        {
            try
            {
                using StreamReader file = File.OpenText(JsonFilePath);
                JsonSerializer serializer = new JsonSerializer();
                var d = serializer.Deserialize(new JsonTextReader(file), typeof(List<T>));
                if (d == null)
                {
                    return new List<T>();
                }
                return (List<T>)d;
            }
            catch
            {
                throw;
            }
        }

        public static void WriteToJsonFile<T>(List<T> data)
        {
            try
            {
                using StreamWriter file = File.CreateText(JsonFilePath);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
            catch
            {
                throw;
            }
        }
    }
}
