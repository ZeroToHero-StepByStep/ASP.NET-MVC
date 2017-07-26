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
        public  Movie Movie{ get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title
        {
            get { return Movie == null ?   "New Movie" : "Edit Movie" ; } 
        }
    }
}