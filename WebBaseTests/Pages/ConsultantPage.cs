using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBaseTests.Pages
{
    class ConsultantPage
    {
        [FindsBy(How = How.ClassName, Using = "loginDisplay")]
        protected IWebElement ;

    }
}
