using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VideosOnDemandEntityDatabase;
using Moq;
using System.Linq;
using System.Data.Entity;
using VideoOnDemandProjectDay1;

namespace VideosOnDemandProjectTestsDay1
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void Test_GetAllFilms_FromTheDatabase_ReturnAnEmptyList()
        {
            //Arrange
            var data = new List<film>().AsQueryable();

            var mockSet = new Mock<DbSet<film>>();
            mockSet.As<IQueryable<film>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<film>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<film>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<film>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.films).Returns(mockSet.Object);

            //Act
            var repo = new FilmRepository(mockContext.Object);
            var listOfFilms = repo.GetAllFilms();

            //Assert
            Assert.AreEqual(0, listOfFilms.Count);
        }

        [TestMethod]
        public void Test_GetAllFilms_FromTheDatabase_ReturnAListOfOneFilm()
        {
            //Arrange
            var data = new List<film>
            {
                new film { name = "Pokemon", length_minute = 150, release_date = Convert.ToDateTime("1990-01-01") }

            }.AsQueryable();

            var mockSet = new Mock<DbSet<film>>();
            mockSet.As<IQueryable<film>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<film>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<film>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<film>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.films).Returns(mockSet.Object);

            //Act
            var repo = new FilmRepository(mockContext.Object);
            var listOfFilms = repo.GetAllFilms();

            //Assert
            Assert.AreEqual(1, listOfFilms.Count);
        }

        [TestMethod]
        public void Test_GetAllTelevisionShows_FromTheDatabase_ReturnAnEmptyList()
        {
            //Arrange
            var data = new List<television>().AsQueryable();

            var mockSet = new Mock<DbSet<television>>();
            mockSet.As<IQueryable<television>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<television>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<television>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<television>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.televisions).Returns(mockSet.Object);

            //Act
            var repo = new TelevisionRepository(mockContext.Object);
            var listOfTVShows = repo.GetAllTelevisionShows();

            //Assert
            Assert.AreEqual(0, listOfTVShows.Count);
        }

        [TestMethod]
        public void Test_GetAllTelevisionShows_FromTheDatabase_ReturnAListOfTwoTelevisionShows()
        {
            //Arrange
            var data = new List<television>
            {
                new television { name = "The Wire", number_of_seasons = 6, number_of_episodes = 72, length_minute = 60, release_date = Convert.ToDateTime("01-01-00") },
                new television { name = "Sons Of Anarchy", number_of_seasons = 7, number_of_episodes = 84, length_minute = 45, release_date = Convert.ToDateTime("01-01-10") }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<television>>();
            mockSet.As<IQueryable<television>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<television>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<television>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<television>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.televisions).Returns(mockSet.Object);

            //Act
            var repo = new TelevisionRepository(mockContext.Object);
            var listOfTVShows = repo.GetAllTelevisionShows();

            //Assert
            Assert.AreEqual(2, listOfTVShows.Count);
        }

        //[TestMethod]
        //public void Test_GetAListOfTwoTelevisionShows_WithTheTwoDifferentGenresFromTheDatabase_ReturnAListOfTwoTelevisionShows2()
        //{
        //    //Arrange
        //    var genreC = new genre() { name = "Crime" };
        //    var genreW = new genre() { name = "Western" };

        //    var data = new List<television>
        //    {
        //        new television { name = "The Wire", genre = "Crime"},
        //        new television { name = "Sons Of Anarchy", genre = genreW}
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<television>>();
        //    mockSet.As<IQueryable<television>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<television>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<television>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<television>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        //    var mockContext = new Mock<videosOnDemandEntities>();
        //    mockContext.Setup(a => a.televisions).Returns(mockSet.Object);

        //    //Act
        //    var repo = new TelevisionRepository(mockContext.Object);
        //    var listOfTVShows = repo.GetAllTelevisionShows();

        //    //Assert
        //    Assert.AreEqual(2, listOfTVShows.Count);
        //    Assert.AreEqual("Crime", listOfTVShows[0].genre);
        //}

        [TestMethod]
        public void Test_DeletesAUsernameWhenSubscriptionIsExpired_SavesToDatabase()
        {
            //arrange
            var data = new List<username>
            {
                new username {subscription = "expired"}
            }.AsQueryable();


            var mockSet = new Mock<DbSet<username>>();
            mockSet.As<IQueryable<username>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<username>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<username>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<username>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            //act
            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.usernames).Returns(mockSet.Object);

            var repo = new UsernameRepository(mockContext.Object);
            repo.DeleteUser("expired");

            //assert
            mockContext.Verify(a => a.SaveChanges());
        }

        [TestMethod]
        public void Test_DeletesTwoUsernamesWhenSubscriptionIsExpired_SavesToDatabase()
        {
            //arrange
            var data = new List<username>
            {
                new username {subscription = "expired"},
                new username {subscription = "expired"}

            }.AsQueryable();


            var mockSet = new Mock<DbSet<username>>();
            mockSet.As<IQueryable<username>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<username>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<username>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<username>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            //act
            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.usernames).Returns(mockSet.Object);

            var repo = new UsernameRepository(mockContext.Object);
            repo.DeleteUser("expired");

            //assert
            mockContext.Verify(a => a.SaveChanges());
        }

        [TestMethod]
        public void Test_DeletesAFilmFromMediaLibraray_SavesToDatabase()
        {
            //arrange
            var data = new List<film>
            {
                new film {name="Usual Suspects",length_minute=210,release_date=Convert.ToDateTime("01-01-2000")}
            }.AsQueryable();


            var mockSet = new Mock<DbSet<film>>();
            mockSet.As<IQueryable<film>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<film>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<film>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<film>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            //act
            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.films).Returns(mockSet.Object);

            var repo = new FilmRepository(mockContext.Object);
            repo.RemoveFilm("Usual Suspects");

            //assert
            mockContext.Verify(a => a.SaveChanges());
        }

        [TestMethod]
        public void Test_DeletesATVShowFromMediaLibraray_SavesToDatabase()
        {
            //arrange
            var data = new List<television>
            {
                new television {name="Luther", number_of_seasons = 4, number_of_episodes = 45, length_minute = 60, release_date = Convert.ToDateTime("01-01-2010")}
            }.AsQueryable();


            var mockSet = new Mock<DbSet<television>>();
            mockSet.As<IQueryable<television>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<television>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<television>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<television>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            //act
            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.televisions).Returns(mockSet.Object);

            var repo = new TelevisionRepository(mockContext.Object);
            repo.RemoveTVShow("Luther");

            //assert
            mockContext.Verify(a => a.SaveChanges());
        }
    }
}
