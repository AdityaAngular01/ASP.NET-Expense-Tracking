// using Microsoft.EntityFrameworkCore;
// using SmartExpense.API.Data;
// using SmartExpense.API.Repositories;
// using SmartExpense.API.Services;
// using FluentValidation;
// using FluentValidation.AspNetCore;
using DotNetEnv;

// Load .env (only if present)
Env.Load();

/*
var builder = WebApplication.CreateBuilder(args);

// Short aliases
var configuration = builder.Configuration;
// var services = builder.Services;

#region Database Configuration

// Default approach (appsettings.json)
// services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


// Using only .env file
// var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
// services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(connectionString));


// Recommended (Hybrid Approach 🔥)
// Priority:
// 1. Environment Variables (Production)
// 2. appsettings.json (Fallback)
// 3. .env (via DotNetEnv)

// configuration.AddEnvironmentVariables();

// var connectionString =
//     configuration.GetConnectionString("DefaultConnection") // from appsettings
//     ?? configuration["DB_CONNECTION"];                     // from env / .env

// if (string.IsNullOrEmpty(connectionString))
// {
//     throw new Exception("Database connection string is not configured.");
// }

// services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(connectionString));

//Using extension method for cleaner code
var services = builder.Services.AddDatabase(configuration);

#endregion


#region Dependency Injection

services.AddScoped<IExpenseRepository, ExpenseRepository>();
services.AddScoped<IExpenseService, ExpenseService>();

#endregion

#region Controllers & Validation

services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<Program>();
    });

#endregion

#region App Pipeline

var app = builder.Build();

app.MapControllers();

app.Run();

#endregion

*/



// Clean code
/*
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services
    .AddDatabase(builder.Configuration)
    .AddApplicationServices()
    .AddValidation()
    .AddSwaggerDocumentation()
    .AddCorsPolicy();

var app = builder.Build();

app.UseAppMiddlewares();

app.MapControllers();

app.Run();
*/

// Super Clean code with extension methods and minimal APIs

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Layered setup
builder.Services
    .AddDatabase(builder.Configuration)     // Infrastructure
    .AddInfrastructure()                    // Infrastructure
    .AddApplication()                       // Application
    .AddPresentation();                     // Presentation

var app = builder.Build();

// Middleware pipeline
app.UsePresentation();

app.MapControllers();

app.Run();