using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Feedback
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int AuthorId { get; set; }

        public User User { get; set; }

        [ForeignKey("Event")]
        public int EventFeedbackId { get; set; }

        public Event Event { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
