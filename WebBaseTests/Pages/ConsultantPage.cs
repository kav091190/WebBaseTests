using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBaseTests.Pages
{
    class ConsultantPage
    {
        public ConsultantPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "loginDisplay")]
        private IWebElement loginDisplay { get; set; } // получаю всю шапку

        public string LogedInUserName()
        {
           return loginDisplay.Text;
        }
        

    }
}
