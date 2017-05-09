using System.Net.Http;
using System.Net.Http.Headers;

namespace DeployTests
{
    public class StatusClient
    {
        private HttpClient _client;
        private string _baseUrl;

        private string GetUrl(string relativeUrl) => $"{_baseUrl}{relativeUrl}";

        public StatusClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void CheckStatus()
        {
            var response = _client.GetAsync(GetUrl("/api/status")).Result;
            response.EnsureSuccessStatusCode();
        }
    }
}