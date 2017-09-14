
namespace MovieDb.Models
{
    using MovieDb.Service;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ViewMovie
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(100)]
        public string DirectorName { get; set; }
        [DateValidator]
        public DateTime ReleaseDate { get; set; }
    }
}