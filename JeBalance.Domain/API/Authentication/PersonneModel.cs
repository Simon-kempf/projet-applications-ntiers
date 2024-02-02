using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.API.Authentication;

public class PersonneModel
{
	public string? Nom { get; set; }
	public string? Prenom { get; set; }
	public string? Statut { get; set; }
	public bool? estVIP { get; set; }
	public bool? estCalomniateur { get; set; }
	public string? Role { get; set; }
	public string? Adresse { get; set; }
}
