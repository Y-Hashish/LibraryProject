using LibraryProject.Models;
using LibraryProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryProject.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> sign;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> sign)
		{
			this.userManager = userManager;
			this.sign = sign;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM userVM)
		{
			if (ModelState.IsValid)
			{
				//save to data base 
				ApplicationUser user = new ApplicationUser();
				// Mapping 
				user.PasswordHash = userVM.Password;
				user.UserName = userVM.Username;
				user.Email = userVM.Email;
				IdentityResult result = await userManager.CreateAsync(user, userVM.Password); // should define it in the ctor above 
				if (result.Succeeded)
				{
					// create role
					await userManager.AddToRoleAsync(user, "user");
					// create cooki
					await sign.SignInAsync(user, false);
					return RedirectToAction("Index", "test");
				}
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
			return View("Register", userVM);
		}

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser user = await userManager.FindByNameAsync(loginVM.name);
				if (user != null)
				{
					bool found = await userManager.CheckPasswordAsync(user, loginVM.password);
					if (found == true)
					{
						List<Claim> claims = new List<Claim>();
						claims.Add(new Claim("email", user.Email));
						await sign.SignInWithClaimsAsync(user, loginVM.rememberMe, claims);
						//await sign.SignInAsync(user, loginVM.rememberMe);
						return RedirectToAction("index", "test");
					}
				}
				ModelState.AddModelError("", "Username or Password is wrong");
			}
			return View("Login", loginVM);
		}
		public async Task<IActionResult> signout()
		{
			await sign.SignOutAsync();
			return RedirectToAction("login");
		}
	}
}