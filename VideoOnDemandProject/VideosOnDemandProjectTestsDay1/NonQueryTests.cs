using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using VideosOnDemandEntityDatabase;
using VideoOnDemandProjectDay1;

namespace VideosOnDemandProjectTestsDay1
{
    [TestClass]
    public class NonQueryTests
    {
        [TestMethod]
        public void Test_CreatesAUsernameWithSubscription_SavesToDatabase()
        {
            //arrange
            var mockSet = new Mock<DbSet<username>>();
            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.usernames).Returns(mockSet.Object);

            //act
            var repo = new UsernameRepository(mockContext.Object);
            repo.AddUser("abel.ghebrezadik", "paid");

            //assert
            mockSet.Verify(a => a.Add(It.IsAny<username>()), Times.Once);
            mockContext.Verify(a => a.SaveChanges());
        }

        [TestMethod]
        public void Test_CreatesAUsernameWithoutSubscription_SavesToDatabase()
        {
            //arrange
            var mockSet = new Mock<DbSet<username>>();
            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.usernames).Returns(mockSet.Object);

            //act
            var repo = new UsernameRepository(mockContext.Object);
            repo.AddUser("abel.ghebrezadik", "unpaid");

            //assert
            mockSet.Verify(a => a.Add(It.IsAny<username>()), Times.Once);
            mockContext.Verify(a => a.SaveChanges());
        }

        [TestMethod]
        public void Test_AddFilmToTheDatabase_SavesToDatabase()
        {
            //arrange
            var mockSet = new Mock<DbSet<film>>();
            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.films).Returns(mockSet.Object);


            //act
            var repo = new FilmRepository(mockContext.Object);
            repo.AddFilm("Usual Suspects", 210, Convert.ToDateTime("01-01-2000"));

            //assert
            mockSet.Verify(a => a.Add(It.IsAny<film>()), Times.Once);
            mockContext.Verify(a => a.SaveChanges());

        }

        [TestMethod]
        public void Test_AddTVShowToTheDatabase_SavesToDatabase()
        {
            //arrange
            var mockSet = new Mock<DbSet<television>>();
            var mockContext = new Mock<videosOnDemandEntities>();
            mockContext.Setup(a => a.televisions).Returns(mockSet.Object);


            //act
            var repo = new TelevisionRepository(mockContext.Object);
            repo.AddTVShow("Luther", 4, 45, 60, Convert.ToDateTime("01-01-2010"));

            //assert
            mockSet.Verify(a => a.Add(It.IsAny<television>()), Times.Once);
            mockContext.Verify(a => a.SaveChanges());

        }
    }
}

