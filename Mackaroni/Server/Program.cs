using Mackaroni.Server.Hubs;
using Mackaroni.Server.Impl;
using Mackaroni.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ITimeOffsetProvider>(new DummyTimeOffsetProvider());
builder.Services.AddSingleton<CommentProvider>();
builder.Services.AddSingleton<ICommentThreadProvider, FreeCommentThreadProvider>();
builder.Services.AddSingleton<ISideDetector, ServerSideProvider>();
builder.Services.AddHttpClient();
builder.Services.AddSignalR();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapHub<CommentNotificationHub>("/api/commentNotifications");
app.MapControllers();

app.Run();