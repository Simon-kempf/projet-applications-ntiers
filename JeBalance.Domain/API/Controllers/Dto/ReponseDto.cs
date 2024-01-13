using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace API.Controllers.Dto
{
    public class ReponseDto
    {
        [JsonPropertyName("type")]
        public int Type { get ; set; }

        [JsonPropertyName("retribution")]
        public int? Retribution { get; set; }
    }
}
