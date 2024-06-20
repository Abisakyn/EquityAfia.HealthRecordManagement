using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.MappingProfile;
using EquityAfia.HealthRecordManagement.Contracts.Events.UserExist;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure MassTransit with RabbitMQ and Kafka
builder.Services.AddMassTransit(x =>
{
    
    x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));

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

// Register MediatR
builder.Services.AddMediatR(typeof(LabResultsUploadCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(HealthRecordsCommandHandler).Assembly);

// Register AutoMapper
//builder.Services.AddAutoMapper(typeof(LabResultsUploadCommandHandler));
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register handlers for commands
builder.Services.AddTransient<IRequestHandler<LabResultsUploadCommand, LabResultsResponse>, LabResultsUploadCommandHandler>();
builder.Services.AddTransient<IRequestHandler<HealthRecordsCommand, HealthRecordsResponse>, HealthRecordsCommandHandler>();

// Register FluentValidation if needed
// builder.Services.AddValidatorsFromAssemblyContaining<LabResultsUploadCommandValidator>();

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
