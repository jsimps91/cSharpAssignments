using System.Collections.Generic;
using System;
namespace weddingPlanner.Models
{
    public class User : BaseEntity
    {
        public int UserId {get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email {get;set;}
        public string Password {get;set;}

        public List<RSVP> RSVPS {get;set;}
        public User()
        {
            RSVPS = new List<RSVP>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}