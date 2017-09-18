
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
                movies = this.context.Movies.ToList().Skip(skiped).OrderByDescending(x => x.Id).Select(x => CustomMapper(x)).ToList();
            }
            return movies;
        }

        public ViewMovie GetMovieById(int id)
        {
            Movie movie = new Movie();
            using (context = new MovieDbContext())
            {
                movie = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            }

            return CustomMapper(movie);
        }

        public bool SaveMovieToDb(ViewMovie vMovie)
        {
            Movie movie;
            bool result = false;
            if (vMovie.Id == 0)
            {
                try
                {
                    movie = new Movie()
                    {
                        Title = vMovie.Title,
                        DirectorName = vMovie.DirectorName,
                        ReleaseDate = vMovie.ReleaseDate
                    };
                    using (context = new MovieDbContext())
                    {
                        context.Movies.Add(movie);
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
            else
            {
                try
                {
                    using (context = new MovieDbContext())
                    {
                        movie = context.Movies.Where(x => x.Id == vMovie.Id).FirstOrDefault();
                        if (movie != null)
                        {
                            movie.Title = vMovie.Title;
                            movie.DirectorName = vMovie.DirectorName;
                            movie.ReleaseDate = vMovie.ReleaseDate;
                            context.SaveChanges();
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
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