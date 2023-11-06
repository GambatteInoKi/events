using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class RSVP
    {

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }



        [Required]
        public string RSVPStatus { get; set; }  // Can be an enum
        
        public virtual User User { get; set; }       
        public virtual Event Event { get; set; }

    }
}
