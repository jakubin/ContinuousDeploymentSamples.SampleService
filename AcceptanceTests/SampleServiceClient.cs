using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace AcceptanceTests
{
    public class SampleServiceClient
    {
        private HttpClient _client;
        private string _baseUrl;

        private string GetUrl(string relativeUrl) => $"{_baseUrl}{relativeUrl}";

        public SampleServiceClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<NoteModel> GetAllNotes() => Get<List<NoteModel>>("/api/notes");

        public void AddNote(NoteModel note)
        {
            var json = JsonConvert.SerializeObject(note);
            var response = _client.PostAsync(GetUrl("/api/notes"), new StringContent(json, Encoding.UTF8, "application/json")).Result;
            response.EnsureSuccessStatusCode();
        }

        public void Reset()
        {
            _client.DeleteAsync(GetUrl("/api/testing")).Result.EnsureSuccessStatusCode();
        }

        private T Get<T>(string path)
        {
            var json = _client.GetStringAsync(GetUrl(path)).Result;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public class NoteModel
    {
        public int? Id { get; set; }

        public string Content { get; set; }
    }
}