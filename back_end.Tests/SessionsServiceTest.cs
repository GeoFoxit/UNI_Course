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
    public class SessionsServiceTest
    {
        private MockSessions mockSessions;
        private DbSet<Session> mockDbSet;
        private ApplicationContext mockAppContext;
        private SessionsService sessions;

        [SetUp]
        public void Setup()
        {
            this.mockSessions = new MockSessions();
            this.mockDbSet = NSubstituteUtils.CreateMockDbSet(mockSessions.Sessions);
            this.mockAppContext = Substitute.For<ApplicationContext>();
            mockAppContext.Sessions.Returns(mockDbSet);
            this.sessions = new SessionsService(mockAppContext);
        }

        [Test]
        public void GetAll_Should_Return_All_Sessions()
        {
            // Act
            var data = sessions.GetAll();

            // Assert
            Assert.AreEqual(data.Count, 3);
        }

        [Test]
        public void GetListById_Should_Return_Correct_Sessions()
        {
            // Act
            var data = sessions.GetListById(2);

            // Assert
            Assert.AreEqual(data.Count, 2);
        }

        [Test]
        public void GetListById_Should_Return_Empty_List_On_Wrong_Id()
        {
            // Act
            var data = sessions.GetListById(5);

            // Assert
            Assert.AreEqual(data.Count, 0);
        }

        [Test]
        public void Add_Calls_SaveChanges()
        {
            // Arrange
            Session sessionToAdd = new Session { Id = 4, DateTime = DateTime.Now, FilmId = 1 };

            // Act
            var data = sessions.Add(sessionToAdd);

            // Assert
            mockAppContext.Received().Sessions.Add(sessionToAdd);
            mockAppContext.Received().SaveChanges();
        }

        [Test]
        public void Add_Throws_ArgumentNullException_On_Null_Parameter()
        {
            Assert.That(() => sessions.Add(null),
                Throws.Exception
                .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Delete_Calls_Remove_And_SaveChanges()
        {
            // Arrange
            Int32 id = 3;

            // Act
            var data = sessions.Delete(id);

            // Assert
            mockAppContext.Received().Sessions.Find(id);
            mockAppContext.Received().Sessions.Remove(Arg.Any<Session>());
            mockAppContext.Received().SaveChanges();
        }

        [Test]
        public void GetById_Throws_NotImplementedException()
        {
            Assert.That(() => sessions.GetById(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void Update_Throws_NotImplementedException()
        {
            Assert.That(() => sessions.Update(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void GetUser_Throws_NotImplementedException()
        {
            Assert.That(() => sessions.GetUser("user", "pass"),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }
    }
}
