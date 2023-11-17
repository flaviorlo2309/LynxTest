using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using FutebolAPI.Configuration;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Infraestructure.Map;
using Infraestructure.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service;
using Service.Interface;
using System;
using System.Configuration;
using System.Text;
using TemplateEntity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<App_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CnnDb")));
builder.Services.AddDependencyInjectionConfig();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddMvc(options =>
{
    options.AllowEmptyInputInBodyModelBinding = true;
    foreach (var formatter in options.InputFormatters)
    {
        if (formatter.GetType() == typeof(SystemTextJsonInputFormatter))
            ((SystemTextJsonInputFormatter)formatter).SupportedMediaTypes.Add(
            Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/plain"));
    }
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddAuthorization();



builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();


builder.Services.AddCors( options =>
{
    options.AddPolicy("PolicyCors", app => 
    {
        app.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//FluentMapper.Initialize(config =>
//{
//    config.AddMap(new UsuarioMap());
//    config.ForDommel();
//});
app.UseAuthentication();

app.UseCors("PolicyCors");

app.UseAuthorization();

IConfiguration configuration = app.Configuration;

IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
});

app.Run();



