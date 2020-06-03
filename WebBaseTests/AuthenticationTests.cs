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
                    .SetName("{m}{a}")
                    .SetDescription("Пользователь успешно авторизовался с указанными параметрами");

                yield return new TestCaseData("Калиниченко Антон2", "123456").Returns("Калиниченко Антон2")
                    .SetName("{m}{a}")
                    .SetDescription("Пользователь успешно авторизовался с указанными параметрами");

                yield return new TestCaseData("АнтонМ", "123456").Returns("АнтонМ")
                    .SetName("{m}{a}")
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

        public static IEnumerable UserNameRequiredAuthentificationData
        {
            get
            {
                var UserNameRequiredNotification = "Поле \"Имя пользователя\" обязательно для заполнения";

                yield return new TestCaseData("123456", UserNameRequiredNotification)
                    .SetName("{m}{a}")
                    .SetDescription("Оповещение пользователя о необходимости логина, при попытке авторизации без него");

                yield return new TestCaseData("1", UserNameRequiredNotification)
                    .SetName("{m}{a}")
                    .SetDescription("Оповещение пользователя о необходимости логина, при попытке авторизации без него");

                yield return new TestCaseData("0000000000000000000000", UserNameRequiredNotification)
                    .SetName("{m}{a}")
                    .SetDescription("Оповещение пользователя о необходимости логина, при попытке авторизации без него");
            }
        }

        [TestCaseSource(nameof(UserNameRequiredAuthentificationData))]
        public void UserNameRequiredAuthentification(string password, string notification)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.FillPasswordTextField(password);
            loginPage.ClickSubmitButton();
            StringAssert.AreEqualIgnoringCase(loginPage.GetUserNameValidationMessageText(), notification);

        }

        public static IEnumerable PasswordRequiredAuthentificationData
        {
            get
            {
                var PasswordRequiredNotification = "Поле \"Пароль\" обязательно для заполнения";

                yield return new TestCaseData("Калиниченко Антон", PasswordRequiredNotification)
                    .SetName("{m}{a}")
                    .SetDescription("Оповещение пользователя о необходимости пароля, при попытке авторизоваться без него");

                yield return new TestCaseData("Оʻzbek tili", PasswordRequiredNotification)
                    .SetName("{m}{a}")
                    .SetDescription("Оповещение пользователя о необходимости пароля, при попытке авторизоваться без него");

                yield return new TestCaseData("122334568656", PasswordRequiredNotification)
                    .SetName("{m}{a}")
                    .SetDescription("Оповещение пользователя о необходимости пароля, при попытке авторизоваться без него");
            }
        }

        [TestCaseSource(nameof(PasswordRequiredAuthentificationData))]
        public void PasswordRequiredAuthentification(string username, string notification)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.FillUserNameTextField(username);
            loginPage.ClickSubmitButton();
            StringAssert.AreEqualIgnoringCase(loginPage.GetPasswordValidationMessageText(), notification);
        }

        [TestCase("Калиниченко Антон", "654321", 
            ExpectedResult = "dev.dns-shop.ru/login", 
            TestName ="{m}{a}")]
        [TestCase("Калиниченко Антон2", "dsfr5", 
            ExpectedResult = "dev.dns-shop.ru/login", 
            TestName = "{m}{a}")]
        [TestCase("АнтонМ", "ва4ыва", 
            ExpectedResult = "dev.dns-shop.ru/login", 
            TestName = "{m}{a}")]
        public string WrongPasswordAuthentification(string username, string password)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin(username, password);
            StringAssert.AreEqualIgnoringCase(loginPage.GetErrorMessageText(), "Неверный логин или пароль");
            return driver.Url.Replace("http://", string.Empty);
        }

        
    }
}






