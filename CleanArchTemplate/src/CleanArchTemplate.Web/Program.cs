﻿// <copyright file="Program.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.ListStartupServices;
using Autofac.Core;
using CleanArchTemplate.Core;
using CleanArchTemplate.Infrastructure;
using CleanArchTemplate.Infrastructure.Data;
using CleanArchTemplate.Infrastructure.Identity;
using CleanArchTemplate.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

string connectionString = builder.Configuration.GetConnectionString("SqliteConnection");  //Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext(connectionString);
builder.Services.AddIdentityDbContext(connectionString);

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
});

// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
    config.Services = new List<ServiceDescriptor>(builder.Services);

    // optional - default path to view services is /listallservices - recommended to choose your own path
    config.Path = "/listservices";
});

builder.Services.AddDefaultCoreDependencies();
builder.Services.AddDefaultInfrastructureDependencies(builder.Environment.EnvironmentName == "Development");

//builder.Logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseShowAllServicesMiddleware();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

// Seed Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        //                    context.Database.Migrate();
        context.Database.EnsureCreated();
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
}

app.Run();
