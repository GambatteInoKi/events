using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VenueName { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
