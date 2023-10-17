using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }  // In a real-world scenario, you'll need to hash and salt this.

        public string Email { get; set; }

        public DateTime DateJoined { get; set; }

        // Navigation properties
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<RSVP> RSVPs { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
