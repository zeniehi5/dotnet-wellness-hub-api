using dotnet_wellness_hub_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Configure YouTube API Client
var youtubeApiKey = builder.Configuration["YouTube:ApiKey"];

builder.Services.AddSingleton<YouTubeApiClient>(sp => 
{
    if (string.IsNullOrEmpty(youtubeApiKey))
    {
        throw new InvalidOperationException("YouTube API Key is not configured.");
    }
    
    return new YouTubeApiClient(youtubeApiKey);
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.MapGet("/", () => "Welcome to the Dotnet Wellness Hub API!");

app.Run();
