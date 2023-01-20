using Application;
using Infrastructure;
using Web.Helpers;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMidlleware();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.AddBearerTokenSupport());
builder.Services.AddApplication(builder.Host);
builder.Services.AddWeb(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

//await app.Services.SeedDatabase();
app.UseCors(o =>
    o.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseMiddleware<ExceptionHandlingMiddleware>();


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
