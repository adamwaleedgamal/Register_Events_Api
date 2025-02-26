using login;
using login.Repo.Events_Repo;
using login.Repo.Login_Repo;
using login.Repo.Signup_Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// ✅ Enable CORS - Allow requests from specific frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.AllowAnyOrigin() // ✅ Allow your frontend URL
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Context
builder.Services.AddDbContext<Appdbcontext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<Ilogin, Loginn>();
builder.Services.AddScoped<ISignUP, SignUpp>();
builder.Services.AddScoped<IEvents, Eventss>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// ✅ Apply CORS Middleware BEFORE other middlewares
app.UseCors("AllowFrontend");

app.Use(async (context, next) =>
{
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200;
        await context.Response.CompleteAsync();
        return;
    }
    await next();
});


app.UseAuthorization();

app.MapControllers();

app.Run();
