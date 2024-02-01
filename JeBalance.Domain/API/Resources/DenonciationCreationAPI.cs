using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace API.Resources
{
	public class DenonciationCreationAPI
	{
		//Tenter de faire en découpant les Personne et Reponse en petits champs
		//Aussi, ne plus renseigner l'identifiant de l'Informateur et du Suspect... inutile
		public int Id { get; set; }
		public string NomInformateur { get; set; }
		public string PrenomInformateur { get; set; }
		public int CodePostalInformateur { get; set; }
		public string NomDeCommuneInformateur { get; set; }
		public int NumeroDeVoieInformateur { get; set; }
		public string NomDeVoieInformateur { get; set; }
		public string NomSuspect { get; set; }
		public string PrenomSuspect { get; set; }
		public int CodePostalSuspect { get; set; }
		public string NomDeCommuneSuspect { get; set; }
		public int NumeroDeVoieSuspect { get; set; }
		public string NomDeVoieSuspect { get; set; }
		public Delit Delit { get; set; }
		public string PaysEvasion { get; set; }

		public DenonciationCreationAPI()
		{
		}
	}
}
