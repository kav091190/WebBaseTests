using NUnit.Framework;

namespace WebBaseTests
{
    public class AuthentificationTests : TestBase
    {
        [Test]
        public void SuccessfulAuthentification()
        {
            var account = new AccountData("����������� �����", "123456");
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenLoginPage(driver);
            loginPage.PerformLogin(account);
            Pages.ConsultantPage consultantPage = new Pages.ConsultantPage(driver);
            StringAssert.Contains(account.Username, consultantPage.LogedInUserName());
        }
        
        [Test]
        public void UserNameRequiredAuthentification()
        {
            var account = new AccountData(string.Empty, "123456");
            var notification = "���� ''��� ������������'' �������� ������������.";
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenLoginPage(driver);
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(notification, loginPage.GetFailureNotificationText());

        }
        
        [Test]
        public void PasswordRequiredAuthentification()
        {
            var account = new AccountData("����������� �����", string.Empty);
            var notification = "���� ''������'' �������� ������������.";
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenLoginPage(driver);
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(notification, loginPage.GetFailureNotificationText());
        }
        
        [Test]
        public void WrongPasswordAuthentification()
        {
            var account = new AccountData("����������� �����", "654321");
            var notification = string.Empty;
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenLoginPage(driver);
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(notification, loginPage.GetFailureNotificationText());
        }
    }
}






