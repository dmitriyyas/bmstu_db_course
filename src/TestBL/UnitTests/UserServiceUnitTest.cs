using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBL.Mocks;
using BL.Services;
using BL.Models;

namespace TestBL.UnitTests
{
    [TestClass]
    public class UserServiceUnitTest
    {
        private void compare(User x, User y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.Login, y.Login);
            Assert.AreEqual(x.Password, y.Password);
            Assert.AreEqual(x.Permission, y.Permission);
        }

        [TestMethod]
        public void TestRegisterDefault()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            string login = "login";
            string password = "password";
            User user = new User(login, password);

            User createdUser = userService.register(login, password);

            compare(user, createdUser);
        }

        [TestMethod]
        public void TestRegisterSameLogin()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            string login = "login";
            string password = "password";

            User createdUser = userService.register(login, password);
            Assert.ThrowsException<Exception>(() => userService.register(login, password));
        }

        [TestMethod]
        public void TestLogInDefault()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            string login = "login";
            string password = "password";

            User user = new User(login, password);
            userMock.create(user);

            User loggedUser = userService.logIn(login, password);

            compare(user, loggedUser);
        }

        [TestMethod]
        public void TestLogInWrongPassword()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            string login = "login";
            string password = "password";

            User user = new User(login, password);
            userMock.create(user);

            Assert.ThrowsException<Exception>(() => userService.logIn(login, "wrong"));
        }

        [TestMethod]
        public void TestLogInUnknownLogin()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            string login = "login";
            string password = "password";

            User user = new User(login, password);
            userMock.create(user);

            Assert.ThrowsException<Exception>(() => userService.logIn("wrong", password));
        }

        [TestMethod]
        public void TestChangeUserPermissionsDefault()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            string login = "login";
            string password = "password";

            User user = new User(login, password);
            userMock.create(user);

            userService.changeUserPermissions(user.Id);

            user = userMock.getById(user.Id);
            Assert.AreEqual(user.Permission, "admin");
        }

        [TestMethod]
        public void TestChangeUserPermissionsUnknownId()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            string login = "login";
            string password = "password";

            User user = new User(login, password);
            userMock.create(user);

            Assert.ThrowsException<Exception>(() => userService.changeUserPermissions(-1));
        }

        [TestMethod]
        public void TestGetUserDefault()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            string login = "login";
            string password = "password";

            User user = new User(login, password);
            userMock.create(user);

            User gotUser = userService.getUser(user.Id);

            compare(user, gotUser);
        }

        [TestMethod]
        public void TestGetUserUnknownId()
        {
            Mock.clear();
            var userMock = new UserMock();
            var userService = new UserService(userMock, null);

            Assert.ThrowsException<Exception>(() => userService.getUser(-1));
        }
    }
}
