using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace WebBaseTests
{
    public class AuthentificationTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            var path = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(path);

        }

        [Test]
        public void SuccessLoginTest()
        {
            OpenHomePage();
            Login(new AccountData("Калиниченко Антон", "123456"));
        }
        
        [Test]
        public void UserNameRequiredTest()
        {
            OpenHomePage();
            Login(new AccountData("", "123456"));
        }

        [Test]
        public void PasswordRequiredTest()
        {
            OpenHomePage();
            Login(new AccountData("Калиниченко Антон", ""));
        }

        [Test]
        public void WrongPasswordTest()
        {
            OpenHomePage();
            Login(new AccountData("Калиниченко Антон", "1"));
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Id("MainContent_LoginUser_UserName")).Click();
            driver.FindElement(By.Id("MainContent_LoginUser_UserName")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector(".account-info > fieldset")).Click();
            driver.FindElement(By.Id("MainContent_LoginUser_Password")).Click();
            driver.FindElement(By.Id("MainContent_LoginUser_Password")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("p:nth-child(3)")).Click();
            driver.FindElement(By.Id("MainContent_LoginUser_LoginButton")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://dev.dns-shop.ru/login");
        }
    }
}






