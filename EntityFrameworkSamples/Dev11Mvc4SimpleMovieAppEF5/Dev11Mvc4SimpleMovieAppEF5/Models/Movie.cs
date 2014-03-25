using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dev11Mvc4SimpleMovieAppEF5.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("name=Movies")
        // C# will call base class parameterless constructor by default
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}