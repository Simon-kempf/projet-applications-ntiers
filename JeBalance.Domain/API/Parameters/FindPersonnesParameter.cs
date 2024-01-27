using JeBalance.Domain.Model;
using System.Text.Json.Serialization;

namespace API.Parameters
{
	public class FindPersonnesParameter
	{
		public int Limit { get; set; }

		public int Offset { get; set; }

		public int? id { get; set; }

		public string? Prenom { get; set; }

		public string? Nom { get; set; }


		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Statut? Statut { get; set; }

		public FindPersonnesParameter()
		{
		}
	}
}
