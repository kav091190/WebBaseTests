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

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        protected void GoToPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        protected void Login(AccountData account)
        {
            driver.FindElement(By.Id("MainContent_LoginUser_UserName")).SendKeys(account.Username);
            driver.FindElement(By.Id("MainContent_LoginUser_Password")).SendKeys(account.Password);
            driver.FindElement(By.Id("MainContent_LoginUser_LoginButton")).Click();
        }
    }
}
