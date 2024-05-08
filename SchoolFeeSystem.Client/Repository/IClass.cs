using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Client.Repository
{
    public interface IClass
    {
        Task<List<Entities.Class>> GetClasses();
        Task<Entities.Class> GetSingleClass(int id);
        Task<Response<Entities.Class>> AddClass(Entities.Class clas);
        Task<Response<Entities.Class>> UpdateClass(Entities.Class clas);
    }
}
