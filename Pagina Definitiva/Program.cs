using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pagina_Definitiva.Data;
using Pagina_Definitiva.Pages;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Pagina_DefinitivaContextConnection") ?? throw new InvalidOperationException("Connection string 'Pagina_DefinitivaContextConnection' not found.");

builder.Services.AddDbContext<Pagina_DefinitivaContext>(options =>
    options.UseSqlite(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Pagina_DefinitivaContext>();;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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
app.UseAuthentication();;

app.Run();
