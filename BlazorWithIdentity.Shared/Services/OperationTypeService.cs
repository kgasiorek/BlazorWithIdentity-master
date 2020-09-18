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
    public class OperationTypeService
    {
        static HttpClient client = new HttpClient();

        public OperationTypeService()
        {
            client.BaseAddress = new Uri("http://localhost:53414/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<OperationTypeRequest>> GetOperationType()
        {
            var result = await client.GetJsonAsync<IEnumerable<OperationTypeRequest>>("api/operationtype");
            return result;
            //HttpResponseMessage response = await client.GetAsync("api/platesepc");
        }
    }
}