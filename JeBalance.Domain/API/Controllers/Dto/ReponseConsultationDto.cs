using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace API.Controllers.Dto
{
    public class ReponseConsultationDto : ReponseDto
    {
        [JsonPropertyName("horodatage")]
        public DateTime? Horodatage { get; set; }
    }
}
