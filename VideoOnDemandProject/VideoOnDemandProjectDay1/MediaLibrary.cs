using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoOnDemandProjectDay1
{
    public class MediaLibrary
    {
        MediaDatabaseReader _mediaDB;

        public MediaLibrary(MediaDatabaseReader mediaDB)
        {
            _mediaDB = mediaDB;
        }

        public List<Video> VideoSearch()
        {

            return _mediaDB.ReadMedia();
        }

    }
}
