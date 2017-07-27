using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
//        public  Movie Movie{ get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public int  Id { get; set; }
        public string Name { get; set; }

        public int GenreId { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public  int NumberInStock{ get; set; }


        public string Title
        {
            get { return Id == 0 ?   "New Movie" : "Edit Movie" ; } 
        }


//        public MovieFormViewModel()
//        {
//            Id = 0;
//        }


        public MovieFormViewModel( Movie movie )
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }

        public MovieFormViewModel()
        {
           
        }
    }
}