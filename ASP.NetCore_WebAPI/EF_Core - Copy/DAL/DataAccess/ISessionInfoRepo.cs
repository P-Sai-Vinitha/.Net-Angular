using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface ISessionInfoRepo<T>
    {
        T GetSessionById(int sessionId);
        T UpdateSession(T sessionInfo);
        T AddSession(T sessionInfo);
        T DeleteSession(int sessionId);
        List<T> GetAllSessions();

    }
}