﻿using Moq;
using UnitTests.Controllers;
using UnitTests.Enums;
using UnitTests.Models;
using UnitTests.Services;

namespace UnitTests.Db.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        private Mock<IDb> _mockDb;
        private UserService _userService;

        [TestInitialize]
        public void Initialize()
        {
            _mockDb = new Mock<IDb>();
            _userService = new UserService(_mockDb.Object);
        }

        [TestMethod()]
        public void GetUserLogin_shouldReturnAcctInfo_whenRequestValid()
        {
            LoginModel request = new LoginModel("username", "password");
            LoginModel expectedLogin = new LoginModel("username", "password");

            ResponseModel expected = new ResponseModel(ErrorCode.Success, "", expectedLogin);

            _mockDb.Setup(x => x.GetUser(request)).Returns(expectedLogin);

            ResponseModel result = _userService.GetUserLogin(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(EnumExtensions.GetCodeValue(ErrorCode.Success), result.ErrCode);
            Assert.AreEqual(expected.Data.Username, result.Data.Username);
            Assert.AreEqual(expected.Data.Password, result.Data.Password);
        }

        [TestMethod()]
        public void GetUserLogin_shouldReturnNull_whenRequestValid()
        {
            LoginModel request = new LoginModel("username1", "password1");
            LoginModel expected = null;

            _mockDb.Setup(x => x.GetUser(request)).Returns(expected);

            ResponseModel result = _userService.GetUserLogin(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(EnumExtensions.GetCodeValue(ErrorCode.NotFound), result.ErrCode);
        }
    }
}