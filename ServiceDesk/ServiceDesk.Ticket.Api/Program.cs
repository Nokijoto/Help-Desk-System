using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using ServiceDesk.Ticket.Api;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.Api.Services;
using ServiceDesk.Ticket.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Ustawienia dla enumów
    c.MapType<StatusTicket>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetNames(typeof(StatusTicket)).Select(name => new OpenApiString(name) as IOpenApiAny).ToList()
    });

    c.MapType<PriorityTicket>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetNames(typeof(PriorityTicket)).Select(name => new OpenApiString(name) as IOpenApiAny).ToList()
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TicketDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),sqlOptions => sqlOptions.MigrationsAssembly("ServiceDesk.Ticket.Storage")));
builder.Services.AddAutoMapper(typeof(TicketMappingProfile).Assembly);
builder.Services.AddScoped<Seeder>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
