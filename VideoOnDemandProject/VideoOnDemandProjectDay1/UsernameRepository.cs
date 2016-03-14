using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideosOnDemandEntityDatabase;

namespace VideoOnDemandProjectDay1
{
    public class UsernameRepository
    {
        private videosOnDemandEntities _context;

        public UsernameRepository(videosOnDemandEntities context)
        {
            _context = context;
        }

        public void AddUser(string username, string password)
        {
            var Username = _context.usernames.Add(new username() { name = username, pass_word = password });
            _context.SaveChanges();

        }

        public List<username> GetUsernames()
        {
            var query = (from u in _context.usernames

                         select u);
            return query.ToList();
        }

        //public List<username> GetAListOfOneUsernamesSubscribed()
        //{
        //    var query = from u in _context.usernames
        //                where u.subscription == "paid"
        //                select u;
        //    return query.ToList();
        //}

        //public List<username> GetAListOfOneUsernamesNotSubscribed()
        //{
        //    var query = from u in _context.usernames
        //                where u.subscription == "unpaid"
        //                select u;
        //    return query.ToList();
        //}

        public void DeleteUser(string username)
        {

            var Username = _context.usernames.Where(u => u.name == username);
            _context.SaveChanges();

        }

        //public List<username> CheckHoursWatched()
        //{
        //    var query = from u in _context.usernames
        //                where u.hours_watched >= 0
        //                select u;

        //    return query.ToList();
        //}
    }
}
