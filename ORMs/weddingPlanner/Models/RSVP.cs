using System;
namespace weddingPlanner.Models
{
    public class RSVP : BaseEntity
    {
        public int RSVPId {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public int WeddingId {get;set;}
        public Wedding Wedding {get;set;}
        public RSVP()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}