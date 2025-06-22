using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class ParticipantEventDetailsRepo : IParticipantEventDetailsRepo<ParticipantEventDetails>
    {
        public ParticipantEventDetails AddParticipantEvent(ParticipantEventDetails participant)
        {
            using (var db = new EventDbContext())
            {
                db.ParticipantEventDetails.Add(participant);
                db.SaveChanges();
                return participant;
            }
        }

        public ParticipantEventDetails UpdateParticipantEvent(ParticipantEventDetails participant)
        {
            using (var db = new EventDbContext())
            {
                var existing = db.ParticipantEventDetails.FirstOrDefault(p => p.Id == participant.Id);
                if (existing != null)
                {
                    existing.ParticipantEmailId = participant.ParticipantEmailId;
                    existing.EventId = participant.EventId;
                    existing.IsAttended = participant.IsAttended;
                    db.SaveChanges();
                    return existing;
                }
                return null;
            }
        }

        public ParticipantEventDetails DeleteParticipantEvent(int id)
        {
            using (var db = new EventDbContext())
            {
                var existing = db.ParticipantEventDetails.FirstOrDefault(p => p.Id == id);
                if (existing != null)
                {
                    db.ParticipantEventDetails.Remove(existing);
                    db.SaveChanges();
                    return existing;
                }
                return null;
            }
        }

        public ParticipantEventDetails GetParticipantEventById(int id)
        {
            using (var db = new EventDbContext())
            {
                return db.ParticipantEventDetails.FirstOrDefault(p => p.Id == id);
            }
        }

        public List<ParticipantEventDetails> GetAllParticipantEvents()
        {
            using (var db = new EventDbContext())
            {
                return db.ParticipantEventDetails.ToList();
            }
        }
    }
}
