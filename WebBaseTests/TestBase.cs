using NUnit.Framework;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace WebBaseTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected string baseURL;

        [SetUp]
        protected void SetupTest()
        {
            var path = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(path);
            baseURL = "http://dev.dns-shop.ru/login";

        }

        //Закрытие браузера
        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }        
    }
}
