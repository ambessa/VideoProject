using AspNetVidOnDemand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoOnDemandProjectDay1;
using VideosOnDemandEntityDatabase;


namespace AspNetVidOnDemand.Controllers
{
    public class VideoController : Controller
    {
        FilmRepository filmRepo;

        public static List<film> films = new List<film>();

        // GET: Video
        public ActionResult Index()
        {
            if(Request.IsAjaxRequest())
            {
                return ShowFilms();
            }


            films = filmRepo.GetAllFilms();

            return View();
        }

        private ActionResult ShowFilms()
        {
            return PartialView("_FilmDetails", films[0]);
        }


        public VideoController()
        {
            filmRepo = new FilmRepository(new videosOnDemandEntities());
        }
    }
}