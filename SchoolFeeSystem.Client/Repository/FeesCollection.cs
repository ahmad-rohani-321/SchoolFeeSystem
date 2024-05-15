using SchoolFeeSystem.Shared;
using System.Net.Http.Json;

namespace SchoolFeeSystem.Client.Repository
{
    public class FeesCollection(HttpClient client) : IFeesCollection
    {
        private readonly HttpClient _client = client;
        private readonly string _url = @"api/feescollection";

        #region Monthly fees collection
        public async Task<List<Entities.FeesCollection>> GetByClassForMonthlyFees(int classId)
        {
            return await _client.GetFromJsonAsync<List<Entities.FeesCollection>>($"{_url}/monthlyfees/{classId}");
        }
        public async Task<Response<List<Entities.FeesCollection>>> UpdateMonthlyFees(List<Entities.FeesCollection> fees)
        {
            var request = await _client.PutAsJsonAsync($"{_url}/monthlyfees", fees);
            return await request.Content.ReadFromJsonAsync<Response<List<Entities.FeesCollection>>>();
        }
        #endregion

        #region Month transport fees collection
        // transportfee
        public async Task<Response<List<Entities.TransportFeesCollection>>> UpdateMonthlyTransportFees(List<Entities.TransportFeesCollection> fees)
        {
            var request = await _client.PutAsJsonAsync($"{_url}/monthlyfees", fees);
            return await request.Content.ReadFromJsonAsync<Response<List<Entities.TransportFeesCollection>>>();
        }
        public async Task<List<Entities.TransportFeesCollection>> GetByClassForMonthlyTransportFees(int classId)
        {
            return await _client.GetFromJsonAsync<List<Entities.TransportFeesCollection>>($"{_url}/monthlyfees/{classId}");
        }
        #endregion

        #region Activity Fees Collection
        // activityfee
        public async Task<List<Entities.ActivityFeesCollection>> GetByClassForActivityFees(int classId)
        {
            return await _client.GetFromJsonAsync<List<Entities.ActivityFeesCollection>>($"{_url}/monthlyfees/{classId}");
        }

        public async Task<Response<List<Entities.ActivityFeesCollection>>> UpdateActivityFees(List<Entities.ActivityFeesCollection> fees)
        {
            var request = await _client.PutAsJsonAsync($"{_url}/monthlyfees", fees);
            return await request.Content.ReadFromJsonAsync<Response<List<Entities.ActivityFeesCollection>>>();
        }
        #endregion

    }
}