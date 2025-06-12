using System;
using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;

namespace EventDb
{
    public class EventDetailsBL
    {
        private readonly IEventDetailsRepo<EventDetails> _eventRepo;

        public EventDetailsBL(IEventDetailsRepo<EventDetails> eventRepo)
        {
            this._eventRepo = eventRepo;
        }

        public List<EventDetails> GetAllEvents()
        {
            return _eventRepo.GetAllEvents();
        }

        public List<EventDetails> GetEventsByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category must not be empty.");

            return _eventRepo.GetEventsByCategory(category);
        }

        public EventDetails AddEvent(EventDetails eventDetails)
        {
            ValidateEvent(eventDetails);

            var existingEvents = _eventRepo.GetAllEvents();
            bool isDuplicate = existingEvents.Exists(e =>
                e.EventName.Equals(eventDetails.EventName, StringComparison.OrdinalIgnoreCase) &&
                e.EventDate.Date == eventDetails.EventDate.Date);

            if (isDuplicate)
                throw new InvalidOperationException("An event with the same name and date already exists.");

            return _eventRepo.AddEvent(eventDetails);
        }

        public EventDetails UpdateEvent(EventDetails eventDetails)
        {
            if (eventDetails.EventId <= 0)
                throw new ArgumentException("Valid EventId is required for update.");

            ValidateEvent(eventDetails);

            var updated = _eventRepo.UpdateEvent(eventDetails);
            if (updated == null)
                throw new InvalidOperationException("Event not found to update.");

            return updated;
        }

        public EventDetails DeleteEvent(int eventId)
        {
            if (eventId <= 0)
                throw new ArgumentException("Invalid Event ID.");

            var deleted = _eventRepo.DeleteEvent(eventId);
            if (deleted == null)
                throw new InvalidOperationException("Event not found for deletion.");

            return deleted;
        }

        private void ValidateEvent(EventDetails e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            if (string.IsNullOrWhiteSpace(e.EventName))
                throw new ArgumentException("Event name is required.");
            if (string.IsNullOrWhiteSpace(e.EventCategory))
                throw new ArgumentException("Event category is required.");
            if (e.EventDate == default)
                throw new ArgumentException("Valid event date is required.");
            if (string.IsNullOrWhiteSpace(e.Description))
                throw new ArgumentException("Event description is required.");
            if (string.IsNullOrWhiteSpace(e.Status))
                throw new ArgumentException("Event status is required.");
        }
    }
}
