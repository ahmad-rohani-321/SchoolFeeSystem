using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SchoolFeeSystem.Client;
using MudBlazor.Services;
using MudBlazor;
using SchoolFeeSystem.Client.Repository;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IStudents, Students>();
builder.Services.AddScoped<IBranch, Branch>();
builder.Services.AddScoped<IClass, Class>();
builder.Services.AddScoped<IClassStudents, ClassStudents>();
await builder.Build().RunAsync();
