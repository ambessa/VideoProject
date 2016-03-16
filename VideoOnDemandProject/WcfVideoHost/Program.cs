﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfVideoService;

namespace WcfVideoHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(VideoService)))
            {
                string address = "http://" + Dns.GetHostName() + ":8081/VideoService";

                host.AddServiceEndpoint(typeof(IVideoService), new BasicHttpBinding(), address);

                host.Open();

                Console.WriteLine("Press any key to stop");
                Console.Read();

            }
        }
    }
}
