using JeBalance.Domain.Model;

namespace API.Resources
{
	public class PersonneAPI
	{
		public string Nom { get; set; }
		public string Prenom { get; set; }

		public Statut Statut { get; set; }
		public Adresse Adresse { get; set; }

		public PersonneAPI()
		{
		}
	}
}
