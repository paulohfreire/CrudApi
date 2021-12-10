using CrudApi.Application.Interfaces;
using CrudApi.Application.Mappings;
using CrudApi.Application.Services;
using CrudApi.Domain.Interfaces;
using CrudApi.Infra.Data.Context;
using CrudApi.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrudApi.Infra.IoC
{
    public static class DependencyInjectionApi
    {
        public static IServiceCollection AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("CrudApi.Application");
            services.AddMediatR(myhandlers);

            return services;
        }

    }
}
