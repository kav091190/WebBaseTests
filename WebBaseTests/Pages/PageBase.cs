using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebBaseTests.Pages
{
    abstract class PageBase
    {
        protected IWebDriver Driver;
        public string PageUrl = "http://dev.dns-shop.ru";

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(PageUrl);
        }

        protected PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            Driver = driver;
        }
    }
}
