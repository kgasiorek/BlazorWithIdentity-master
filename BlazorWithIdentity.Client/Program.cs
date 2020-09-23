using BlazorWithIdentity.Client.Services.Contracts;
using BlazorWithIdentity.Client.Services.Implementations;
using BlazorWithIdentity.Client.States;
using BlazorWithIdentity.Shared;
using BlazorWithIdentity.Shared.Services;
using AWSC.SharedFramework.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BlazorWithIdentity.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<IdentityAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthorizeApi, AuthorizeApi>();
            builder.RootComponents.Add<App>("app");
            builder.Services.AddDevExpressBlazor();

            builder.Services.AddScoped<PlansService>(s =>
            {
                return new PlansService();
            });

            builder.Services.AddScoped<PlateEpcService>(s =>
            {
                return new PlateEpcService();
            });

            builder.Services.AddScoped<OperationTypeService>(s =>
            {
                return new OperationTypeService();
            });

            builder.Services.AddScoped<ServiceModus>(s =>
            {
                return new ServiceModus();
            });

            var host = builder.Build();
            await host.RunAsync();
        }
    }
}
