using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoOnDemandProjectDay1;
using System.Collections.Generic;
using Moq;

namespace VideosOnDemandProjectTestsDay1
{
    [TestClass]
    public class MediaPlayerTests
    {
        [TestMethod]
        public void Test_PlayVideo_FromMediaLibrary_WhenVideoHasBeenSearched()
        {
            //Arrange
            MediaLibrary mediaLibrary = new MediaLibrary(new MediaDatabaseReader()); ;
            MediaPlayer mediaPlayer = new MediaPlayer(mediaLibrary);
            
            //Act
            List<Video> playerList = mediaPlayer.PlayVideo();

            //Arrange
            Assert.AreEqual(0, playerList.Count);

        }

        [TestMethod]
        public void Test_PlayVideo_FromMediaLibraryOrDatabase()
        {
            //Arrange
            Mock<MediaDatabaseReader> mediaDatabaseReader = new Mock<MediaDatabaseReader>();
            MediaLibrary mediaLibrary = new MediaLibrary(mediaDatabaseReader.Object);
            MediaPlayer mediaPlayer = new MediaPlayer(mediaLibrary);

            //Act
            List<Video> playerList = mediaPlayer.PlayVideo();

            //Arrange
            mediaDatabaseReader.Verify(a => a.ReadMedia());

        }

        [TestMethod]
        public void Test_PlayVideo_FromMediaLibraryOrDatabase_ReturnsAVideo()
        {
            //Arrange
            Mock<MediaDatabaseReader> mediaDatabaseReader = new Mock<MediaDatabaseReader>();
            MediaLibrary mediaLibrary = new MediaLibrary(mediaDatabaseReader.Object);
            MediaPlayer mediaPlayer = new MediaPlayer(mediaLibrary);
            List<Video> videoToPlay = new List<Video>();
            mediaDatabaseReader.Setup(a => a.ReadMedia()).Returns(videoToPlay);
            //Act
            List<Video> playerList = mediaPlayer.PlayVideo();

            //Arrange
            Assert.AreEqual(videoToPlay, playerList);

        }
    }
}
