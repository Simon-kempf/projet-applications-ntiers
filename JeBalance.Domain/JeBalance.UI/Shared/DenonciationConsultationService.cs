using API.Controllers.Dto;
using API.Resources;
using Blazored.Modal;
using JeBalance.Domain.Model;
using JeBalance.UI.Authentication;
using JeBalance.UI.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Shared
{
	public class DenonciationConsultationService : ServiceBase<DenonciationConsultationAPI>
	{
		private const string Controller = "Denonciation";
		public DenonciationConsultationService(IHttpClientFactory clientFactory, AuthenticationStateProvider authStateProvider)
		: base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
		{
		}
		public async Task<DenonciationConsultationAPI[]> GetDenonciationsAsync(int limit = 10,	int offset = 0,	Statut? status = null)
		{
			var request = await MakePaginatedGetAllRequest(
			limit,
			offset,
			status.HasValue
			? new KeyValuePair<string, string>("status",
			((int)status).ToString())
			: null);
			var denonciations = await SendGetAllPaginatedRequest(request);
			return denonciations;
		}
		public async Task<DenonciationConsultationAPI> GetDenonciationAsync(int id)
		{
			var request = await MakeGetOneRequest(id);
			var denonciation = await SendGetOneRequest(request);
			return denonciation;
		}
	}
}