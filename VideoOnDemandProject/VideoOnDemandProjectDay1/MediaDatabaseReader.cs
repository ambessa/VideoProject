using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoOnDemandProjectDay1
{
    public class MediaDatabaseReader
    {
        List<Video> _video = new List<Video>();

        public virtual List<Video> ReadMedia()
        {
            return _video;
        }
    }
}
