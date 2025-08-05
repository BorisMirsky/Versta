using Versta.Core.Abstractions;
using Versta.DataAccess;
using Versta.DataAccess.Repo;
using Versta.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Versta.DataAccess.Scripts;


var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<VerstaDbContext>(options => options.UseNpgsql(connection));
builder.Services.AddControllers();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IOrdersRepo, OrdersRepo>();
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<IAccountsRepo, AccountsRepo>();
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{                          
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.IncludeErrorDetails = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"]!)),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"]!,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"]!,
    };
});

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(corsBuilder =>
//        corsBuilder.WithOrigins("http://localhost:3000")
//                   .AllowAnyMethod()
//                   .AllowAnyHeader()
//                   .AllowCredentials());
//});
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();                        // ?!
app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
