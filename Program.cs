using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Repository;
using RH.Repository.Interface;
using RH.Service;
using RH.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//repositorios
builder.Services.AddScoped<ICandidatoRepository, CandidatoRepository>();
builder.Services.AddScoped<ITecnologiaRepository, TecnologiaRepository>();
builder.Services.AddScoped<IVagaRepository, VagaRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

//serviços
builder.Services.AddScoped<ICandidatoService, CandidatoService>();
builder.Services.AddScoped<ITecnologiaService, TecnologiaService>();
builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddScoped<ITriagemService, TriagemService>();

builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();