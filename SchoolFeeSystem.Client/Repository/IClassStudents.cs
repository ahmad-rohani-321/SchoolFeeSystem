using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Client.Repository
{
    public interface IClassStudents
    {
        Task<List<Entities.ClassStudents>> GetClassStduents(int? classId);
        Task<Entities.ClassStudents> GetClassSingleStudent(int? classStudentId);
        Task<List<Entities.ClassStudents>> GetStudentsForAdd(int classId);
        Task<Response<Entities.ClassStudents>> UpdateStudentFees(int? id, int? feeAmount);
        Task<Response<string>> AddStudent(HashSet<Entities.ClassStudents> students);
        Task<Response<Entities.ClassStudents>> DeleteStudents(List<Entities.ClassStudents> students);
    }
}
