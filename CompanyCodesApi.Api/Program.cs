using CompanyCodesApi.Infrastructure.Context;
using CompanyCodesApi.Infrastructure.Repositories;
using CompanyCodesApi.Application.Services;
using CompanyCodesApi.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using AutoMapper;
using CompanyCodesApi.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
builder.Services.AddScoped<ICodeRepository, CodeRepository>();

builder.Services.AddScoped<EnterpriseService>();
builder.Services.AddScoped<CodeService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
