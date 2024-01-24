using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLServer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddMediatR(cf =>
		   cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

			services.AddScoped<IDenonciationRepository, DenonciationRepositorySQLS>();
			services.AddScoped<IVIPRepository, VIPRepositorySQLS>();

			return services;
		}
	}
}
