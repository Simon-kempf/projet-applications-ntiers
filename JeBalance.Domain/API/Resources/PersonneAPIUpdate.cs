using JeBalance.Domain.Model;

namespace API.Resources
{
	public class PersonneAPIUpdate
	{
		public string Nom { get; set; }
		public string Prenom { get; set; }

		public Statut Statut { get; set; }
		public int estVIP { get; set; }
		public int estCalomniateur { get; set; }
		public Role Role { get; set; }
		public int CodePostal { get; set; }
		public string NomDeCommune { get; set; }
		public string NomDeVoie { get; set; }
		public int NumeroDeVoie { get; set; }

		public PersonneAPIUpdate()
		{
		}
	}
}
