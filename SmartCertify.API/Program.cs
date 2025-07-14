using Microsoft.EntityFrameworkCore;
using SmartCertify.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register DbContext with connection string from configuration
builder.Services.AddDbContext<SmartCertifyContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbContext"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
