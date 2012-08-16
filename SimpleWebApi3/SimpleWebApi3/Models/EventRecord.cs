using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi3.Models
{
    public class EventRecord
    {
        public int EventRecordId { get; set; }
        public int UserId { get; set; }
        public bool? Vote { get; set; }

        // Navigation property
        public ICollection<Event> Events { get; set; }
    }
}
