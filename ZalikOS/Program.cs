using ZalikOS.Models;
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
            ParseHTMLService.Processing("chromedriver.exe");
        }
    }
}