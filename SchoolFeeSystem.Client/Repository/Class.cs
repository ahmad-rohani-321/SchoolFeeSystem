using SchoolFeeSystem.Shared;
using System.Net.Http.Json;

namespace SchoolFeeSystem.Client.Repository
{
    public class Class : IClass
    {
        private readonly HttpClient _client;
        private readonly string _mainEndPoint = "api/class";
        public Class(HttpClient client)
        {
            _client = client;
        }
        public async Task<Response<Entities.Class>> AddClass(Entities.Class clas)
        {
            var request = await _client.PostAsJsonAsync(_mainEndPoint, clas);
            return await request.Content.ReadFromJsonAsync<Response<Entities.Class>>();
        }

        public async Task<List<Entities.Class>> GetClasses()
        {
            var content = await _client.GetFromJsonAsync<List<Entities.Class>>(_mainEndPoint);
            return content;
        }

        public async Task<Entities.Class> GetSingleClass(int id)
        {
            var request = await _client.GetFromJsonAsync<Entities.Class>($"{_mainEndPoint}/{id}");
            return request;
        }

        public async Task<Response<Entities.Class>> UpdateClass(Entities.Class clas)
        {
            var request = await _client.PutAsJsonAsync(_mainEndPoint, clas);
            return await request.Content.ReadFromJsonAsync<Response<Entities.Class>>();
        }
    }
}
