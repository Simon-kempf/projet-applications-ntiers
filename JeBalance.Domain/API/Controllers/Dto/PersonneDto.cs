using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace API.Controllers.Dto
{
    public class PersonneDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nom")]
        public Nom? Nom { get ; set; }

        [JsonPropertyName("prenom")]
        public Prenom? Prenom { get; set; }

        [JsonPropertyName("codePostal")]
        public CodePostal? codePostal { get; set; }

        [JsonPropertyName("nomDeCommune")]
        public NomDeCommune? nomDeCommune { get; set; }

        [JsonPropertyName("nomDeVoie")]
        public NomDeVoie? nomDeVoie { get; set; }

        [JsonPropertyName("numeroDeVoie")]
        public NumeroDeVoie? numeroDeVoie { get; set; }
    }
}
