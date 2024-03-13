using TestAPIaWEBaASP.Data;
using TestAPIaWEBaASP.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Http.StatusCodes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessageDBContext>(options =>
    options.UseInMemoryDatabase("ASPNETCoreRabbitMQ"));

// Добавляем сервисы
builder.Services.AddScoped<ImessageDB, MessageDBContext>();
builder.Services.AddScoped<Imessage, Producer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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




