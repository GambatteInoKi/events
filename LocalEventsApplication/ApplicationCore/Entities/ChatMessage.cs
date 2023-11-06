using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }
        public virtual User Receiver { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }  // This can be nullable if you want to allow messages not linked to specific events.
        public virtual Event Event { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateSent { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;  // To track if the message has been read by the receiver
    }
}
