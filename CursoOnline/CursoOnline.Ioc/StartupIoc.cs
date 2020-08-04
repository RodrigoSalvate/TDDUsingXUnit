
using CursoOnline.Domain.Interfaces;
using CursoOnline.Domain.Interfaces.Base;
using CursoOnline.Domain.Services;
using Data.Context;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoOnline.Ioc
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration["connectionString"]));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));

            services.AddScoped<CourseInserter>();
        }
    }
}
