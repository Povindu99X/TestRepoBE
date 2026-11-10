using TestRepoBE.Data;
using TestRepoBE.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MockData>();
builder.Services.AddSingleton<OrderStore>();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseCors();

app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }));
app.MapProductEndpoints();
app.MapUserEndpoints();
app.MapOrderEndpoints();

app.Run();
