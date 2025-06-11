using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IUserInfoRepo<T>
    {
        T GetUserByEmail(string emailId);
        T UpdateUser(T user);
        T AddUser(T user);
        T DeleteUser(string emailId);
        List<T> GetAllUsers();
    }
}