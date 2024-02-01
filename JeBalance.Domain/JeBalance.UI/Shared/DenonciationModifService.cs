using API.Resources;
using Blazored.Modal;
using JeBalance.Domain.Model;
using JeBalance.UI.Authentication;
using JeBalance.UI.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Shared
{
	public class DenonciationModifService : ServiceBase<DenonciationUpdateAPI>
	{
		private const string Controller = "Denonciation";
		public DenonciationModifService(IHttpClientFactory clientFactory, AuthenticationStateProvider authStateProvider)
		: base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
		{
		}

		public async Task<int> ModifDenonciationAsync(DenonciationUpdateAPI denonciation)
		{
			var request = await MakeUpdateRequest(denonciation.Id, denonciation);
			var id = await SendUpdateRequest(request);
			return id;
		}
	}
}