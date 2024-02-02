using Microsoft.AspNetCore.Identity;

namespace JeBalance.API.Authentication;

public class ApplicationUser : IdentityUser
{
	public int AssociatedId { get; set; }
}