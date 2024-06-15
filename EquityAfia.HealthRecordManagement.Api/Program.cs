using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
using EquityAfia.HealthRecordManagement.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using MedicalRecords.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MediatR
builder.Services.AddMediatR(typeof(LabResultsUploadCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(HealthRecordsCommandHandler).Assembly);

builder.Services.AddAutoMapper(typeof(LabResultsUploadCommandHandler));

builder.Services.AddTransient<IRequestHandler<LabResultsUploadCommand ,Response>, LabResultsUploadCommandHandler>();
builder.Services.AddTransient<IRequestHandler<HealthRecordsCommand, Response>, HealthRecordsCommandHandler>();
// Register FluentValidation
//builder.Services.AddValidatorsFromAssemblyContaining<LabResultsUploadCommandValidator>();

// Register custom repository
builder.Services.AddScoped<ILabResultsRepository, LabResultsRepository>();
builder.Services.AddScoped<IHealthRecordsRepository, HealthRecordsRepositories>();

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
