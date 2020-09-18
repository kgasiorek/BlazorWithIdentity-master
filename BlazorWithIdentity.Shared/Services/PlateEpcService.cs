using BlazorWithIdentity.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace BlazorWithIdentity.Shared.Services
{
    public class PlateEpcService
    {
        static HttpClient client = new HttpClient();

        public PlateEpcService()
        {
            client.BaseAddress = new Uri("http://localhost:53414/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> CreatePlateEpcAsync(PlateEpcRequest plan)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/platesepc", plan);
            response.EnsureSuccessStatusCode();

            return response.StatusCode.ToString();
        }

        public async Task<IEnumerable<PlateEpc>> GetPlateEpcAsync()
        {
            var result = await client.GetJsonAsync<IEnumerable<PlateEpc>>("api/platesepc");
            return result;
            //HttpResponseMessage response = await client.GetAsync("api/platesepc");
        }

        public async Task<string> DeletePlateEpcAsync(PlateEpc plateEpc)
        {
            int id = plateEpc.Id;
            var url = "api/platesepc/" + id.ToString(); 
            HttpResponseMessage response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            return response.StatusCode.ToString();
        }

    }
}