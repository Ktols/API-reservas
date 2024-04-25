using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura HttpClient para la API de Restful Booker
builder.Services.AddHttpClient("RestfulBooker", client =>
{
    client.BaseAddress = new Uri("https://restful-booker.herokuapp.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
   // client.DefaultRequestHeaders.Add("Content-Type", "application/json");
});

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
