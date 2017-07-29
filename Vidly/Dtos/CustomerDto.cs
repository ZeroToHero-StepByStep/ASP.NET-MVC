using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
//remove all the MVC ations in Dto , Min18YearsIfAMember has a casting method 
//to Customer which can get an error
//        [Required(ErrorMessage = "Please enter customer's name")]
//        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

//        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

//        [Required(ErrorMessage = "Please choose a membership type")]
        public byte MembershipTypeId { get; set; }
    }
}