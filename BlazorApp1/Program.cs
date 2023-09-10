using BlazorApp1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


// by default Created by Create builder
// Top 
/*
1 - Chained Configuration (Default settings, Built-in)
2 - appsettings.json
3 - appsettings.<environment>.json (Development,Production,Staging)
4 - App Secrets (secrets.json) - only in Development mode
5 - Environment Variables
6 - Command Line Arguments

*/

// Azure Key Vault 
// Safely stores encrypted values for your configuration and you can use this to override previous setting in production 
// ^^ 
// || 



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
