using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface IParticipantEventDetailsRepo<T>
    {
        T AddParticipantEvent(T participant);
        T UpdateParticipantEvent(T participant);
        T DeleteParticipantEvent(int id);
        T GetParticipantEventById(int id);
        List<T> GetAllParticipantEvents();
    }
}
