using eBusiness.Areas.Admin.ViewModels;
using eBusiness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccountController : Controller
	{
	

		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly DataContext _dataContext;

		public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager , DataContext dataContext)
		{

			_userManager = userManager;
			_signInManager = signInManager;
			_dataContext = dataContext;
			
		}
		//public async Task<IActionResult> CreateAdmin()
		//{
		//	AppUser appUser = new AppUser
		//	{
		//		FullName = "Fidan Suleymanova",
		//		UserName = "Admin"
		//	};
		//	var result = await _userManager.CreateAsync(appUser, "Fidan2002");
		//	return Ok(result);
		//}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
		{
			if (!ModelState.IsValid) return View();
			AppUser user = await _userManager.FindByNameAsync(adminLoginViewModel.Username);

			if (user == null)
			{
				ModelState.AddModelError("", "Username or password is incorrent!");
				return View();
			}
			var result = await _signInManager.PasswordSignInAsync(user,adminLoginViewModel.Password,false,false);

			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Username or password is incorret!");
				return View();
			}
			

			return RedirectToAction("Index","dashboard");
		}
		public IActionResult Register()
		{

			return View();
		}
	}
}
