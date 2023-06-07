using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tournament.API.Application.Contract.Participants;
using Tournament.API.Application.Contract.Tournaments;
using Tournament.API.Application.Participants;
using Tournament.API.Application.Tournaments;
using Tournament.API.Domain.Participants;
using Tournament.API.Domain.Tournaments;
using Tournament.API.EntityFrameworkCore;
using Tournament.API.EntityFrameworkCore.Participants;
using Tournament.API.EntityFrameworkCore.Tournaments;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(
      "CorsPolicy",
      builder => builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});

// Add builder.Services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddSwaggerDocument(settings =>
{
    settings.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Tournament API";
        document.Info.Description = "";
    };
});

builder.Services.AddDbContext<TournamentAPIDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<ITournamentManager, TournamentManager>();
builder.Services.AddScoped<IParticipantManager, ParticipantManager>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
