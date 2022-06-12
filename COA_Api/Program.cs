using COA_Api.Core.Services;
using COA_Api.Core.Services.Interfaces;
using COA_Api.DataAccess;
using COA_Api.DataAccess.Seeder;
using COA_Api.Repositories;
using COA_Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get ConectionString via User Secrets
var CoaConn = configuration["ConnectionStrings:CoaConnection"];
builder.Services.AddDbContext<CoaDbContext>(c => c.UseSqlServer(CoaConn));

//Automapper configure service
builder.Services.AddAutoMapper(typeof(Program));

//Repositories Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Services Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();

// Policy CORS 
builder.Services.AddCors(o => o.AddPolicy("COA", c => { 
        c.AllowAnyOrigin()
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
}));
builder.Services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Policy CORS 
app.UseCors("COA");
app.Use((context, next) =>
{
    context.Items["__CorsMiddlewareInvoked"] = true;
    return next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Migration manager to seed data
app.MigrateDatabase();

app.Run();
