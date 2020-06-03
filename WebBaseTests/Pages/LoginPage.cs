using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace WebBaseTests.Pages
{
    class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageUrl += "/login";
        }

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement UserNameTextField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement PasswordTextField { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[starts-with(@class,'validationMessage') and contains(text(), 'Имя пользователя')]")]
        private IWebElement UserNameValidationMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[starts-with(@class,'validationMessage') and contains(text(), 'Пароль')]")]
        private IWebElement PasswordValidationMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class*=\"errorMessage\"]")]
        private IWebElement ErrorMessage { get; set; }

        public void FillUserNameTextField(string username)
        {
            UserNameTextField.SendKeys(username);
        }

        public void FillPasswordTextField(string password)
        {
            PasswordTextField.SendKeys(password);
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        public string GetUserNameValidationMessageText()
        {
            return UserNameValidationMessage.Text;
        }

        public string GetPasswordValidationMessageText()
        {
            return PasswordValidationMessage.Text;
        }

        public string GetErrorMessageText()
        {
            return ErrorMessage.Text;
        }

        public void PerformLogin(string username, string passward)
        {
            FillUserNameTextField(username);
            FillPasswordTextField(passward);
            ClickSubmitButton();
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class*=\"loading\"]")));
        }
    }
}