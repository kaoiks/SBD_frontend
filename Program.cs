using BlazorApp1.Data;
using BlazorApp1.Services;
using Blazored.Toast;
using BlazorTable;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using BS.Forms.ValidatorComponent.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<VehicleService>();
builder.Services.AddSingleton<ContractorService>();
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<InvoiceService>();
builder.Services.AddSingleton<InsuranceService>();
builder.Services.AddSingleton<RepairService>();
builder.Services.AddSingleton<RepairCostService>();
builder.Services.AddSingleton<DriverService>();
builder.Services.AddSingleton<RouteService>();
builder.Services.AddSingleton<SettlementService>();
builder.Services.AddSingleton<CustomValidator>();

builder.Services.AddBlazorTable();
builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
