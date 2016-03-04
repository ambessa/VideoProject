using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoOnDemandProjectDay1;
using System.Collections.Generic;
using Moq;

namespace VideosOnDemandProjectTestsDay1
{
    [TestClass]
    public class MediaLibraryTests
    {
        [TestMethod]
        public void Test_SearchForVideo_TheMediaLibraryIsChecked_ReturnsSearchResult()
        {
            //Arrange
            MediaLibrary mediaLibrary = new MediaLibrary(new MediaDatabaseReader());

            //Act
            List<Video> myVideo = mediaLibrary.VideoSearch();

            //Assert
            Assert.AreEqual(0, myVideo.Count);
        }

        [TestMethod]
        public void Test_SearchForVideos_WithinTheMediaLibraryWhichReadsDatabase_WhenTheMediaLibraryIsChecked()
        {
            //Arrange
            Mock<MediaDatabaseReader> mediaDatabaseReader = new Mock<MediaDatabaseReader>();
            MediaLibrary mediaLibrary = new MediaLibrary(mediaDatabaseReader.Object);
            
            //Act
            List<Video> myVideo = mediaLibrary.VideoSearch();

            //Assert
            mediaDatabaseReader.Verify(a => a.ReadMedia());
        }

        [TestMethod]
        public void Test_SearchForVideo_WithinTheMediaLibraryWhichReadsDatabase_ReturnAVideoFromDatabase()
        {
            //Arrange
            Mock<MediaDatabaseReader> mediaDatabaseReader = new Mock<MediaDatabaseReader>();
            MediaLibrary mediaLibrary = new MediaLibrary(mediaDatabaseReader.Object);
            List<Video> databaseVideo = new List<Video>();
            mediaDatabaseReader.Setup(r => r.ReadMedia()).Returns(databaseVideo);
           
            //Act
            List<Video> myVideo = mediaLibrary.VideoSearch();

            //Assert
            Assert.AreSame(databaseVideo, myVideo);
        }
    }
}
