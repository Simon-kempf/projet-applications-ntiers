using JeBalance.Domain.Model;
using System.Text.Json.Serialization;

namespace API.Parameters
{
    public class FindOnePersonneParameter
    {

        public string? Prenom { get; set; }

        public string? Nom { get; set; }

        public int CodePostal { get; set; }

        public string? NomDeCommune { get; set; }

        public string? NomDeVoie { get; set; }

        public int NumeroDeVoie { get; set; }

        public FindOnePersonneParameter()
        {
        }
    }
}
