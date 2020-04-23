using NUnit.Framework;

namespace WebBaseTests
{
    public class AuthentificationTests : TestBase
    {
        /*
        [Test]
        public void SuccessfulLoginTest()
        {
            var account = new AccountData("Калиниченко Антон", "123456");
            GoToPage();
            Login(account);
        }*/

        [Test]
        public void Test()
        {
            var account = new AccountData("Калиниченко Антон", "123456");
            GoToPage();
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.PerformLogin(account);
            Pages.ConsultantPage consultantPage = new Pages.ConsultantPage(driver);
            StringAssert.Contains(account.Username, consultantPage.LogedInUserName());
        }
        
        [Test]
        public void UserNameRequiredTest()
        {
            var account = new AccountData(string.Empty, "123456");
            var notification = "Поле ''Имя пользователя'' является обязательным.";
            GoToPage();
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(notification, loginPage.FailureNotification());

        }
        /*
        [Test]
        public void PasswordRequiredTest()
        {
            var account = new AccountData("Калиниченко Антон", "");
            GoToPage();
            Login(account);
        }

        [Test]
        public void WrongPasswordTest()
        {
            var account = new AccountData("Калиниченко Антон", "");
            GoToPage();
            Login(account);
        }
        */

    }
}






