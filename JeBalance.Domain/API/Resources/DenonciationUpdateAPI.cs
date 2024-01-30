using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace API.Resources
{
	public class DenonciationUpdateAPI
	{
		//Tenter de faire en découpant les Personne et Reponse en petits champs
		//Aussi, ne plus renseigner l'identifiant de l'Informateur et du Suspect... inutile
		public int Retribution { get; set; }
		public int TypeReponse { get; set; }


		public DenonciationUpdateAPI()
		{
		}
	}
}
