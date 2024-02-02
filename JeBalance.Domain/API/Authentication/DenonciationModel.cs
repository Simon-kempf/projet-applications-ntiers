using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.API.Authentication;

public class DenonciationModel
{
	[Required(ErrorMessage = "Horodatage is required")]
	public DateTime? Horodatage { get; set; }
	[Required(ErrorMessage = "Informateur is required")]
	public string? Informateur { get; set; }
	[Required(ErrorMessage = "Suspect is required")]
	public string? Suspect { get; set; }

}
