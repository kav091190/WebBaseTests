using NUnit.Framework;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace WebBaseTests
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        protected void SetupTest()
        {
            var path = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(path);
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }
    }
}
