using TestRepoBE.Data;
using TestRepoBE.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MockData>();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseCors();

app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }));
app.MapProductEndpoints();
app.MapUserEndpoints();

app.Run();
