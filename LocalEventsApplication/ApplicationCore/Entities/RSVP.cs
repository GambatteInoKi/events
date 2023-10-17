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
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Event")]
        public int EventID { get; set; }

        public virtual Event Event { get; set; }

        [Required]
        public string RSVPStatus { get; set; }  // Can be an enum
    }
}
