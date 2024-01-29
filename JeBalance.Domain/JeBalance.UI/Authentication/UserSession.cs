using System.Data;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace JeBalance.UI.Authentication
{
    public class UserSession
    {
        [JsonPropertyName("nom")]
        public string Nom { get; set; }
        [JsonPropertyName("prenom")]
        public string Prenom { get; set; }
        [JsonPropertyName("adresse")]
        public string Adresse { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
        public ClaimsPrincipal ToClaimsPrincipal(string? authenticationType = "CustomAuth")
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, Nom + " " + Prenom),
                new Claim(ClaimTypes.StreetAddress, Adresse)
            }, authenticationType));
        }
    }
}
