using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace JeBalance.UI.Data.Services;
public class ServiceBase<SourceType>
{
	private IHttpClientFactory _clientFactory;
	private CustomAuthenticationStateProvider _casp;
	private const string BaseURL = "https://localhost:7029/api/";
	private string Controller;
	private string Endpoint => $"{BaseURL}{Controller}";
	public ServiceBase(IHttpClientFactory clientFactory, CustomAuthenticationStateProvider casp, string controller)
	{
		_clientFactory = clientFactory;
		_casp = casp;
		Controller = controller;
	}

	public async Task<HttpRequestMessage> MakePaginatedGetAllRequest(int limit, int offset, KeyValuePair<string, string>? filter)
	{
		var token = await _casp.GetJWT();
		var param = new Dictionary<string, string>() {
			{ "limit", limit.ToString() },
			{ "offset", offset.ToString() }
		};
		if (filter.HasValue)
		{
			param.Add(filter.Value.Key, filter.Value.Value);
		}
		var request = new HttpRequestMessage(HttpMethod.Get, new Uri(QueryHelpers.AddQueryString(Endpoint, param)));
		request.Headers.Add("Accept", "application/json");
		request.Headers.Add("User-Agent", "JeBalance");
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
		return request;
	}
	public async Task<HttpRequestMessage> MakeGetOneRequest(int id)
	{
		var token = await _casp.GetJWT();
		var request = new HttpRequestMessage(HttpMethod.Get, $"{Endpoint}/{id}");
		request.Headers.Add("Accept", "application/json");
		request.Headers.Add("User-Agent", "JeBalance");
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
		return request;
	}

	public async Task<SourceType[]> SendGetAllPaginatedRequest(HttpRequestMessage request)
	{
		var client = _clientFactory.CreateClient();
		var response = await client.SendAsync(request);
		if (!response.IsSuccessStatusCode) return default(SourceType[]);
		using var responseStream = await response.Content.ReadAsStreamAsync();
		var data = await JsonSerializer.DeserializeAsync<SourceType[]>(responseStream);
		return data;
	}
	public async Task<SourceType> SendGetOneRequest(HttpRequestMessage request)
	{
		var client = _clientFactory.CreateClient();
		var response = await client.SendAsync(request);
		if (!response.IsSuccessStatusCode) return default(SourceType);
		using var responseStream = await response.Content.ReadAsStreamAsync();
		var data = await JsonSerializer.DeserializeAsync<SourceType>(responseStream);
		return data;
	}
}