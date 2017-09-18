using MovieDb.Models;
using MovieDb.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieDb.Controllers
{
    public class HomeController : Controller
    {
        private DataManager manager;
        public HomeController()
        {
            this.manager = new DataManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMovies()
        {
            var movies = this.manager.GetMovies();
            var toJson = Json(movies, JsonRequestBehavior.AllowGet);
            return toJson;
        }

        public JsonResult GetMovie(int id)
        {
            var movie = this.manager.GetMovieById(id);
            var toJson = Json(movie, JsonRequestBehavior.AllowGet);
            return toJson;
        }
        [HttpPost]
        public JsonResult SaveNewMovie(ViewMovie data)
        {
            bool result = manager.SaveMovieToDb(data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void WriteJson(ViewMovie data)
        {
            string filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Error Log", "moviesList.json");
            TextWriter tw = new StreamWriter(filePath);
            tw.Write(data);
        }
    }
}