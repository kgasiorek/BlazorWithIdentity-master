using BlazorWithIdentity.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BlazorWithIdentity.Shared.Services
{
    public class PlansService
    {
        static HttpClient client = new HttpClient();

        public PlansService()
        {
            client.BaseAddress = new Uri("http://localhost:53414/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> CreateProductAsync(PlanRequest plan)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/plans", plan);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.StatusCode.ToString();
        }

        //public async Task<string> GetAllWeekPlansAsync()
        //{
        //    await Http.GetJsonAsync<IEnumerable<Plan>>("api/TrucsPlan");
        //}
    }
}
