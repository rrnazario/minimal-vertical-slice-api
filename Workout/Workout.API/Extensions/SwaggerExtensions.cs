using Carter.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Workout.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "Workout API - Minimal edition",
                    Version = "v1",
                    Title = "Workout API - Minimal edition"
                });

                options.DocInclusionPredicate((_, description) =>
                    description.ActionDescriptor.EndpointMetadata.Any(_ => _ is IIncludeOpenApi));
            });

            return services;
        }

        public static WebApplication MapSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
