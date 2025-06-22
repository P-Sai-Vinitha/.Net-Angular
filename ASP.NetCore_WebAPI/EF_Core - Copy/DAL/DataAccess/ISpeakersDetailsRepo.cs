using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface ISpeakersDetailsRepo<T>
    {
        List<T> GetAllSpeakersDetails();
        T GetSpeakersDetailsById(int id);
        T AddSpeakersDetails(T speaker);
        T UpdateSpeakersDetails(T speaker);
        T DeleteSpeakersDetails(int id);
    }
}
