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
        public void QueryGetAllFilms_FromTheDatabase_ReturnAListOfOneFilm()
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
            var controller = new FilmController(mockContext.Object);
            var listOfFilms = controller.GetAllFilms();

            //Assert
            Assert.AreEqual(1, listOfFilms.Count);
        }
    }
}
