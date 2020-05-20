using NUnit.Framework;
using System.Collections;

namespace WebBaseTests
{
    public class AuthentificationTests : TestBase
    {
        public static IEnumerable SuccessfulAuthentificationData
        {
            get
            {
                yield return new TestCaseData("Калиниченко Антон", "123456").Returns("Калиниченко Антон");
                yield return new TestCaseData("Калиниченко Антон2", "123456").Returns("Калиниченко Антон2");
                yield return new TestCaseData("АнтонМ", "123456").Returns("АнтонМ");
            }
        }

        [TestCaseSource(nameof(SuccessfulAuthentificationData))]
        public string SuccessfulAuthentification(string username, string password)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin(username, password);
            Pages.ConsultantPage consultantPage = new Pages.ConsultantPage(driver);
            return consultantPage.GetLogedInUserNameText().Replace(" [ Сменить ] [ Выйти ]\r\n[ Печать визиток ]", string.Empty);
        }

        public static IEnumerable UserNameRequiredAuthentificationData
        {
            get
            {
                var notification = "Поле ''Имя пользователя'' является обязательным.";
                yield return new TestCaseData("123456", notification);
                yield return new TestCaseData("1", notification);
                yield return new TestCaseData("0000000000000000000000", notification);
            }
        }

        [TestCaseSource(nameof(UserNameRequiredAuthentificationData))]
        public void UserNameRequiredAuthentification(string password, string notification)
        {
            var account = new AccountData(password: password);
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(loginPage.GetFailureNotificationText(), notification);

        }

        [TestCase("Калиниченко Антон", "Поле ''Пароль'' является обязательным.", TestName = "тест"), Description("Вывод сообщения об обязательно пароля, при авторизации без его указания")]
        [TestCase("Оʻzbek tili", "Поле ''Пароль'' является обязательным.", TestName = "тест2")]
        [TestCase("122334568656", "Поле ''Пароль'' является обязательным.", TestName = "тест3")]
        public void PasswordRequiredAuthentification(string username, string notification)
        {
            var account = new AccountData(username: username);
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(loginPage.GetFailureNotificationText(), notification);
        }
        
        [TestCase("Калиниченко Антон", "654321", ExpectedResult = "dev.dns-shop.ru/login"), Description("Сохранение пользователя на странице авторизации, если при авторизации был неверно указан пароль")]
        [TestCase("Калиниченко Антон2", "dsfr5", ExpectedResult = "dev.dns-shop.ru/login")]
        [TestCase("АнтонМ", "ва4ыва", ExpectedResult = "dev.dns-shop.ru/login")]
        public string WrongPasswordAuthentification(string username, string password)
        {
            var notification = string.Empty;
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin(username, password);
            return driver.Url.Replace("http://", string.Empty);
        }
    }
}






