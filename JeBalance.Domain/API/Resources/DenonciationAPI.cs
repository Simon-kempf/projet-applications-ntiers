using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace API.Resources
{
	public class DenonciationAPI
	{
		public DateTime Horodatage { get; set; }
		public Personne Informateur { get; set; }
		public Personne Suspect { get; set; }
		public Delit Delit { get; set; }
		public string PaysEvasion { get; set; }
		public Reponse Reponse { get; set; }

		public DenonciationAPI()
		{
		}
	}
}
