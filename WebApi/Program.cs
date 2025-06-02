using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Service.Interfaces;
using Service.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("eventServiceConnection") ?? throw new NullReferenceException("Connectionstring for EventService was not found");
var jwtIssuer = builder.Configuration["JWT:Issuer"] ?? throw new NullReferenceException("JWT Issuer is not present");
var jwtAudience = builder.Configuration["JWT:Audience"] ?? throw new NullReferenceException("JWT Audience is not present");
var jwtKeyBase64 = builder.Configuration["JWT:PublicKey"] ?? throw new NullReferenceException("JWT Public key is not present");

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SqlServerDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IVenueRepository, VenueRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        RSA rsa = RSA.Create();
        byte[] publicKeyBytes = Convert.FromBase64String(jwtKeyBase64);
        rsa.ImportRSAPublicKey(publicKeyBytes, out _);

        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            IssuerSigningKey = new RsaSecurityKey(rsa)
        };
    });

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference("/api/docs");

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
