using Application.DTOs.Auth;
using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlyReadDbContext>(options =>
{
    DbContextOptionsConfigurator.Configure(options, "API");
}, ServiceLifetime.Scoped);

builder.Services.AddDbContext<OnlyWriteDbContext>(options =>
{
    DbContextOptionsConfigurator.Configure(options, "API");
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICryptoService, CryptoService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAutoMapper(typeof(BaseMapping<RegistrarRequest,Usuario>));

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretJWT")!);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(x => {
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
