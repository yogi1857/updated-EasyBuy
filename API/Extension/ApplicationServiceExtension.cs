using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using API.Errors;

namespace API.Extension
{
    public  static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services){
             services.AddScoped<IProductRepo,ProductRepo>();
            services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
             services.Configure<ApiBehaviorOptions> (options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState 
                    .Where( e => e.Value.Errors.Count >0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                         Errors = errors
                    };
                          return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}