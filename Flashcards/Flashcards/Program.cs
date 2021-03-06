global using Flashcards.Models;
global using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --- Umo?liwienie dost?pu z ka?dej domeny 1/2
builder.Services.AddCors(c => {
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// --- Serializacja za pomoc? JSON
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(
        options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()
    );

// --- Po??czenie z baz? danych
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseMySql( builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion( new Version(8, 0, 11 ) ) );
});

// --- Dodanie obs?ugi sesji 1/2
builder.Services.AddSession();

// --- Pod??czenie repozytori?w
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IFlashcardRepository, FlashcardRepository>();
builder.Services.AddScoped<ILinkRepository, LinkRepository>();
builder.Services.AddScoped<ICollectionUserRepository, CollectionUserRepository>();
builder.Services.AddScoped<IFlashcardUserRepository, FlashcardUserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

// --- Umo?liwienie dost?pu z ka?dej domeny 2/2
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// --- Dodanie obs?ugi sesji 2/2
app.UseSession();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();