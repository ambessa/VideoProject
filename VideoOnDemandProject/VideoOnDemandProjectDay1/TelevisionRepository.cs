using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideosOnDemandEntityDatabase;

namespace VideoOnDemandProjectDay1
{
    public class TelevisionRepository
    {
        private videosOnDemandEntities _context;

        public TelevisionRepository(videosOnDemandEntities context)
        {
            _context = context;
        }

        public List<television> GetAllTelevisionShows()
        {
            var query = (from t in _context.televisions

                         select t);
            return query.ToList();
        }


        //public void SearchTelevisionsShowWithGenreHorror()
        //{
        //    //_context = new videosOnDemandEntities();

        //    var query = (from t in _context.televisions
        //                      join g in _context.genres on t.fk_genre_id equals g.id
        //                      select new televisionGenre { name = t.name, number_of_seasons = t.number_of_seasons, number_of_episodes = t.number_of_episodes, length_minute=t.length_minute, release_date = t.release_date, genre = g.name }
        //}
    }
}
