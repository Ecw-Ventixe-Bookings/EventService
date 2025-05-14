using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Services;
using WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("eventServiceConnection") ?? throw new NullReferenceException("Connectionstring for EventService was not found");

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDataContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IEventService, EventService>();

var app = builder.Build();

app.MapOpenApi();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
