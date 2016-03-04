using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VideosOnDemandEntityDatabase;

namespace VideoOnDemandProjectDay1
{
    public class FilmController
    {
        private videosOnDemandEntities _context;

        public FilmController(videosOnDemandEntities context)
        {
            _context = context;
        }

        public film AddFilm(string name, int length, DateTime date, int id)
        {
            var Film = _context.films.Add(new film { name = name, length_minute = length, release_date = date, fk_genre_id = id });
            _context.SaveChanges();
            return Film;
        }

        public List<film> GetAllFilms()
        {
            var query = (from f in _context.films

                        select f);
            return query.ToList();
        }

         
    }
}
