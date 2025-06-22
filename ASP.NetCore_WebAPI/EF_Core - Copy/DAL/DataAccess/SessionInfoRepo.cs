using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class SessionInfoRepo : ISessionInfoRepo<SessionInfo>
    {
        public SessionInfo AddSession(SessionInfo sessionInfo)
        {
            using (var dbContext = new EventDbContext())
            {
                dbContext.Sessions.Add(sessionInfo);
                dbContext.SaveChanges();
                return sessionInfo;
            }
        }

        public SessionInfo DeleteSession(int sessionId)
        {
            using (var dbContext = new EventDbContext())
            {
                var session = dbContext.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
                if (session != null)
                {
                    dbContext.Sessions.Remove(session);
                    dbContext.SaveChanges();
                    return session;
                }
                return null;
            }
        }

        public List<SessionInfo> GetAllSessions()
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Sessions.ToList();
            }
        }

        public SessionInfo GetSessionById(int sessionId)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
            }
        }

        public SessionInfo UpdateSession(SessionInfo sessionInfo)
        {
            using (var dbContext = new EventDbContext())
            {
                var existingSession = dbContext.Sessions.FirstOrDefault(s => s.SessionId == sessionInfo.SessionId);
                if (existingSession != null)
                {
                    existingSession.SessionTitle = sessionInfo.SessionTitle;
                    existingSession.Description = sessionInfo.Description;
                    existingSession.SpeakerId = sessionInfo.SpeakerId;
                    existingSession.SessionStart = sessionInfo.SessionStart;
                    existingSession.SessionEnd = sessionInfo.SessionEnd;
                    existingSession.SessionUrl = sessionInfo.SessionUrl;

                    dbContext.SaveChanges();
                    return existingSession;
                }
                return null;
            }
        }
    }
}
