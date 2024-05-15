using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Client.Repository
{
    public interface IFeesCollection
    {
        #region Monthly fees collection
        Task<List<Entities.FeesCollection>> GetByClassForMonthlyFees(int classId);
        Task<Response<List<Entities.FeesCollection>>> UpdateMonthlyFees(List<Entities.FeesCollection> fees);
        #endregion

        #region Monthly transport fees collection
        Task<List<Entities.TransportFeesCollection>> GetByClassForMonthlyTransportFees(int classId);
        Task<Response<List<Entities.TransportFeesCollection>>> UpdateMonthlyTransportFees(List<Entities.TransportFeesCollection> fees);
        #endregion

        #region activity fees collection
        Task<List<Entities.ActivityFeesCollection>> GetByClassForActivityFees(int classId);
        Task<Response<List<Entities.ActivityFeesCollection>>> UpdateActivityFees(List<Entities.ActivityFeesCollection> fees);
        #endregion
    }
}
