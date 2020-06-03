using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace WebBaseTests.Pages
{
    abstract class PageBase
    {
        protected IWebDriver Driver;
        public string PageUrl = "http://dev.dns-shop.ru";
        public WebDriverWait Wait { get; set; }

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(PageUrl);
        }

        protected PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
