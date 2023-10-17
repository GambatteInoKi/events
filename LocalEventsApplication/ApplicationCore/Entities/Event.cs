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
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [ForeignKey("Venue")]
        public int VenueID { get; set; }

        public virtual Venue Venue { get; set; }

        [ForeignKey("User")]
        public int OrganizerID { get; set; }

        public virtual User Organizer { get; set; }

        // Navigation properties
        public virtual ICollection<RSVP> Attendees { get; set; }
        public virtual ICollection<Feedback> Reviews { get; set; }
    }
}
