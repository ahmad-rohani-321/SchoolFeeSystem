
using SchoolFeeSystem.Shared;
using System.Net.Http.Json;

namespace SchoolFeeSystem.Client.Repository
{
    public class ClassStudents : IClassStudents
    {
        private readonly HttpClient _client;
        private readonly string _mainEndPoint = "api/classstudents";
        public ClassStudents(HttpClient client)
        {
            _client = client;
        }

        public async Task<Response<string>> AddStudent(HashSet<Entities.ClassStudents> students)
        {
            var request = await _client.PostAsJsonAsync(_mainEndPoint, students);
            return await request.Content.ReadFromJsonAsync<Response<string>>();
        }

        public async Task<List<Entities.ClassStudents>> GetClassStduents(int? classId)
        {
            return await _client.GetFromJsonAsync<List<Entities.ClassStudents>>($"{_mainEndPoint}/{classId}");
        }

        public async Task<Entities.ClassStudents> GetClassSingleStudent(int? classStudentId)
        {
            return await _client.GetFromJsonAsync<Entities.ClassStudents>($"{_mainEndPoint}/single/{classStudentId}");
        }

        public async Task<List<Entities.ClassStudents>> GetStudentsForAdd(int classId)
        {
            var content = await _client.GetFromJsonAsync<List<Entities.ClassStudents>>($"{_mainEndPoint}/add/{classId}");
            return content;
        }

        public async Task<Response<Entities.ClassStudents>> UpdateStudentFees(int? id, int? feeAmount)
        {
            var request = await _client.PutAsJsonAsync($"{_mainEndPoint}/{id}/{feeAmount}", feeAmount);
            return await request.Content.ReadFromJsonAsync<Response<Entities.ClassStudents>>();
        }

        public async Task<Response<Entities.ClassStudents>> DeleteStudents(List<Entities.ClassStudents> students)
        {
            var request = await _client.PostAsJsonAsync($"{_mainEndPoint}/add", students);
            return await request.Content.ReadFromJsonAsync<Response<Entities.ClassStudents>>();
        }
    }
}
