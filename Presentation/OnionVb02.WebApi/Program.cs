using OnionVb02.Application.DependencyResolvers;
using OnionVb02.InnerInfrastructure.DependencyResolvers;
using OnionVb02.Persistence.DependencyResolvers;
using OnionVb02.WebApi.DependencyResolvers;
using OnionVb02.Application.DependencyResolvers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextService();
builder.Services.AddDtoMapperService();
builder.Services.AddManagerService();
builder.Services.AddRepositoryService();
builder.Services.AddVmMapperService();
builder.Services.AddHandlerService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
