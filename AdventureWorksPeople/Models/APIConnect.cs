using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AdventureWorksPeople.Models
{
    public class APIConnect : IDisposable
    {
        public string Results { get; set; }
        private HttpClient Client = new HttpClient();
        public APIConnect()
        {

        }

        public bool GetDataSync(string url)
        {
            HttpResponseMessage response = Client.GetAsync(new Uri(url)).Result;

            if (response.IsSuccessStatusCode)
            {
                Results=response.Content.ReadAsStringAsync().Result;
                return true;
            }
            return false;
        }

        public async Task<string> GetData(string url)
        {
            //StringContent queryString = new StringContent(data);

            HttpResponseMessage response = await Client.GetAsync(new Uri(url));

            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}