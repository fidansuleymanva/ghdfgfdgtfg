using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
	public class AdminLoginViewModel
	{
		[Required]
		[StringLength(maximumLength:50)]
		public string Username { get; set; }

		[Required]
		[StringLength(maximumLength:20,MinimumLength =8)]
		public string Password { get; set; }
	}
}
