using System;
using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;

namespace EventDb
{
    public class SessionInfoBL
    {
        private readonly ISessionInfoRepo<SessionInfo> _sessionRepo;

        public SessionInfoBL(ISessionInfoRepo<SessionInfo> sessionRepo)
        {
            this._sessionRepo = sessionRepo;
        }

        public List<SessionInfo> GetAllSessions()
        {
            return _sessionRepo.GetAllSessions();
        }

        public SessionInfo GetSessionById(int sessionId)
        {
            if (sessionId <= 0)
                throw new ArgumentException("Invalid Session ID");

            var session = _sessionRepo.GetSessionById(sessionId);
            if (session == null)
                throw new InvalidOperationException("Session not found.");

            return session;
        }

        public SessionInfo AddSession(SessionInfo session)
        {
            ValidateSession(session);
            return _sessionRepo.AddSession(session);
        }

        public SessionInfo UpdateSession(SessionInfo session)
        {
            if (session.SessionId <= 0)
                throw new ArgumentException("Session ID must be valid.");

            ValidateSession(session);

            var updated = _sessionRepo.UpdateSession(session);
            if (updated == null)
                throw new InvalidOperationException("Session not found to update.");

            return updated;
        }

        public SessionInfo DeleteSession(int sessionId)
        {
            if (sessionId <= 0)
                throw new ArgumentException("Invalid Session ID");

            var deleted = _sessionRepo.DeleteSession(sessionId);
            if (deleted == null)
                throw new InvalidOperationException("Session not found for deletion.");

            return deleted;
        }

        private void ValidateSession(SessionInfo session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (string.IsNullOrWhiteSpace(session.SessionTitle))
                throw new ArgumentException("Session title is required.");
            if (string.IsNullOrWhiteSpace(session.Description))
                throw new ArgumentException("Session description is required.");
            if (session.EventId <= 0)
                throw new ArgumentException("Valid Event ID is required.");
            // SpeakerId can be optional, so not validated strictly
        }
    }
}
