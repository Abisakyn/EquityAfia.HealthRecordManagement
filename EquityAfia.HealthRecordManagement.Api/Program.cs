using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.MappingProfile;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.DownloadLabResults;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.PressureMap;
using EquityAfia.HealthRecordManagement.Contracts.Events.UserExist;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.DownloadLabResultsDTOs;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.PressureMapDTOs;
using EquityAfia.HealthRecordManagement.Infrastructure.Repositories;
using FluentValidation;
using MassTransit;
using MassTransit.KafkaIntegration;
using MediatR;
using MedicalRecords.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure MassTransit with Kafka (commented out for now)
/*
builder.Services.AddMassTransit(x =>
{
    // Kafka configuration
    x.AddRider(rider =>
    {
        // Register Kafka consumers and producers
        rider.AddConsumer<UserExistConsumer>();
        rider.AddProducer<UserExistEvent>(nameof(UserExistEvent));

        // Configure Kafka host and topic endpoints
        rider.UsingKafka((context, k) =>
        {
            k.Host("localhost:9092");
            k.TopicEndpoint<UserExistEvent>("UserExists", "consumer-group-id", e =>
            {
                e.ConfigureConsumer<UserExistConsumer>(context);
            });
        });
    });
});
builder.Services.AddMassTransitHostedService();
*/

// Register MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register command handlers for MediatR
builder.Services.AddTransient<IRequestHandler<LabResultsUploadCommand, LabResultsResponse>, LabResultsUploadCommandHandler>();
builder.Services.AddTransient<IRequestHandler<HealthRecordsCommand, HealthRecordsResponse>, HealthRecordsCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DownloadLabResultsQuery, DownloadLabResultsResponse>, DownloadLabResultsQueryHandler>();
builder.Services.AddTransient<IRequestHandler<PressureMapQuery, PressureMapResponse>, PressureMapQueryHandler>();
// Register FluentValidation validators if needed
// builder.Services.AddValidatorsFromAssemblyContaining<LabResultsUploadCommandValidator>();

// Register repositories
builder.Services.AddScoped<ILabResultsRepository, LabResultsRepository>();
builder.Services.AddScoped<IHealthRecordsRepository, HealthRecordsRepositories>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
