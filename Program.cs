using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Repository.Interface;
using RH.Repository;
using RH.Service.Interface;
using RH.Service;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//repositorios
builder.Services.AddScoped<ICandidatoRepository, CandidatoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

//servi�os
builder.Services.AddScoped<ICandidatoService, CandidatoService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();

builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
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