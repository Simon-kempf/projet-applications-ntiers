using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace API.Controllers.Dto
{
    public class DenonciationDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("informateur")]
        public IPersonne? Informateur { get ; set; }

        [JsonPropertyName("suspect")]
        public IPersonne? Suspect { get; set; }

        [JsonPropertyName("delit")]
        public Delit? Delit { get; set; }

        [JsonPropertyName("paysevasion")]
        public PaysEvasion? PaysEvasion { get; set; }
    }
}
