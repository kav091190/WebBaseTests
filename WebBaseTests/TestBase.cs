using NUnit.Framework;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;



namespace WebBaseTests
{
    public class TestBase
    {
        protected string path = Directory.GetCurrentDirectory();

        /* Объявление и инициализация driver для тестов
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
        */
    }
}
