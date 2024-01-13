using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace API.Controllers.Dto
{
    public class DenonciationConsultationDto : DenonciationDto
    {
        [JsonPropertyName("horodatage")]
        public DateTime? Horodatage { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("reponse")]
        public ReponseDto? Reponse { get; set; }
    }
}
