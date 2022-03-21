﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JobManager.Droid.Services;
using JobManager.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebClientService))]
namespace JobManager.Droid.Services
{
    public class WebClientService : IWebClientService
    {
        public async Task<string> GetAsync(string uri)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(uri);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> PostAsync(string uri, string body, string type)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();

                var content = new StringContent(body.ToString(), Encoding.UTF8, type);

                HttpResponseMessage response = await client.PostAsync(uri, content);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> PutAsync(string uri, string body, string type)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();

                var content = new StringContent(body.ToString(), Encoding.UTF8, type);

                HttpResponseMessage response = await client.PutAsync(uri, content);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> DeleteAsync(string uri)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();

                HttpResponseMessage response = await client.DeleteAsync(uri);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch
            {
                return null;
            }
        }
    }
}