using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleApplication_API.Data;
using SampleApplication_API.Mapping;
using SampleApplication_API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SampleDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SampleConnection")));
//Inject constructor injection
builder.Services.AddScoped<IRegion,RegionRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiler));
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
