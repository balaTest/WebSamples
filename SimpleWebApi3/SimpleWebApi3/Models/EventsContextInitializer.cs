using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleWebApi3.Models
{
    public class EventsContextInitializer : DropCreateDatabaseAlways<EventsContext>
    {
        protected override void Seed(EventsContext context)
        {
            var users = new List<User>()            
            {
                new User() { Name = "Bala" },
                new User() { Name = "Pranav" },
                new User() { Name = "John" },
                new User() { Name = "Suhas" }

            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var teamEvent1 = new EventRecord();
            var eventDetails = new List<Event>()
            {
                //new Event() { Name="Lunch at Five Guys", Description="Lunch before the movie", Duration = 1, EventRecord = teamEvent1  },
                //new Event() { Name="Batman Movie", Description="AAPT movie event", Duration=4, EventRecord = teamEvent1}

                new Event() { Name="Lunch at Five Guys", Description="Lunch before the movie", Duration = 1},
                new Event() { Name="Batman Movie", Description="AAPT movie event", Duration=4}

            };

            context.EventRecords.Add(teamEvent1);            
            eventDetails.ForEach(ed => context.Events.Add(ed));
            teamEvent1.Events = eventDetails;

            context.SaveChanges();
           
        }

    }

}