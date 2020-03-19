
namespace WebBaseTests
{
    public class AccountData
    {
        //объявляю параметры (свой-ва), которые будут описывать объекты класса (по-умолчанию они = 0)
        private string username;
        private string password;

        //конструктор с помощью которого контруирую объект в одну строчку, указывая обязательные параметры
        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        //метод-аксессор с помощью которого могу получить параметр Username и поменять его
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        //метод-аксессор для Password
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
