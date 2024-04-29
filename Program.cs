using BlazorApp.Components;
using BlazorApp.Data;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
var config = configuration.Build();

builder.Services.AddBlazorise().AddFontAwesomeIcons().AddBootstrapProviders();
builder.Services.AddBlazorBootstrap();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<ListsContext>(options => 
options.UseNpgsql(config.GetConnectionString("DbString")));

builder.Services.AddScoped<IDataAccessProvider, DataAccessProvider>();
builder.Services.AddBlazoredLocalStorage();

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

app.MapControllers();

app.Run();
