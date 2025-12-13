using FluentValidation.AspNetCore;
using OnionVb02.Application.DependencyResolvers;
using OnionVb02.Persistence.DependencyResolvers;
using OnionVb02.ValidatorStructor.DependencyResolvers;
using OnionVb02.WebApi.Filters;
using OnionVb02.WebApi.Middlewares;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContextService();
        builder.Services.AddRepositoryService();
        builder.Services.AddHandlerService();
        builder.Services.AddValidatorService();
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddScoped<ValidationFilter>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AngularClient", policy =>
            {
                policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        var app = builder.Build();

        app.UseGlobalExceptionMiddleware();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AngularClient");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}