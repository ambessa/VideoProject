using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VideosOnDemandEntityDatabase;
using WcfVideoService;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {

            EndpointAddress endpoint = new EndpointAddress("http://TRNLON11603:8081/VideoService");
            
            IVideoService proxy = ChannelFactory<IVideoService>.CreateChannel(new BasicHttpBinding(), endpoint);

            List<film> films = proxy.GetFilms();
            

            foreach (var film in films)
            {
                Console.WriteLine(film.name);
            }

            Console.Read();
            
        }
    }
}
