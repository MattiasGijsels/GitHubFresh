using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Labo.API.Wasm.Client.Services;
using Labo.API.Wasm.Shared;

namespace Labo.API.Wasm.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped(s => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IManagerService, BookClientService>();

            await builder.Build().RunAsync();
        }
    }
}
