using CleanArq.Application.External.Roma;
using CleanArq.Domain.Models.Roma;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.External.Roma
{
    public class RomaService : IRomaService
    {
        private readonly IConfiguration configuration;

        public RomaService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<Category>> Execute(int buil)
        {
            List<Category> listCategories = new List<Category>();
            string token = "1q2w3e4r5t";
            string apiUrl = $"http://appromacoreapi2.azurewebsites.net/api/Categories/GetCategories?build={buil}";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            { 
                var jsonData = await response.Content.ReadAsStringAsync();

                listCategories = JsonConvert.DeserializeObject<List<Category>>(jsonData) ?? listCategories;
            }

            return listCategories;
        }
    }
}
