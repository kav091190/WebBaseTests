namespace WebBaseTests
{
    public class Account
    {
        //конструктор с помощью которого контруирую объект в одну строчку, указывая обязательные параметры
        public Account(string username = "", string password = "")
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; }
    }
}
