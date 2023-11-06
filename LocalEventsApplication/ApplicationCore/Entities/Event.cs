using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        [ForeignKey("User")]
        public int OrganizerId { get; set; }

        public virtual User Organizer { get; set; }

        // Navigation properties
        public virtual ICollection<RSVP> RSVPs { get; set; }
        public virtual ICollection<Feedback> Reviews { get; set; }
    }
}
