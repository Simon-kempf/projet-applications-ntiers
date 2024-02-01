using API.Resources;
using Blazored.Modal;
using JeBalance.Domain.Model;
using JeBalance.UI.Authentication;
using JeBalance.UI.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Shared
{
	public class DenonciationCreationService : ServiceBase<DenonciationCreationAPI>
	{
		private const string Controller = "Denonciation";
		public DenonciationCreationService(IHttpClientFactory clientFactory, AuthenticationStateProvider authStateProvider)
		: base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
		{
		}

		public async Task<int> AddDenonciationAsync(DenonciationCreationAPI denonciation)
		{
            var request = await MakeAddRequest(denonciation);
            var id = await SendAddRequest(request);
            return id;
        }
	}
}