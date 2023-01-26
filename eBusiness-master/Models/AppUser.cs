using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
	public class AppUser:IdentityUser
	{
		[StringLength(maximumLength: 100,ErrorMessage ="FullNmae uzunlugu duzgun deyil!")]
		public string FullName { get; set; }
	}
}
