using JetSetAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JetSetAPI.Services
{
    public class JsonFileService
    {
        private readonly string _basePath;

        public JsonFileService(IWebHostEnvironment env)
        {
            _basePath = Path.Combine(env.ContentRootPath, "Data");
        }

        public IEnumerable<T> GetItems<T>(string fileName)
        {
            var filePath = Path.Combine(_basePath, fileName);
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
    }
}