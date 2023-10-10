using Jarvis.WEB.API.AutoMapper;
using Jarvis.WEB.API.Context;
using Mail.Service.Models;
using Mail.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WEB.API.Jarvis.Context;
using WEB.API.Jarvis.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// For Entity Framework
var configuration = builder.Configuration;
builder.Services.AddDbContext<JarvisDbContext>(options => options.UseSqlServer(
        configuration.GetConnectionString("ConnStr")));

builder.Services.AddDbContext<JarvisFullDbContext>(options => options.UseSqlServer(
        configuration.GetConnectionString("ConnStr")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<JarvisDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options => options.SignIn.RequireConfirmedEmail = true);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!))
    };
});

builder.Services.AddCors(options => {
    options.AddPolicy("MyPolicy", builder => {
        builder.WithOrigins("http://localhost:3000", "http://localhost:4200");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
