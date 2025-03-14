using DMSubmission.BusinessLogic;
using DMSubmission.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DMSubmission
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.Configure<ExternalApiKeys>(
                builder.Configuration.GetSection("ExternalApiKeys")
            );

            //Register BLL Services
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<INewsArticleService, NewsArticleService>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<ICityInfoService, CityInfoService>();
            //Register API Services
            builder.Services.AddHttpClient<INewsApiService,NewsApiService>();
            builder.Services.AddHttpClient<IWeatherApiService,WeatherApiService>();
            builder.Services.AddHttpClient<IOpenLibraryApiService, OpenLibraryApiService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API Aggregation Project", Version = "v1" });

                // Add support for XML comments
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
                options.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
