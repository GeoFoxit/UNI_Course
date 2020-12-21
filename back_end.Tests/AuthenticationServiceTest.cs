using back_end.models;
using back_end.Services;
using back_end.Tests.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace back_end.Tests
{
    class AuthenticationServiceTest
    {
        private MockUsers mockUsers;
        private DbSet<User> mockDbSet;
        private ApplicationContext mockAppContext;
        private AuthenticationService users;

        [SetUp]
        public void Setup()
        {
            this.mockUsers = new MockUsers();
            this.mockDbSet = NSubstituteUtils.CreateMockDbSet(mockUsers.Users);
            this.mockAppContext = Substitute.For<ApplicationContext>();
            mockAppContext.Users.Returns(mockDbSet);
            this.users = new AuthenticationService(mockAppContext);
        }

        [Test]
        public void GetUser_Returns_Correct_User()
        {
            // Act
            string login = "admin";
            string password = "password";
            var data = users.GetUser(login, password);

            // Assert
            Assert.IsNotNull(data);
            Assert.AreEqual(data.Login, login);
            Assert.AreEqual(data.Password, password);
        }

        [Test]
        public void GetUser_Returns_Null_On_Wrong_Login()
        {
            // Act
            string login = "kitty";
            string password = "password";
            var data = users.GetUser(login, password);

            // Assert
            Assert.IsNull(data);
        }

        [Test]
        public void GetUser_Returns_Null_On_Wrong_Password()
        {
            // Act
            string login = "admin";
            string password = "123456";
            var data = users.GetUser(login, password);

            // Assert
            Assert.IsNull(data);
        }

        [Test]
        public void GetById_Returns_Correct_User()
        {
            // Act
            var data = users.GetById(1);

            // Assert
            Assert.IsNotNull(data);
            Assert.AreEqual(data.Login, "admin");
            Assert.AreEqual(data.Password, "password");
        }

        [Test]
        public void GetById_Returns_Null_On_Wrong_Id()
        {
            // Act
            var data = users.GetById(5);

            // Assert
            Assert.IsNull(data);
        }
    }
}
