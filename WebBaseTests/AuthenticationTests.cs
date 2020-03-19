using NUnit.Framework;

namespace WebBaseTests
{
    public class AuthentificationTests : TestBase
    {
        [Test]
        public void SuccessfulLoginTest()
        {
            GoToPage();
            Login(new AccountData("����������� �����", "123456"));
        }
        
        [Test]
        public void UserNameRequiredTest()
        {
            GoToPage();
            Login(new AccountData("", "123456"));
        }

        [Test]
        public void PasswordRequiredTest()
        {
            GoToPage();L
            Login(new AccountData("����������� �����", ""));
        }

        [Test]
        public void WrongPasswordTest()
        {
            GoToPage();
            Login(new AccountData("����������� �����", "1"));
        }
        

    }
}






