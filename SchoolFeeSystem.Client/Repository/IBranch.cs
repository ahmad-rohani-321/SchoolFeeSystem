using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Client.Repository
{
    public interface IBranch
    {
        Task<Response<Entities.Branch>> AddBranch(Entities.Branch branch);
        Task<Response<Entities.Branch>> UpdateBranch(Entities.Branch branch);
        Task<List<Entities.Branch>> GetAllBranches();
        Task<Entities.Branch> GetSingleBranch(int id);

    }
}
