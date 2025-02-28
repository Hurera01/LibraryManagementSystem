using LibraryManagementSystem.Data;
using LibraryManagementSystem.Helper;
using LibraryManagementSystem.Service.Implementation;
using LibraryManagementSystem.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  // Allow any origin
            .AllowAnyHeader()  // Allow any header
            .AllowAnyMethod(); // Allow any HTTP method
    });
});

// Add services to the container
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register custom services and repositories
builder.Services.RegisterServices();
builder.Services.AddScoped<JwtService>();
builder.Services.RegisterRepositories();

// Configure JWT Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// Add Authorization and other necessary services
builder.Services.AddAuthorization();
builder.Services.AddMemoryCache();

// Add Redis Cache Service
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

// Configure Swagger to accept JWT tokens
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer {your token}' to authenticate"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Use CORS middleware before other middleware
app.UseCors("AllowAllOrigins"); // Apply CORS policy

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI only in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Add Authentication Middleware
app.UseAuthorization();  // Add Authorization Middleware

// Custom Middleware (optional)
app.UseMiddleware<ForbiddenResponseMiddleware>();

app.MapControllers(); // Map Controllers

app.Run(); // Run the application
