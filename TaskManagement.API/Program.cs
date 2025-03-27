using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Infrastructure.Repositories;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Services;
using TaskManagement.Worker;

using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")  // Specify frontend URL
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Add Hangfire
builder.Services.AddHangfire(config =>
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHangfireServer();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register repositories and services
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();

// Add Controllers
builder.Services.AddControllers();

// Add Logging
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// Use CORS policy
app.UseCors("AllowAllOrigins");  // Use before routing

// Use Hangfire Dashboard (Optional, can be restricted in production)
app.UseHangfireDashboard("/hangfire");

// Enable HTTPS Redirection (if needed)
app.UseHttpsRedirection();

// Map Controllers
app.MapControllers();

app.Run();
