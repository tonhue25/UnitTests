using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTests.Enums;
using UnitTests.Models;
using UnitTests.Services;

namespace UnitTests.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {

        private Mock<IUserService> _mockUserService;
        private HomeController _homeController;

        [TestInitialize]
        public void Initialize()
        {
            _mockUserService = new Mock<IUserService>();
            _homeController = new HomeController(_mockUserService.Object);
        }

        // 00
        [TestMethod()]
        public void Login_LoginData_ReturnsOkResultWithUser()
        {
            // arrange
            LoginModel request = new LoginModel("username", "password");
            LoginModel expectedLogin = new LoginModel("username", "password");
            ResponseModel expected = new ResponseModel(ErrorCode.Success, "Login success", expectedLogin);

            _mockUserService.Setup(s => s.GetUserLogin(request)).Returns(expected);

            // act
            var result = _homeController.Login(request) as OkObjectResult;
            ResponseModel responseModel = (ResponseModel)result.Value;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(responseModel?.Data);
            Assert.AreEqual("Login success", responseModel.ErrMsg);

            Assert.AreEqual(EnumExtensions.GetCodeValue(ErrorCode.Success), responseModel.ErrCode);
            Assert.AreEqual(expected.Data.Username, responseModel.Data.Username);
            Assert.AreEqual(expected.Data.Password, responseModel.Data.Password);
        }

        //01
        [TestMethod()]
        public void Login_LoginData_ReturnsNotFound()
        {
            // arrange
            LoginModel request = new LoginModel("username1", "password");
            ResponseModel expected = new ResponseModel(ErrorCode.NotFound);

            _mockUserService.Setup(x => x.GetUserLogin(request))
            .Returns(expected);

            // act
            var result = _homeController.Login(request) as OkObjectResult;
            ResponseModel responseModel = (ResponseModel)result.Value;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            
            Assert.IsNull(responseModel?.Data);
            Assert.AreEqual(EnumExtensions.GetCodeValue(ErrorCode.NotFound), responseModel.ErrCode);
        }

        //03
        [TestMethod()]
        public void Login_Password_ReturnsInvalidInputData()
        {
            // arrange
            LoginModel request = new LoginModel("", "password");
            ResponseModel expected = new ResponseModel(ErrorCode.InvalidInputData);

            _mockUserService.Setup(x => x.GetUserLogin(request)).Returns(expected);

            // act
            var result = _homeController.Login(request) as OkObjectResult;
            ResponseModel responseModel = (ResponseModel)result.Value;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            Assert.IsNull(responseModel?.Data);

            Assert.AreEqual(EnumExtensions.GetCodeValue(ErrorCode.InvalidInputData), responseModel.ErrCode);
            Assert.AreEqual(EnumExtensions.GetDescription(ErrorCode.InvalidInputData), responseModel.ErrMsg);
        }

        //03
        [TestMethod()]
        public void Login_Username_ReturnsInvalidInputData()
        {
            // arrange
            LoginModel request = new LoginModel("username", "");
            ResponseModel expected = new ResponseModel(ErrorCode.InvalidInputData);

            _mockUserService.Setup(x => x.GetUserLogin(request)).Returns(expected);

            // act
            var result = _homeController.Login(request) as OkObjectResult;
            ResponseModel responseModel = (ResponseModel)result.Value;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNull(responseModel?.Data);

            Assert.AreEqual(EnumExtensions.GetCodeValue(ErrorCode.InvalidInputData), responseModel.ErrCode);
            Assert.AreEqual(EnumExtensions.GetDescription(ErrorCode.InvalidInputData), responseModel.ErrMsg);
        }

        //03
        [TestMethod()]
        public void Login_ReturnsInvalidInputData()
        {
            // arrange
            LoginModel request = new LoginModel("", "");
            ResponseModel expected = new ResponseModel(ErrorCode.InvalidInputData);

            _mockUserService.Setup(x => x.GetUserLogin(request)).Returns(expected);

            // act
            var result = _homeController.Login(request) as OkObjectResult;
            ResponseModel responseModel = (ResponseModel)result.Value;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNull(responseModel?.Data);

            Assert.AreEqual(EnumExtensions.GetCodeValue(ErrorCode.InvalidInputData), responseModel.ErrCode);
            Assert.AreEqual(EnumExtensions.GetDescription(ErrorCode.InvalidInputData), responseModel.ErrMsg);
        }
    }
}