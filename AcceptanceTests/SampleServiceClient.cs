﻿using System;
using System.Collections.Generic;
using System.Net;
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

        public NoteModel GetNote(int id) => Get<NoteModel>($"/api/notes/{id}");

        public int AddNote(NoteModel note)
        {
            var json = JsonConvert.SerializeObject(note);
            var response = _client.PostAsync(GetUrl("/api/notes"), new StringContent(json, Encoding.UTF8, "application/json")).Result;
            response.EnsureSuccessStatusCode();
            return Int32.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public void DeleteNote(int id)
        {
            var response = _client.DeleteAsync(GetUrl($"/api/notes/{id}")).Result;
            response.EnsureSuccessStatusCode();
        }

        public void Reset()
        {
            _client.DeleteAsync(GetUrl("/api/testing")).Result.EnsureSuccessStatusCode();
        }

        private T Get<T>(string path)
        {
            var response = _client.GetAsync(GetUrl(path)).Result;
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return default(T);
            }

            response.EnsureSuccessStatusCode();

            var json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public class NoteModel
    {
        public int? Id { get; set; }

        public string Content { get; set; }
    }
}