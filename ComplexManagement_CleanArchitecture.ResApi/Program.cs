using ComplexManagement_CleanArchitecture.EFPresistence;
using ComplexManagement_CleanArchitecture.EFPresistence.Blocks;
using ComplexManagement_CleanArchitecture.EFPresistence.Complexes;
using ComplexManagement_CleanArchitecture.EFPresistence.Units;
using ComplexManagement_CleanArchitecture.Service.Blocks;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts;
using ComplexManagement_CleanArchitecture.Service.Complexes;
using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts;
using ComplexManagement_CleanArchitecture.Service.Contracts;
using ComplexManagement_CleanArchitecture.Service.Units;
using ComplexManagement_CleanArchitecture.Service.Units.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ComplexService, ComplexAppService>();
builder.Services.AddScoped<ComplexRepository, EFComplexRepository>();
builder.Services.AddScoped<BlockService, BlockAppService>();
builder.Services.AddScoped<BlockRepository, EFBlockRepository>();
builder.Services.AddScoped<UnitRepository, EFUnitRepository>();
builder.Services.AddScoped<UnitService, UnitAppService>();
 


builder.Services.AddDbContext<EFDataContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("SqlServer"));
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
