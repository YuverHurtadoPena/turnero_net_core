using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Turnero.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Turnero.DAL.Interfaces;
using Turnero.DAL.Implementacion;
using Turnero.BLL.Interfaces;
using Turnero.BLL.Implementacion;

namespace Turnero.IOC
{
    public static class Dependencia
    {
        public static void InyecionDepencia(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<TurneroContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("cadenaSQL"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICorreoService, CorreoService>();
            services.AddScoped<IUtileriaService, UtileriaService>();
            services.AddScoped<IRolService, RolService>();



        }
    }
}
