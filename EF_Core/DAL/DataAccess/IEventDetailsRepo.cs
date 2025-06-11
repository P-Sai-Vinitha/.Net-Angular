using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IEventDetailsRepo<T>
    {
        List<T> GetEventsByCategory(string category);
        T UpdateEvent(T eventDetails);
        T AddEvent(T eventDetails);
        T DeleteEvent(int eventId);
        List<T> GetAllEvents();

    }
}