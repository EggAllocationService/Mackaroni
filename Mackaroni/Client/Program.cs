using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Mackaroni.Client;
using Mackaroni.Client.Impl;
using Mackaroni.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Mackaroni.ServerAPI",
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Mackaroni.ServerAPI"));
builder.Services.AddSingleton<ITimeOffsetProvider, JavascriptTimeOffsetProvider>();
builder.Services.AddScoped<ICommentThreadProvider, HttpCommentProvider>();
builder.Services.AddSingleton<ISideDetector, BlazorSideProvider>();
await builder.Build().RunAsync();