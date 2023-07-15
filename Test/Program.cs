using Microsoft.EntityFrameworkCore;
using Test.Configurations;
using Test.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlite(builder.Configuration["ConnectionString"]);
});

builder.Services.AddDbContext<ReadOnlyContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlite(builder.Configuration["ConnectionString"]);
});
builder.Services.SetupInfrastructureDependencyInjection();
builder.Services.SetupBusinessDependencyInjection();
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
