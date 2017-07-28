using System;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //this two approaches are overriding default conventions but with some disadvantages
        [Required(ErrorMessage ="Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
        //MembershipType is called a naviation property becuase it allows us 
        //to navigate  from one type to another. In this case : Custoemr->Membershiptype
      
        public MembershipType MembershipType { get; set; }
        //sometime for optimization , we don't want to load the entire Membershiptype of the object 
        //we may only need a foreign key so we can add another property here : MembershpTypeId 
        //EF can recognise this convention and tread this as a foreign key.
        [Required(ErrorMessage = "Please choose a membership type")]
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }


       

       
    }
}