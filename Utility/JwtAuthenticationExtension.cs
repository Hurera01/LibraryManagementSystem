using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LibraryManagementSystem.Utility
{
    public static class JwtAuthenticationExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "LibrarySystem";
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "LibraryUsers";

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new Exception("JWT_SECRET environment variable is not set.");
            }

            var key = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // Ensures token expires at exact time
                };

                // Custom Unauthorized & Expired Token Response
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        if (!context.Response.HasStarted) // ✅ Prevent error
                        {
                            context.HandleResponse(); // Prevent default response
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";

                            var result = new
                            {
                                error = "Unauthorized",
                                message = "You are not authorized to access this resource."
                            };

                            await context.Response.WriteAsJsonAsync(result);
                        }
                    },
                    OnAuthenticationFailed = async context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            var response = context.Response;
                            if (!response.HasStarted) // ✅ Prevent error
                            {
                                context.Response.Clear(); // ✅ Clear any partial response
                                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                context.Response.ContentType = "application/json";

                                response.Headers.Append("Access-Control-Allow-Origin", "*");
                                response.Headers.Append("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                                response.Headers.Append("Access-Control-Allow-Headers", "Authorization, Content-Type");

                                var result = new
                                {
                                    error = "Token Expired",
                                    message = "Your session has expired. Please log in again."
                                };

                                await context.Response.WriteAsJsonAsync(result);
                            }
                        }
                    }
                };
            });

            return services;
        }
    }
}
