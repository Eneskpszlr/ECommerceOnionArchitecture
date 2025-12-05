using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Categories;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.DependencyResolvers
{
    
    public static class HandlerResolver
    {
        public static void AddHandlerService(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(HandlerResolver).Assembly));
        }
    }
}
