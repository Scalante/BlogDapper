using Api;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPublicacionRepository, PublicacionRepository>();


//Swagger/OpenAPI 
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

app.ConfigureApi();


app.Run();
