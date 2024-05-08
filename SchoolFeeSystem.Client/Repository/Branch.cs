using SchoolFeeSystem.Client.Entities;
using SchoolFeeSystem.Shared;
using System.Net.Http.Json;

namespace SchoolFeeSystem.Client.Repository
{
    public class Branch : IBranch
    {
        private readonly HttpClient _client;
        private readonly string _mainEndPoint = "api/branch";
        public Branch(HttpClient client)
        {
            _client = client;
        }

        public async Task<Response<Entities.Branch>> AddBranch(Entities.Branch branch)
        {
            var request = await _client.PostAsJsonAsync(_mainEndPoint, branch);
            return await request.Content.ReadFromJsonAsync<Response<Entities.Branch>>();
        }

        public async Task<List<Entities.Branch>> GetAllBranches()
        {
            return await _client.GetFromJsonAsync<List<Entities.Branch>>(_mainEndPoint);
        }

        public async Task<Entities.Branch> GetSingleBranch(int id)
        {
            return await _client.GetFromJsonAsync<Entities.Branch>($"{_mainEndPoint}/{id}");
        }

        public async Task<Response<Entities.Branch>> UpdateBranch(Entities.Branch branch)
        {
            var request = await _client.PutAsJsonAsync(_mainEndPoint, branch);
            return await request.Content.ReadFromJsonAsync<Response<Entities.Branch>>();
        }
    }
}
