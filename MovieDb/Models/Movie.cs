
using MovieDb.Service;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDb.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}