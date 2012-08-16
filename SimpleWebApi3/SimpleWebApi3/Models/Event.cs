using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi3.Models
{

    public enum EventGenre
    {
        Meal,
        Movie,
        Other
    }

    public enum EventStatus
    {
        Proposed,
        Approved,
        Scheduled,
        Canceled,
        Completed
    }

    public class Event
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public int EventRecordId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProposedByUserId { get; set; }
        public double Duration { get; set; } // in hours
        public string TentativeDate { get; set; }
        public string Venue { get; set; }
        //public List<User> Participants { get; set; }
        public EventGenre Genre { get; set; }
        public int NumberOfYes { get; set; }
        public int NumberOfNo { get; set; }
        public int Cost { get; set; }
        public EventStatus Status { get; set; }

        // Navigation property
        //public EventRecord EventRecord { get; set; }
    }
}
