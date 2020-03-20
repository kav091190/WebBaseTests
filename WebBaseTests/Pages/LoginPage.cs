using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBaseTests.Pages
{
    class LoginPage
    {
        protected IWebDriver driver;
        driver = 

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_UserName")]
        protected IWebElement UserNameTextField;
        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_Password")]
        protected IWebElement PasswordTextField;
        [FindsBy(How = How.ClassName, Using = "submitButton")]
        protected IWebElement SubmitButton;
        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_LoginUserValidationSummary")]
        protected IWebElement FailureNotification;

    }
}
