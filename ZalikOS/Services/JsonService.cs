using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ZalikOS.Services
{
    public class JsonService
    {
        private static readonly string _dataFolderPath = @"..\..\..\Data\";

        public static T? LoadData<T>(string path) where T : class
        {
            string json = File.ReadAllText(Path.Combine(_dataFolderPath, path));
            return JsonSerializer.Deserialize<T>(json);
        }

        public static void WriteData<T>(T value, string path) where T : class
        {
            string json = JsonSerializer.Serialize(value);
            File.WriteAllText(Path.Combine(_dataFolderPath, path), json);
        }
    }
}
