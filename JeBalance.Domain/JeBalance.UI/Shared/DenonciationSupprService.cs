using API.Resources;
using Blazored.Modal;
using JeBalance.Domain.Model;
using JeBalance.UI.Authentication;
using JeBalance.UI.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Shared
{
	public class DenonciationSupprService : ServiceBase<DenonciationCreationAPI>
	{
		private const string Controller = "Denonciation";
		public DenonciationSupprService(IHttpClientFactory clientFactory, AuthenticationStateProvider authStateProvider)
		: base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
		{
		}

		public async Task<bool> SupprDenonciationAsync(int id)
		{
			var request = await MakeDeleteRequest(id);
			await SendDeleteRequest(request);
			return true;
		}
	}
}