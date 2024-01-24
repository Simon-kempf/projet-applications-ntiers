using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace API_Secrete.Controllers.Dto
{
    public class PersonneDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nom")]
        public string? Nom { get ; set; }

        [JsonPropertyName("prenom")]
        public string? Prenom { get; set; }

        [JsonPropertyName("adresse")]
        public string? Adresse { get; set; }
    }
}
