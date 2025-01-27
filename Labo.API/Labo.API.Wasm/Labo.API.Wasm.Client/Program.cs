using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Labo.API.Wasm.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            await builder.Build().RunAsync();
        }
    }
}
