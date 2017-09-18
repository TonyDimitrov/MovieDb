namespace MovieDb.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MovieDbContext : DbContext
    {

        public MovieDbContext()
            : base("MovieDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }

}