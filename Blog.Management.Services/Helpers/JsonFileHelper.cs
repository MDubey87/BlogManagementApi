using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Blog.Management.Services.Helpers
{
    public static class JsonFileHelper
    {
        private static readonly string JsonFilePath = @"Data/blogpost.json";

        public static async Task<List<T>> ReadFromJsonFile<T>()
        {
            try
            {
                using StreamReader file = File.OpenText(JsonFilePath);
                JsonSerializer serializer = new JsonSerializer();
                string json = await file.ReadToEndAsync();
                var content= JsonConvert.DeserializeObject<List<T>>(json);
                if (content == null)
                {
                    return new List<T>();
                }
                return content;
            }
            catch
            {
                throw;
            }
        }

        public static async Task WriteToJsonFile<T>(List<T> data)
        {
            try
            {
                using StreamWriter file = File.CreateText(JsonFilePath);
                JsonSerializer serializer = new JsonSerializer();
                await Task.Run(()=>serializer.Serialize(file, data));
            }
            catch
            {
                throw;
            }
        }
    }
}
