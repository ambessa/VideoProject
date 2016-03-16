using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoOnDemandProjectDay1;
using VideosOnDemandEntityDatabase;

namespace WcfVideoService
{

    public class VideoService : IVideoService
    {
        TelevisionRepository teleRepo;
        FilmRepository filmRepo;
        

        public VideoService()
        {
            teleRepo = new TelevisionRepository(new videosOnDemandEntities());
            filmRepo = new FilmRepository(new videosOnDemandEntities());
        }

        public void AddTVService(string title, int noSeasons, int noEpisodes, int minute, DateTime release)
        {
            teleRepo.AddTVShow(title, noSeasons, noEpisodes, minute, release);
        }


        public List<film> GetFilms()
        {
            return filmRepo.GetAllFilms();
        }

    }      
}
