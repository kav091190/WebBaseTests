using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Text.RegularExpressions;

namespace WebBaseTests.Pages
{
    class ConsultantPage : PageBase
    {
        public ConsultantPage(IWebDriver driver) : base(driver)
        {
            PageUrl = PageUrl + "/consultant";
        }

        [FindsBy(How = How.ClassName, Using = "loginDisplay")]
        private IWebElement LoginDisplay { get; set; } // получаем всю шапку 

        public string GetLogedInUserNameText()
        {
           return LoginDisplay.Text;           
        }
    }
}
