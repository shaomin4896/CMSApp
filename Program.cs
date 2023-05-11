using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CaseManagementApp;
using CaseManagementApp.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient(new AddHeadersDelegatingHandler())
{
    BaseAddress = new Uri(builder.Configuration.GetValue<string>("apiHost") ?? "")
});

builder.Services.AddSingleton<LoginState>();
builder.Services.AddAntDesign();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CaseService>();

// Static DI Provider
ServiceLocator.SetLocatorProvider(builder.Services.BuildServiceProvider());



await builder.Build().RunAsync();