using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.seats;
using AvionesBackNet.Modules.Vuelos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using project.roles;
using project.users;
using project.utils.autoMapper;
using project.utils.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<seatSvc>();
builder.Services.AddScoped<interceptorDb>();
builder.Services.AddScoped<emailService>();

builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AvionesContext>((serviceProvider, options) =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse(
        builder.Configuration.GetConnectionString("mySqlVersion")
    )).AddInterceptors(
        serviceProvider.GetRequiredService<interceptorDb>()
    );
});

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                option => option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["keyJwt"])
                    ),
                    ClockSkew = TimeSpan.Zero
                }
            );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
                {
                    c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header
                    }
                    );
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                        {
                            new OpenApiSecurityScheme{
                                Reference= new OpenApiReference{
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                            },
                            new string[]{}
                        }

                    });
                }
            );
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddIdentity<userEntity, rolEntity>()
                .AddEntityFrameworkStores<AvionesContext>()
                .AddDefaultTokenProviders();
builder.Services.AddDataProtection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("myCors");
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapHub<seatSelectionHub>("/selectSeatHub");

app.Run();
