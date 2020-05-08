using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebBaseTests.Pages
{
    class ConsultantPage : PageBase
    {
        public ConsultantPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.ClassName, Using = "loginDisplay")]
        private IWebElement loginDisplay { get; set; } // получаю всю шапку

        public string LogedInUserName()
        {
           return loginDisplay.Text;
        }
    }
}
