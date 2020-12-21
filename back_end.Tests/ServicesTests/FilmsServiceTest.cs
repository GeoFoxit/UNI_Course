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
            Assert.AreEqual(data.Genre, "Action");
            Assert.AreEqual(data.Rate, 4);
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
        public void Add_Calls_SaveChanges()
        {
            // Arrange
            Film filmToAdd = new Film { Id = 3, Naming = "Hobbit", Genre = "Fantasy", Rate = 5 };

            // Act
            var data = films.Add(filmToAdd);

            // Assert
            mockAppContext.Received().Films.Add(filmToAdd);
            mockAppContext.Received().SaveChanges();
        }

        [Test]
        public void Add_Throws_ArgumentNullException_On_Null_Parameter()
        {
            Assert.That(() => films.Add(null),
                Throws.Exception
                .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Delete_Calls_Remove_And_SaveChanges()
        {
            // Arrange
            Int32 id = 2;

            // Act
            var data = films.Delete(id);

            // Assert
            mockAppContext.Received().Films.Find(id);
            mockAppContext.Received().Films.Remove(Arg.Any<Film>());
            mockAppContext.Received().SaveChanges();
        }

        [Test]
        public void Delete_Not_Calls_SaveChanges_OnWrongId()
        {
            // Arrange
            Int32 id = 10;

            // Act
            var data = films.Delete(id);

            // Assert
            mockAppContext.Received().Films.Find(id);
            mockAppContext.Received().Films.Remove(Arg.Any<Film>());
            mockAppContext.DidNotReceive().SaveChanges();
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