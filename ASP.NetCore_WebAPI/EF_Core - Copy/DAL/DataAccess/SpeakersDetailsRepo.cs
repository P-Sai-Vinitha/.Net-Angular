using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class SpeakersDetailsRepo : ISpeakersDetailsRepo<SpeakersDetails>
    {
        public List<SpeakersDetails> GetAllSpeakersDetails()
        {
            using (var db = new EventDbContext())
            {
                return db.Set<SpeakersDetails>().ToList();
            }
        }

        public SpeakersDetails GetSpeakersDetailsById(int id)
        {
            using (var db = new EventDbContext())
            {
                return db.Set<SpeakersDetails>().FirstOrDefault(s => s.SpeakerId == id);
            }
        }

        public SpeakersDetails AddSpeakersDetails(SpeakersDetails speaker)
        {
            using (var db = new EventDbContext())
            {
                db.Speakers.Add(speaker);
                db.SaveChanges();
                return speaker;
            }
        }

        public SpeakersDetails UpdateSpeakersDetails(SpeakersDetails speaker)
        {
            using (var db = new EventDbContext())
            {
                var existing = db.Speakers.FirstOrDefault(s => s.SpeakerId == speaker.SpeakerId);
                if (existing != null)
                {
                    existing.SpeakerName = speaker.SpeakerName;
                    db.SaveChanges();
                    return existing;
                }
                return null;
            }
        }

        public SpeakersDetails DeleteSpeakersDetails(int id)
        {
            using (var db = new EventDbContext())
            {
                var speaker = db.Speakers.FirstOrDefault(s => s.SpeakerId == id);
                if (speaker != null)
                {
                    db.Speakers.Remove(speaker);
                    db.SaveChanges();
                    return speaker;
                }
                return null;
            }
        }
    }
}
