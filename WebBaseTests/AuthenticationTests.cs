using NUnit.Framework;

namespace WebBaseTests
{
    public class AuthentificationTests : TestBase
    {

        [Test]
        public void Test()
        {
            var account = new AccountData("����������� �����", "123456");
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.PerformLogin(account);
            Pages.ConsultantPage consultantPage = new Pages.ConsultantPage(driver);
            StringAssert.Contains(account.Username, consultantPage.LogedInUserName());
        }
        
        [Test]
        public void UserNameRequiredTest()
        {
            var account = new AccountData(string.Empty, "123456");
            var notification = "���� ''��� ������������'' �������� ������������.";
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(notification, loginPage.FailureNotification());

        }
        
        [Test]
        public void PasswordRequiredTest()
        {
            var account = new AccountData("����������� �����", string.Empty);
            var notification = "���� ''������'' �������� ������������.";
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(notification, loginPage.FailureNotification());
        }


        [Test]
        public void WrongPasswordTest()
        {
            var account = new AccountData("����������� �����", "654321");
            var notification = string.Empty;
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(notification, loginPage.FailureNotification());
        }
    }
}






