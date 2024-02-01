using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace API.Resources
{
	public class ReponseAPI
	{
		[JsonPropertyName("horodatage")]
		public DateTime Horodatage { get; set; }
		[JsonPropertyName("type")]
		public int Type { get; set; }
		[JsonPropertyName("retribution")]
		public int Retribution { get; set; }
	}
}
