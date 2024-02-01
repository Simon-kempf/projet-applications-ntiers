using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace API.Resources
{
	public class PersonneAPIConsultation
	{
		[JsonPropertyName("nom")]
		public ValueAPI Nom { get; set; }
		[JsonPropertyName("prenom")]
		public ValueAPI Prenom { get; set; }
		public PersonneAPIConsultation()
		{

		}
	}
}
