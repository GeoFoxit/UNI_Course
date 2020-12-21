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
    class SeatsServiceTest
    {
        private MockSeats mockSeats;
        private DbSet<Seat> mockDbSet;
        private ApplicationContext mockAppContext;
        private SeatsService seats;

        [SetUp]
        public void Setup()
        {
            this.mockSeats = new MockSeats();
            this.mockDbSet = NSubstituteUtils.CreateMockDbSet(mockSeats.Seats);
            this.mockAppContext = Substitute.For<ApplicationContext>();
            mockAppContext.Seats.Returns(mockDbSet);
            this.seats = new SeatsService(mockAppContext);
        }

        [Test]
        public void GetListById_Should_Return_Correct_Seats()
        {
            // Act
            var data = seats.GetListById(2);

            // Assert
            Assert.AreEqual(data.Count, 3);
        }

        [Test]
        public void GetListById_Should_Return_Empty_List_On_Wrong_Id()
        {
            // Act
            var data = seats.GetListById(5);

            // Assert
            Assert.AreEqual(data.Count, 0);
        }

        [Test]
        public void Update()
        {

        }

        [Test]
        public void GetAll_Throws_NotImplementedException()
        {
            Assert.That(() => seats.GetAll(),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void Add_Throws_NotImplementedException()
        {
            Seat seat = new Seat { Id = 4, IsFree = true, Number = 4, Price = 100, SessionId = 3 };

            Assert.That(() => seats.Add(seat),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void GetById_Throws_NotImplementedException()
        {
            Assert.That(() => seats.GetById(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void Delete_Throws_NotImplementedException()
        {
            Assert.That(() => seats.Delete(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void GetUser_Throws_NotImplementedException()
        {
            Assert.That(() => seats.GetUser("user", "pass"),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }
    }
}
