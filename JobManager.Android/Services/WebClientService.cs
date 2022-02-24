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
        public async Task<string> GetString(string uri)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(uri);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch
            {
                return null;
            }
        }
    }
}