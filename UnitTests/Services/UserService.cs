using UnitTests.Enums;
using UnitTests.Models;
using UnitTests.Services;

namespace UnitTests.Db
{
    public class UserService : IUserService
    {
         private IDb _db;
        public UserService(IDb db)
        {
            _db = db;
        }

        public ResponseModel GetUserLogin(LoginModel login)
        {
            LoginModel loginResponse = _db.GetUser(login);
            ResponseModel response = new ResponseModel(ErrorCode.NotFound);

            if (loginResponse != null)
            {
                response = new ResponseModel(ErrorCode.Success, "" , loginResponse);
            }
            
            return response;
        }
    }
}
