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
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public int EventID { get; set; }

        public Event Event { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
