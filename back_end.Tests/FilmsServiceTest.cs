using back_end.models;
using back_end.Services;
using back_end.Tests.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;

namespace back_end.Tests
{
    public class Tests
    {
        private MockFilms mockFilms;
        private DbSet<Film> mockDbSet;
        private ApplicationContext mockAppContext;
        private FilmsService films;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<ApplicationContext> options = new DbContextOptions<ApplicationContext>();

            this.mockFilms = new MockFilms();
            this.mockDbSet = NSubstituteUtils.CreateMockDbSet(mockFilms.Films);
            this.mockAppContext = Substitute.For<ApplicationContext>();
            mockAppContext.Films.Returns(mockDbSet);
            this.films = new FilmsService(mockAppContext);
        }

        [Test]
        public void GetAll_Should_Return_All_Films()
        {
            // Arrange - in Setup()

            // Act
            var data = films.GetAll();

            // Assert
            Assert.AreEqual(data[0].Naming, "Star Wars");
        }
    }
}