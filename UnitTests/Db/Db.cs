namespace UnitTests.Db
{
    public class Db : IDb
    {
        LoginModel loginModel = new LoginModel("username", "password");

        public LoginModel GetUser(LoginModel login)
        {
            if (login.Username.Equals(loginModel.Username) && login.Password.Equals(loginModel.Password))
            {
                return login;
            }
            return null;
        }
    }
}
