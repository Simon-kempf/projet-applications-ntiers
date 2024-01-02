using System.Text.Json.Serialization;

namespace API.Controllers.Dto
{
    public class CategorieDto
    {

        [JsonPropertyName("nom")]
        public string Nom { get; set; } = null!;

        [JsonPropertyName("personnes")]
        public List<PersonneDto?> Personnes { get; set; } = null!;
    }
}
