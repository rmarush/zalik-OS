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
        public static void Processing(string path, string url, Dictionary<string, string> data)
        {

            using (IWebDriver driver = new ChromeDriver(Path.Combine(_dataFolderPath, path)))
            {
                driver.Navigate().GoToUrl(Path.Combine("http:\\", url));
                var actions = new Actions(driver);
                IWebElement inputElement = null;
                while (true)
                {
                    var currentPageContent = driver.PageSource;
                    var extractedText = ProcessingText(ExtractText(currentPageContent));
                    var foundedAnswer = " ";
                    if (!string.IsNullOrEmpty(extractedText))
                    {
                        foundedAnswer = data[extractedText];
                        inputElement = driver.FindElement(By.Name("answer"));
                        inputElement.SendKeys(foundedAnswer);
                        actions.SendKeys(Keys.Enter).Perform();
                    }
                    Console.WriteLine(extractedText + " " + foundedAnswer);
                    if (!string.Equals(currentPageContent, _previousPageContent))
                    {
                        _previousPageContent = currentPageContent;
                    }
                    Thread.Sleep(500);
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
