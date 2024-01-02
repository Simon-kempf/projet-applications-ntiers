using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JeBalance.Domain.Controllers.Dto
{
    public class CategorieDto
    {

        [JsonPropertyName("nom")]
        public string Nom { get; set; } = null!;

        [JsonPropertyName("personnes")]
        public List<PersonneDto?> Personnes { get; set; } = null!;
    }
}
