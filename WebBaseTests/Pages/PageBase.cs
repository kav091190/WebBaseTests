using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace WebBaseTests.Pages
{
    abstract class PageBase
    {
        protected IWebDriver Driver;
        public string PageUrl = "http://dev.dns-shop.ru";
        protected WebDriverWait Wait { get; set; }

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(PageUrl);
        }

        protected void WaitTillPageStatusBeComlete()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            bool condition() => (bool)js.ExecuteScript("return document.readyState == 'complete'");
            while (!condition())
                Thread.Sleep(100);
        }

        protected PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

    }
}
