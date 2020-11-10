using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using WebApplication7.Model;


namespace WebApplication7.Data
{
    public class CloudAdultService : IAdultService
    {
        private string uri = "https://localhost:5003";
        private string uri1 = "http://dnp.metamate.me/";
        private readonly HttpClient client;
        public CloudAdultService() {
            client = new HttpClient();
        }
        public async Task<IList<Adult>> getAdultsAsync()
        {
            string message = await client.GetStringAsync($"{uri}/adult");
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultSerialized = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(
                adultSerialized,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync($"{uri}/adult", content);
            Console.WriteLine(response.ToString());
            
        }

        public async Task RemoveAdultAsync(int adultID)
        {
            await client.DeleteAsync($"{uri}/adult/{adultID}");
        }
    }
}