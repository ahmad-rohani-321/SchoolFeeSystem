using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SchoolFeeSystem.Client;
using MudBlazor.Services;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IStudents, Students>();
await builder.Build().RunAsync();

MudTheme FontTest = new MudTheme()
{
    Palette = new PaletteLight()
    {
        Background = "#FFFFFF"
    },
    PaletteDark = new PaletteDark()
    {
        Background = "#000000"
    },
    Typography = new Typography
    {
        Default = new Default()
        {
            FontFamily = new[] { "Bahij-nassim-regular" },
            //FontSize = "1.25rem",
            //FontWeight = 500,
            //LineHeight = 1.6,
            //LetterSpacing = ".0075em"
        }
    }
};