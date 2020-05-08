using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebBaseTests.Pages
{
    abstract class PageBase
    {
        public void GoToPage(IWebDriver driver, string PageUrl = "")
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
