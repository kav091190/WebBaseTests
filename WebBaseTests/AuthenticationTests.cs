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
                yield return new TestCaseData("Калиниченко Антон", "123456").Returns("Калиниченко Антон")
                    .SetName("{m}.{a}")
                    .SetDescription("Пользователь успешно авторизовался с указанными параметрами");

                yield return new TestCaseData("Калиниченко Антон2", "123456").Returns("Калиниченко Антон2")
                    .SetName("{m}.{a}")
                    .SetDescription("Пользователь успешно авторизовался с указанными параметрами");

                yield return new TestCaseData("АнтонМ", "123456").Returns("АнтонМ")
                    .SetName("{m}.{a}")
                    .SetDescription("Пользователь успешно авторизовался с указанными параметрами");
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

        public static IEnumerable UserDataRequiredAuthentificationData
        {
            get
            {
                var UserNameRequiredNotification = "Поле ''Имя пользователя'' является обязательным.";
                var PasswordRequiredNotification = "Поле ''Пароль'' является обязательным.";
                yield return new TestCaseData(string.Empty, "123456", UserNameRequiredNotification)
                    .SetName("{c}.{m}.{a}")
                    .SetDescription("Оповещение пользователя о необходимости логина, при попытке авторизации без него");

                yield return new TestCaseData(string.Empty, "1", UserNameRequiredNotification)
                    .SetName("{c}.{m}.{a}")
                    .SetDescription("Оповещение пользователя о необходимости логина, при попытке авторизации без него");

                yield return new TestCaseData(string.Empty, "0000000000000000000000", UserNameRequiredNotification)
                    .SetName("{c}.{m}.{a}")
                    .SetDescription("Оповещение пользователя о необходимости логина, при попытке авторизации без него");

                yield return new TestCaseData("Калиниченко Антон", string.Empty, PasswordRequiredNotification)
                    .SetName("{c}.{m}.{a}")
                    .SetDescription("Оповещение пользователя о необходимости пароля, при попытке авторизоваться без него");

                yield return new TestCaseData("Оʻzbek tili", string.Empty, PasswordRequiredNotification)
                    .SetName("{c}.{m}.{a}")
                    .SetDescription("Оповещение пользователя о необходимости пароля, при попытке авторизоваться без него");

                yield return new TestCaseData("122334568656", string.Empty, PasswordRequiredNotification)
                    .SetName("{c}.{m}.{a}")
                    .SetDescription("Оповещение пользователя о необходимости пароля, при попытке авторизоваться без него");
            }
        }

        [TestCaseSource(nameof(UserDataRequiredAuthentificationData))]
        public void UserDataRequiredAuthentification(string username, string password, string notification)
        {
            var account = new AccountData(username, password);
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin(account);
            StringAssert.AreEqualIgnoringCase(loginPage.GetFailureNotificationText(), notification);

        }

        [TestCase("Калиниченко Антон", "654321", ExpectedResult = "dev.dns-shop.ru/login")]
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






