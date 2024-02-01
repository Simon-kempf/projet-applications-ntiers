using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace API.Resources
{
	public class ValueAPI
	{
		[JsonPropertyName("value")]
		public string Value { get; set; }
	}
}
