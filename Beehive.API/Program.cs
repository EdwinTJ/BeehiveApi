var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Mock Data
builder.Services.AddScoped<ILoremGenerator, LoremGenerator>();
builder.Services.AddScoped<IMockDataService, MockDataService>();
// Mock User
builder.Services.AddScoped<IUserGenerator, UserGenerator>();
builder.Services.AddScoped<IMockuserService, MockUserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
