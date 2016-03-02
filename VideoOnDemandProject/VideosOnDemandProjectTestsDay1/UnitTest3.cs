using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoOnDemandProjectDay1;
using System.Collections.Generic;

namespace VideosOnDemandProjectTestsDay1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void Test_StreamAVideoToPlay_FromMediaLibraryOrDatabase_WhenUserRequests()
        {
            //Arrange
            MediaPlayer mediaPlayer = new MediaPlayer();
            List<Video> videoToPlay = new List<Video>();
            
            //Act
            List<Video> playerList = mediaPlayer.PlayVideo();

            //Arrange
            CollectionAssert.AreEqual(videoToPlay, playerList);

        }

    }
}
