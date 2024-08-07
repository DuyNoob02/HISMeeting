using server.Extensions;


var builder = WebApplication.CreateBuilder(args);
// var keyString = builder.Configuration["Jwt:Key"];
// Console.WriteLine(builder.Configuration.GetDebugView());

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureCors();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.ConfigureMiddleware();

app.MapControllers();

app.Run();
