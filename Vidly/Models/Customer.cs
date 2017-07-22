using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        //MembershipType is called a naviation property becuase it allows us 
        //to navigate  from one type to another. In this case : Custoemr->Membershiptype
        public MembershipType MembershipType { get; set; }
        //sometime for optimization , we don't want to load the entire Membershiptype of the object 
        //we may only need a foreign key so we can add another property here : MembershpTypeId 
        //EF can recognise this convention and tread this as a foreign key.
        public byte MembershipTypeId { get; set; }
    }
}