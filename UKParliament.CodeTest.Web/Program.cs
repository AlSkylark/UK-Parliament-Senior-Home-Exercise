using CommissionMe.API.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.Controllers.Api;

app.MapEmployeeEndpoints();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
;

namespace UKParliament.CodeTest.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllersWithViews();

        builder.Services.AddSingleton<CreatedUpdatedInterceptor>();
        builder.Services.AddDbContext<PersonManagerContext>(
            (services, options) =>
                options
                    .UseInMemoryDatabase("PersonManager")
                    .AddInterceptors(services.GetRequiredService<CreatedUpdatedInterceptor>())
        );

        builder.Services.AddScoped<IPersonRepository, PersonRepository>();
        builder.Services.AddScoped<IPersonService, PersonService>();

        var app = builder.Build();

        // Create database so the data seeds
        using (
            var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope()
        )
        {
            using var context =
                serviceScope.ServiceProvider.GetRequiredService<PersonManagerContext>();
            context.Database.EnsureCreated();
            context.SeedDatabase();
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}
