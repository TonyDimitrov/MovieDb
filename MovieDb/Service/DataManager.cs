
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

        public ViewMovie GetMovieById(int id) 
        {
            Movie movie = new Movie();
            using (context = new MovieDbContext())
            {
              movie = context.movies.Where(x => x.Id == id).FirstOrDefault();
            }

            return CustomMapper(movie);
        }

        public bool SaveMovieToDb(ViewMovie vMovie)
        {
            bool result = false;
            try
            {
                Movie movie = new Movie()
                {
                    Title = vMovie.Title,
                    DirectorName = vMovie.DirectorName,
                    ReleaseDate = vMovie.ReleaseDate
                };
                using (context = new MovieDbContext())
                {
                    context.movies.Add(movie);
                    context.SaveChanges();
                }
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
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