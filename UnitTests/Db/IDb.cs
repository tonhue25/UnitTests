namespace UnitTests.Db
{
    public interface IDb
    {
        public LoginModel GetUser(LoginModel login);
    }
}
