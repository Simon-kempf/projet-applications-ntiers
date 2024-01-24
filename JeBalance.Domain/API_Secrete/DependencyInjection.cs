namespace API_Secrete
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddAPI_Secrete(this IServiceCollection
services)
		{
			services.AddMediatR(cf =>
		   cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
			return services;
		}

	}
}
