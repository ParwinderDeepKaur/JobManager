using System;
using System.Net.Http;
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

        public Task<string> PostAsync(string uri, string body, string type)
        {
            throw new NotImplementedException();
        }
    }
}