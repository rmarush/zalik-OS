using ZalikOS.Services;

namespace ZalikOS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            //FileService.ProcessingQuestion("Questions.txt");
            var data = JsonService.LoadData<Dictionary<string, string>>("QAData.json");
            foreach (var item in data)
            {
                Console.WriteLine(item.Key + " " + data[item.Key]);
            }
            ParseHTMLService.Processing("chromedriver.exe", data);
        }
    }
}