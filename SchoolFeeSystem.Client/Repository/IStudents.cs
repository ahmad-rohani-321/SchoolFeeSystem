namespace SchoolFeeSystem.Client;

public interface IStudents
{
    IEnumerable<Student> GetTenStudents();
    Student AddStudent(Student student);
    Student UpdateStudent(Student student);
    void InActiveStudent(int id, bool active);
    
}
