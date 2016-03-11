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

        public television AddTVShow(string title, int numSeasons, int numeEpisodes, int length, DateTime releaseDate)
        {
            var TVShow = _context.televisions.Add(new television() { name = title, number_of_seasons= numSeasons, number_of_episodes = numeEpisodes ,length_minute = length, release_date = releaseDate });

            _context.SaveChanges();

            return TVShow;
        }

        public List<television> GetAllTelevisionShows()
        {
            var query = (from t in _context.televisions

                         select t);
            return query.ToList();
        }

        public void RemoveTVShow(string title)
        {
            var TVShows = _context.televisions.Where(a => a.name == title);

            foreach (television TVShow in TVShows)
            {
                _context.televisions.Remove(TVShow);
            }

            _context.SaveChanges();
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
