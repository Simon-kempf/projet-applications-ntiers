namespace API
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddAPI(this IServiceCollection services)
		{
			services.AddMediatR(cf =>
		   cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
			return services;
		}

	}
}
