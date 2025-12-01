using CA2_WebAppUsingAPIs.Components;
using CA2_WebAppUsingAPIs.Models;
using CA2_WebAppUsingAPIs.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
//builder.Services.AddScoped<CardmarketService>();
builder.Services.AddScoped<JustTcgService>();

builder.Services.Configure<JustTcgSettings>(builder.Configuration.GetSection("JustTcg"));


builder.Services.AddHttpClient<YgoApiService>(client =>
{
    client.BaseAddress = new Uri("https://db.ygoprodeck.com/");
});

builder.Services.AddHttpClient("JustTCG", client =>
  client.BaseAddress = new Uri("https://api.justtcg.com/v1/"));

builder.Services.AddHttpClient("Cardmarket", client =>
{
    client.BaseAddress = new Uri("https://api.cardmarket.com/ws/v2.0/output.json/"); // Base URL for Cardmarket API v2
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
