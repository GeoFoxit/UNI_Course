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
    class BookingsServiceTest
    {
        private MockBookings mockBookings;
        private DbSet<Booking> mockDbSet;
        private ApplicationContext mockAppContext;
        private BookingsService bookings;

        [SetUp]
        public void Setup()
        {
            this.mockBookings = new MockBookings();
            this.mockDbSet = NSubstituteUtils.CreateMockDbSet(mockBookings.Bookings);
            this.mockAppContext = Substitute.For<ApplicationContext>();
            mockAppContext.Bookings.Returns(mockDbSet);
            this.bookings = new BookingsService(mockAppContext);
        }

        [Test]
        public void Add()
        {

        }

        [Test]
        public void GetById_Should_Return_Correct_Booking()
        {
            // Act
            var data = bookings.GetById(1);

            // Assert
            Assert.AreEqual(data.SeatId, 1);
        }

        [Test]
        public void GetById_Should_Return_Null_On_Wrong_Id()
        {
            // Act
            var data = bookings.GetById(5);

            // Assert
            Assert.AreEqual(data, null);
        }

        [Test]
        public void GetAll_Throws_NotImplementedException()
        {
            Assert.That(() => bookings.GetAll(),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void GetListById_Throws_NotImplementedException()
        {
            Assert.That(() => bookings.GetListById(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void Delete_Throws_NotImplementedException()
        {
            Assert.That(() => bookings.Delete(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void Update_Throws_NotImplementedException()
        {
            Assert.That(() => bookings.Update(1),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }

        [Test]
        public void GetUser_Throws_NotImplementedException()
        {
            Assert.That(() => bookings.GetUser("user", "pass"),
                Throws.Exception
                .TypeOf<NotImplementedException>());
        }
    }
}
