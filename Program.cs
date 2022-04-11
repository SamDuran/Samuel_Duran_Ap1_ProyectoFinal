using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Blazored.Toast;
using BLL;
using Dal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


/* Contexto */
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConStr"))
);
/* Blazored Toast */
builder.Services.AddBlazoredToast();
/* BLLs */
builder.Services.AddTransient<TransportistasBLL>();
builder.Services.AddTransient<MaterialesBLL>();
builder.Services.AddTransient<EntradasBLL>();
builder.Services.AddTransient<AlmacenBLL>();
builder.Services.AddTransient<SalidasBLL>();


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
