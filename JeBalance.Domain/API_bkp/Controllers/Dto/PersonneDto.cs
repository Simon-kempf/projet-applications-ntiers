using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JeBalance.Domain.Controllers.Dto
{
    public class PersonneDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nom")]
        public string? Nom { get; set; }

        [JsonPropertyName("prenom")]
        public string? Prenom { get; set; }

        [JsonPropertyName("adresse")]
        public string? Adresse { get; set; }
    }
}
