using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebBaseTests.Pages
{
    class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageUrl = PageUrl + "/login";
        }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_UserName")]
        private IWebElement UserNameTextField { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_Password")]
        private IWebElement PasswordTextField { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_LoginButton")]
        private IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_LoginUserValidationSummary")]
        private IWebElement ValidationSummaryNotification { get; set; }

        public string GetFailureNotificationText()
        {
            return ValidationSummaryNotification.Text;
        }
        
        public void PerformLogin(AccountData account)
        {
            UserNameTextField.SendKeys(account.Username);
            PasswordTextField.SendKeys(account.Password);
            SubmitButton.Click();
        }
        public void PerformLogin(string username, string password)
        {
            UserNameTextField.SendKeys(username);
            PasswordTextField.SendKeys(password);
            SubmitButton.Click();
        }
    }
}

