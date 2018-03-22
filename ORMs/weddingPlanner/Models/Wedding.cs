using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace weddingPlanner.Models
{
    public class Wedding : BaseEntity
    {

        public int WeddingId { get; set; }

        public int UserId { get; set; }
        [Required(ErrorMessage="Wedder One required!")]
        public string WedderOne { get; set; }
        [Required(ErrorMessage="Wedder Two required!")]
        public string WedderTwo { get; set; }

        [Required(ErrorMessage="Date required!")]
    
        public DateTime? Date { get; set; }

        [Required(ErrorMessage="Address required!")]
        public string Address { get; set; }

        public List<RSVP> RSVPS { get; set; }
        public Wedding()
        {
            RSVPS = new List<RSVP>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date < DateTime.Now)
            {
                yield return new ValidationResult(
                    "Date must be in the future!"
                    );
            }
        }
    }





}