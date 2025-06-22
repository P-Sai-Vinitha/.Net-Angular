using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class EventDetailsRepo : IEventDetailsRepo<EventDetails>
    {
        public List<EventDetails> GetEventsByCategory(string category)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Events
                    .Where(e => e.EventCategory.Equals(category))
                    .ToList();
            }
        }

        public EventDetails UpdateEvent(EventDetails eventDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                var existingEvent = dbContext.Events
                    .FirstOrDefault(e => e.EventId == eventDetails.EventId);

                if (existingEvent != null)
                {
                    existingEvent.EventName = eventDetails.EventName;
                    existingEvent.EventCategory = eventDetails.EventCategory;
                    existingEvent.EventDate = eventDetails.EventDate;
                    existingEvent.Description = eventDetails.Description;
                    existingEvent.Status = eventDetails.Status;

                    dbContext.SaveChanges();
                    return existingEvent;
                }
                return null;
            }
        }

        public EventDetails AddEvent(EventDetails eventDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                //dbContext.Events.Add(eventDetails);
                //dbContext.SaveChanges();

                //Insertinng Data using Stored Procedure
                var sp = $"EXEC SP_Insert_Event @EventName='{eventDetails.EventName}', @EventCategory='{eventDetails.EventCategory}', @EventDate='{eventDetails.EventDate:yyyy-MM-dd}', @Description='{eventDetails.Description}', @Status='{eventDetails.Status}'";
                dbContext.Database.ExecuteSqlRaw(sp);

                return eventDetails;
            }
        }

        public EventDetails DeleteEvent(int eventId)
        {
            using (var dbContext = new EventDbContext())
            {
                var existingEvent = dbContext.Events
                    .FirstOrDefault(e => e.EventId == eventId);

                if (existingEvent != null)
                {
                    dbContext.Events.Remove(existingEvent);
                    dbContext.SaveChanges();
                    return existingEvent;
                }
                return null;
            }
        }

        public List<EventDetails> GetAllEvents()
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Events.ToList();
            }
        }
        public EventDetails GetEventById(int eventId)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Events.FirstOrDefault(e => e.EventId == eventId);
            }
        }

    }
}
