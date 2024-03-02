using IntegrandoApi.Database;
using IntegrandoApi.Services;

namespace ProyectoFinal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<UsuarioData>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<ProductoData>();
            builder.Services.AddScoped<ProductoService>();
            builder.Services.AddScoped<ProductoVendidoData>();
            builder.Services.AddScoped<ProductoVendidoService>();
            builder.Services.AddScoped<VentaData>();
            builder.Services.AddScoped<VentaService>();
            builder.Services.AddCors(Options =>
            {
                Options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
            }
            );
            }
            );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
