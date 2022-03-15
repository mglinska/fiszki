global using Flashcards.Models;
global using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --- Umo¿liwienie dostêpu z ka¿dej domeny 1/2
builder.Services.AddCors(c => {
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// --- Serializacja za pomoc¹ JSON
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(
        options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()
    );

// --- Po³¹czenie z baz¹ danych
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseMySql( builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion( new Version(8, 0, 11 ) ) );
});

// --- Pod³¹czenie repozytoriów
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

// --- Umo¿liwienie dostêpu z ka¿dej domeny 2/2
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();