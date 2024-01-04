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
    }
}
