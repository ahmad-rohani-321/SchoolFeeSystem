using MudBlazor;
using SchoolFeeSystem.Client.Entities;
using SchoolFeeSystem.Shared;
using static MudBlazor.Colors;
namespace SchoolFeeSystem.Client.Repository;
public interface IStudents
{
    Task<IList<Student>> GetTenStudents();
    Task<Response<Student>> AddStudent(Student student);
    Task<Response<Student>> UpdateStudent(Student student, int id);
    Task<bool> InActiveStudent(int id, bool active);
    /// <summary>
    /// Search types summery 
    /// 0">آیډی
    /// 1" > نوم 
    /// 2">د پلار نوم
    /// 3"> د نیکه نوم
    /// 4"> موبایل 
    /// 5"> تذکره 
    /// 6"> اساس نمبر
    /// 7"> ولدینو موبایل شمېره
    /// </summary>
    Task<IList<Student>> SearchStudent(string keywords, int type);
    Task<Response<Student>> GetStudent(int id);
    
}
