using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using HtmlAgilityPack;
using OpenQA.Selenium.Interactions;

namespace ZalikOS.Services
{
    public class ParseHTMLService
    {
        private static readonly string _dataFolderPath = @"..\..\..\ChromeDriver\";
        private static string _previousPageContent = string.Empty;
        public static void Processing(string path)
        {

            using (IWebDriver driver = new ChromeDriver(Path.Combine(_dataFolderPath, path)))
            {
                driver.Navigate().GoToUrl("http://localhost");

                while (true)
                {
                    var counter = 0;
                    var currentPageContent = driver.PageSource;
                    if (counter == 19) return;
                    var extractedText = ProcessingText(ExtractText(currentPageContent));
                    var foundedAnswer = " ";
                    if (!string.IsNullOrEmpty(extractedText))
                    {
                        foundedAnswer = QAService.FindAnswer(extractedText);
                        IWebElement inputElement = driver.FindElement(By.Name("answer"));
                        inputElement.SendKeys(foundedAnswer);
                        Thread.Sleep(1500);
                        Actions actions = new Actions(driver);
                        actions.SendKeys(Keys.Enter).Perform();
                        counter++;
                    }
                    Console.WriteLine(foundedAnswer);
                    if (!string.Equals(currentPageContent, _previousPageContent))
                    {
                        _previousPageContent = currentPageContent;
                    }
                    Thread.Sleep(5000);
                }
            }
        }

        public static string ExtractText(string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            HtmlNodeCollection h1Nodes = doc.DocumentNode.SelectNodes("//h1");

            if (h1Nodes != null && h1Nodes.Count >= 2)
            {
                HtmlNode secondH1Node = h1Nodes[1];
                return secondH1Node?.InnerText?.Trim();
            }
            return string.Empty;
        }

        public static string ProcessingText(string text)
        {
            if(string.IsNullOrEmpty(text)) return string.Empty;
            var firstSpaceIndex = text.IndexOf(' ');
            var lastSpaceIndex = text.LastIndexOf(' ');
            var result = text.Substring(firstSpaceIndex + 1, lastSpaceIndex - 3).Trim();
            return result;
        }
    }
}
