using SchoolFeeSystem.Client.Entities;
using SchoolFeeSystem.Shared;
using System.Net.Http.Json;

namespace SchoolFeeSystem.Client.Repository;
public class Students : IStudents
{
    private readonly HttpClient _httpClient;
    public Students(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Student>> AddStudent(Student student)
    {
        var request = await _httpClient.PostAsJsonAsync("api/student", student);
        var result = await request.Content.ReadFromJsonAsync<Response<Student>>();
        return result;
    }

    public async Task<Response<Student>> GetStudent(int? id)
    {
        return await _httpClient.GetFromJsonAsync<Response<Student>>($"api/student/{id}");
    }

    public async Task<IList<Student>> GetTenStudents()
    {
        return await _httpClient.GetFromJsonAsync<List<Student>>("api/student");
    }

    public async Task<bool> InActiveStudent(int id, bool active)
    {
        HttpResponseMessage request = await _httpClient.PutAsJsonAsync($"api/student/{id}/{active}", active);
        return await request.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<Student>> SearchStudent(string keywords, int type)
    {
        return await _httpClient.GetFromJsonAsync<List<Student>>($"api/student/{type}/{keywords}");
    }

    public async Task<Response<Student>> UpdateStudent(Student student, int id)
    {
        var request = await _httpClient.PutAsJsonAsync($"api/student/{id}", student);
        return await request.Content.ReadFromJsonAsync<Response<Student>>();
    }
}
