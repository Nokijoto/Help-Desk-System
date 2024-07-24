using EmailNotification;
using EmailNotification.Models;
using EmailNotification.Services;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();

// Configure Serilog
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            AutoCreateSqlTable = false,
            TableName = "EmailLogs"
        },
        restrictedToMinimumLevel: LogEventLevel.Information
    )
    .CreateLogger();

// Add the logger to the services
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddSingleton(logger);

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
