using AutoMapper;
using Homy.Application.Contracts;
using Homy.Application.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // ✅ Manual AutoMapper Registration
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                // بنجيب كل الـ Profiles من الـ Assembly الحالي
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            // بنتأكد إن الـ Configuration صح (optional but recommended)
            mapperConfig.AssertConfigurationIsValid();

            // بنسجل الـ IMapper في الـ DI Container
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IImageUploadHelper, ImageUploadHelper>();

            // هنضيف Services هنا لاحقاً

            return services;
        }
    }
}
