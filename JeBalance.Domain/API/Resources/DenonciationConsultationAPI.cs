using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace API.Resources
{
	public class DenonciationConsultationAPI
	{
		[JsonPropertyName("horodatage")]
		public DateTime Horodatage { get; set; }
		[JsonPropertyName("informateur")]
		public PersonneAPIConsultation Informateur { get; set; }
		[JsonPropertyName("suspect")]
		public PersonneAPIConsultation Suspect { get; set; }
		[JsonPropertyName("delit")]
		public Delit Delit { get; set; }
		[JsonPropertyName("paysEvasion")]
		public ValueAPI PaysEvasion { get; set; }
		[JsonPropertyName("estTraitee")]
		public bool EstTraitee { get; set; }
		[JsonPropertyName("reponse")]
		public ReponseAPI Reponse { get; set; }


		public DenonciationConsultationAPI()
		{
		}
	}
}
