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


        public List<film> GetAllFilms()
        {
            var query = (from f in _context.films

                        select f);
            return query.ToList();
        }


    }
}
