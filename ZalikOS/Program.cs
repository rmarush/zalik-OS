using ZalikOS.Services;

namespace ZalikOS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            var data = JsonService.LoadData<Dictionary<string, string>>("QAData.json");
            Console.WriteLine("Input url: ");
            var url = Console.ReadLine();
            ParseHTMLService.Processing("chromedriver.exe", url, data);
            Console.ReadKey();
        }
    }
}