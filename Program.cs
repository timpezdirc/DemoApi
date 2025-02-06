using DemoApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseCors("AllowAll");
app.MapControllers();

app.MapFallbackToFile("/home", "index.html");

app.Run();