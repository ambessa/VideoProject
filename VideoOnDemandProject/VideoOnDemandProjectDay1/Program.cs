using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using VideosOnDemandEntityDatabase;

[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace VideoOnDemandProjectDay1
{
    public class Program
    {
        private static readonly ILog logger = LogManager.GetLogger("program.cs");

        static void Main(string[] args)
        {
            //try
            //{
            //    int number1 = 10;
            //    int number2 = 0;
            //    int result = number1 / number2;
            //}
            //catch (DivideByZeroException nfex)
            //{
            //    logger.Error(nfex.Message);
            //    Console.WriteLine("Error");
            //}

            using(var context = new videosOnDemandEntities())
            {
               foreach(var actor in context.actors)
               {
                   Console.WriteLine(actor.first_name);
               }
            }
      

        }

    }
}
