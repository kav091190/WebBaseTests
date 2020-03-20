using NUnit.Framework;

namespace WebBaseTests
{
    public class AuthentificationTests : TestBase
    {
        [Test]
        public void SuccessfulLoginTest()
        {
            var account = new AccountData("Калиниченко Антон", "123456");
            GoToPage();
            Login(account);
        }
        
        [Test]
        public void UserNameRequiredTest()
        {
            var account = new AccountData("", "123456");
            GoToPage();
            Login(account);
        }

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
        

    }
}






