using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            //added data context
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            //add CORS header
             services.AddCors(opt => {
                 opt.AddPolicy("CorsPolicy", policy => {
                    //allow any header that has origins from port 3000 (me)
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                 });
             });
             //tells mediator where to find handlers
             services.AddMediatR(typeof(List.Handler).Assembly);
             services.AddAutoMapper(typeof(MappingProfiles).Assembly);
             return services;
        }
    }
}