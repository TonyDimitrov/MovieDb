
namespace MovieDb.Service
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class DataManager
    {
        private MovieDbContext context;


        public List<ViewMovie> GetMovies(int skiped = 0)
        {
            List<ViewMovie> movies = new List<ViewMovie>();
            using (this.context = new MovieDbContext())
            {
                movies = this.context.movies.ToList().Skip(skiped).Take(3).Select(x => CustomMapper(x)).ToList(); ;
            }
            return movies;
        }

        private ViewMovie CustomMapper(Movie movie)
        {
            ViewMovie Vmovie = new ViewMovie()
            {
                Id = movie.Id,
                Title = movie.Title,
                DirectorName = movie.DirectorName,
                ReleaseDate = movie.ReleaseDate
            };
            return Vmovie;

        }
    }
}