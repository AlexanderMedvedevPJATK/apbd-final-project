using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Middlewares;
using Project.Repositories;
using Project.Repositories.Abstraction;
using Project.Services;
using Project.Services.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApbdProjectContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Docker"));
});

builder.Services.AddScoped<IIndividualClientsService, IndividualClientsService>();
builder.Services.AddScoped<ICompanyClientsService, CompanyClientsService>();

builder.Services.AddScoped<IIndividualClientsRepository, IndividualClientsRepository>();
builder.Services.AddScoped<ICompanyClientsRepository, CompanyClientsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
    

app.Run();