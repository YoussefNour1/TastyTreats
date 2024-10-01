using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Net;
using TastyTreats.Models;
using TastyTreats.Repositories.UserRepos;

using TastyTreats.ViewModel;


namespace TastyTreats.Controllers
{
    public class AccountController : Controller
    {
        //Asking Process
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Register() => View();


       
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel RegisterModel)
        {
            if (ModelState.IsValid)
            {
                //We will get Data that user will entered in registration form and Save this data in database for user to create account

                //This Step can made with (Auto mapper)
                var applicationUser = new ApplicationUser()
                {
                    UserName = RegisterModel.UserName,
                    Email = RegisterModel.Email,
                    Address = RegisterModel.Address,
                    
                };

                //creating user email and save its data in database 
                //var result = await _userManager.CreateAsync(applicationUser);
                var result = await _userManager.CreateAsync(applicationUser, RegisterModel.Password);

                //Check if creating user Succeeded
                if (result.Succeeded)
                {   
                    //Create Cookies if User created successfully
                    await _signInManager.SignInAsync(applicationUser, isPersistent: false);//session (Remember me for saving email and Password for login )
                    return RedirectToAction("Login", "Account"); //Action / Controller
                }

                //For displaying Errors in Summary
                else 
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(RegisterModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
         
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            /****************************************************************************************************************/

            //Login Steps

            // step1--> Check validation (client-side and server-side)
            // step2--> Check if user exists using UserName or Email
            // step3--> Check if password not null (Password should be the same as Registeration)
            // step4--> Create cookies for this user to Login Successfully

            /****************************************************************************************************************/

            //step1--> Check validation
            if (ModelState.IsValid)
            {
                //step2-- > Check if user exists using UserName or Email
                var applicationUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (applicationUser != null)
                {
                    // step3--> Check if password not null
                    var PasswordExists = await _userManager.CheckPasswordAsync(applicationUser, loginViewModel.Password);
                    if (PasswordExists)
                    {
                        //step4-- > Create cookies for this user to Login Successfully
                        await _signInManager.SignInAsync(applicationUser, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                    ModelState.AddModelError("", "User Name or Password is Incorrect");
            }

            return View(loginViewModel);
        }


        public async Task<IActionResult> LogOut()
        {
            //Delete cookies for User to made him Login once again
            await _signInManager.SignOutAsync();
            return View(nameof(Login));
        }

    }
}