using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.DependencyResolvers
{
    public static class DtoMapperResolver
    {
      
        public static void AddDtoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoMappingProfile));
        }
    }
}
