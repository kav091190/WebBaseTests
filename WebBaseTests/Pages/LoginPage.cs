using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebBaseTests.Pages
{
    class LoginPage
    { 
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_UserName")]   //FindBy - атрибут
        private IWebElement UserNameTextField { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_Password")]
        private IWebElement PasswordTextField { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_LoginButton")]
        private IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_LoginUserValidationSummary")]
        private IWebElement ValidationSummaryNotification { get; set; }

        public string FailureNotification()
        {
            return ValidationSummaryNotification.Text;
        }


        public void PerformLogin(AccountData account)
        {
            UserNameTextField.SendKeys(account.Username);
            PasswordTextField.SendKeys(account.Password);
            SubmitButton.Click();
        }



    }
}

