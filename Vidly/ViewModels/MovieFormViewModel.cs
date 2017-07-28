using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
//        public  Movie Movie{ get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public int  Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Display(Name="Genre")]
        public int GenreId { get; set; }
       
        public DateTime? ReleaseDate { get; set; }

     
        [Required]
        [Range(1,20)]
        [Display(Name="Number in Stock")]
        public  int NumberInStock{ get; set; }


        public string Title
        {
            get { return Id == 0 ?   "New Movie" : "Edit Movie" ; } 
        }


        //        public MovieFormViewModel()
        //        {
        //            Id = 0;
        //        }


        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
    }
}