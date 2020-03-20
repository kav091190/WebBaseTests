
namespace WebBaseTests
{
    public class AccountData
    {
        //конструктор с помощью которого контруирую объект в одну строчку, указывая обязательные параметры
        public AccountData(string username = "", string password = "")
        {
            Username = username;
            Password = password;
        }

        //метод-аксессор с помощью которого могу получить параметр Username и поменять его
        public string Username { get; }

        //метод-аксессор для Password
        public string Password { get;  }
    }
}
