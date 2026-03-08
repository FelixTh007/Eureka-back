using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Eureka.Data;
using Eureka.Api.Endpoints;
using Eureka.Api.Services.Auth;
using Eureka.Api.Services.Candidates;
using Eureka.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICandidateOnboardingService, CandidateOnboardingService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordHasher<Candidate>, PasswordHasher<Candidate>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAntiforgery();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

var app = builder.Build();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapGet("/", () => "Eureka API is running!");

app.MapActualiteEndpoints();
app.MapCandidateEndpoints();
app.MapAuthEndpoints();

app.Run();
