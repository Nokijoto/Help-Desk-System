using Microsoft.EntityFrameworkCore;
using ServiceDesk.Assets.API.Extensions;
using ServiceDesk.Assets.API.Profiles;
using ServiceDesk.Assets.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AssetsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AssetsProfile).Assembly);

builder.Services.AddCustomServices();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    using (var dbContext = scope.ServiceProvider.GetRequiredService<AssetsDbContext>())
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();
