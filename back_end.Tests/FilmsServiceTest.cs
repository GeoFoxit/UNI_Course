using back_end.models;
using back_end.Services;
using back_end.Tests.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System;

namespace back_end.Tests
{
    public class FilmsServiceTest
    {
        private MockFilms mockFilms;
        private DbSet<Film> mockDbSet;
        private ApplicationContext mockAppContext;
        private FilmsService films;

        [SetUp]
        public void Setup()
        {
            this.mockFilms = new MockFilms();
            this.mockDbSet = NSubstituteUtils.CreateMockDbSet(mockFilms.Films);
            this.mockAppContext = Substitute.For<ApplicationContext>();
            mockAppContext.Films.Returns(mockDbSet);
            this.films = new FilmsService(mockAppContext);
        }

        [Test]
        public void GetAll_Should_Return_All_Films()
        {
            // Act
            var data = films.GetAll();

            // Assert
            Assert.AreEqual(data.Count, 2);
        }

        [Test]
        public void GetById_Should_Return_Correct_Film()
        {
            // Act
            var data = films.GetById(1);

            // Assert
            Assert.AreEqual(data.Naming, "Star Wars");
        }

        [Test]
        public void GetById_Should_Return_Null_On_Wrong_Id()
        {
            // Act
            var data = films.GetById(5);

            // Assert
            Assert.AreEqual(data, null);
        }

        [Test]
        public void Add()
        {
        }

        [Test]
        public void Delete()
        {

        }

        [Test]
        public void GetListById_Throws_NotImplementedException()
        {
            Assert.That(() => films.GetListById(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void Update_Throws_NotImplementedException()
        {
            Assert.That(() => films.Update(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void GetUser_Throws_NotImplementedException()
        {
            Assert.That(() => films.GetUser("user", "pass"),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }
    }
}