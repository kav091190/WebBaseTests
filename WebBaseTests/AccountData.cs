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

        public string Username { get; }
        public string Password { get; }
    }
}
