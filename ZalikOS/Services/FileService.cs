using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZalikOS.Services
{
    public class FileService
    {
        private static readonly string _dataFolderPath = @"..\..\..\Data\";

        public static void ProcessingQuestion(string path)
        {
            var data = new Dictionary<string, string>();

            try
            {
                string[] lines = File.ReadAllLines(Path.Combine(_dataFolderPath, path), Encoding.Unicode);
                for (int i = 0; i < lines.Length; i += 3)
                {
                    data.Add(lines[i].Trim(), lines[i + 1].Trim());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            JsonService.WriteData(data, "QAData.json");
        }
    }
}
