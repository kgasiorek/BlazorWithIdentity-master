using BlazorWithIdentity.Shared.Models;

namespace BlazorWithIdentity.Shared.Services
{
    public class PlanSingleResponse : BaseAPIResponse
    {
        public Plan Record { get; set; }
    }
}
