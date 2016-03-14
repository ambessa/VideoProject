using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VideosOnDemandEntityDatabase;

namespace VideoOnDemandProjectDay1
{
    public class FilmRepository
    {
        private videosOnDemandEntities _context;

        public FilmRepository(videosOnDemandEntities context)
        {
            _context = context;
            
        }

        public void AddFilm(string title, int length, DateTime releaseDate)
        {
            var Film = _context.films.Add(new film() { name = title, length_minute = length, release_date = releaseDate });

            _context.SaveChanges();

        }
        
        public List<film> GetAllFilms()
        {
            var query = (from f in _context.films

                        select f);
            return query.ToList();
        }

        public void RemoveFilm(string title)
        {
            var Films = _context.films.Where(a=>a.name == title);

            foreach(film Film in Films)
            {
                _context.films.Remove(Film);
            }

            _context.SaveChanges();
        }

    }
}
