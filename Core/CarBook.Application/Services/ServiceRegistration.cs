using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace CarBook.Application.Services
{
    public static class ServiceRegistration 
    {
        public static void AddApplicationService(this IServiceCollection services,IConfiguration configuraiton)
        {
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));
        }
    }
}