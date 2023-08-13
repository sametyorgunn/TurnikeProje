using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.BussinesLayer.Abstract;
using TurnikeProje.BussinesLayer.Concrete;
using TurnikeProje.DataAccessLayer.Abstract;
using TurnikeProje.DataAccessLayer.Repositories;

namespace TurnikeProje.BussinesLayer.ServiceRegistiration
{
    public static class ServiceRoute
    {
        public static void AddRegisterRoutes(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IInOutTimeService, InOutTimeManager>();

            services.AddScoped<IInOutTimeDal, InOutTimeRepository>();
            services.AddScoped<IUserDal, EfUserRepository>();

        }
    }
}
