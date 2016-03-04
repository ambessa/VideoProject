using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoOnDemandProjectDay1
{
    public class MediaPlayer
    {
        MediaLibrary _mediaLibrary;
        List<Video> playList = new List<Video>();

        public MediaPlayer(MediaLibrary mediaLibrary)
        {
            _mediaLibrary = mediaLibrary;
        }


        public List<Video> PlayVideo()
        {
            
            return _mediaLibrary.VideoSearch();
        }

    }
}
