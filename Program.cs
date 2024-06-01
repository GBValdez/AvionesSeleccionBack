using System.Text.Json.Serialization;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.seats;
using AvionesBackNet.Modules.Vuelos;
using AvionesBackNet.utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddTransient<seatSvc>();

builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AvionesContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse(
        builder.Configuration.GetConnectionString("mySqlVersion")
    ));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(autoMapperProfiles));
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(name: "myCors", builder =>
        {
            builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
    }
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("myCors");

app.UseAuthorization();

app.MapControllers();

app.MapHub<seatSelectionHub>("/selectSeatHub");

app.Run();
