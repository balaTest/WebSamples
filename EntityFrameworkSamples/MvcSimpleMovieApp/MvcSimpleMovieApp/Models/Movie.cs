﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcSimpleMovieApp.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }

    public class MovieContext : DbContext
    {
        public MovieContext() : base ("name=MoviesContext")
        // C# will call base class parameterless constructor by default
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}