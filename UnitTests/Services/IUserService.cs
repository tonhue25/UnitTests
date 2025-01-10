using UnitTests.Models;

namespace UnitTests.Services
{
    public interface IUserService
    {
        public ResponseModel GetUserLogin(LoginModel login);
    }
}
