
using StudentSystem.API.Extensios;
using StudentSystem.API.Middlewares;

namespace StudentSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddDbContexts(builder.Configuration)
                .AddAuthentication(builder.Configuration)
                .AddInfrastructure()
                .AddApplication()
                .AddSwagger()
                .AddCors(options =>
                {
                    options.AddPolicy("Any", policyBuilder =>
                    {
                        policyBuilder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .Build();
                    });
                })
                .AddControllerMapping();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("Any");
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}