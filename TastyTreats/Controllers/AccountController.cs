using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Net;
using System.Security.Claims;
using TastyTreats.Models;
using TastyTreats.Repositories;
using TastyTreats.Repositories.UserRepos;

using TastyTreats.ViewModel;


namespace TastyTreats.Controllers
{
    public class AccountController : Controller
    {
        //Asking Process
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IEmailSenderRepository _emailSenderRepository;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSenderRepository emailSenderRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSenderRepository = emailSenderRepository;
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
                    await _userManager.AddToRoleAsync(applicationUser, "User");

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
                //var applicationUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
                var applicationUser = await _userManager.Users
                .Where(u => u.Email == loginViewModel.Email)
                .FirstOrDefaultAsync();

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
            return RedirectToAction("Index","Home");
        }

        //======================================================================================================================

        //External Login With Google Account

        //This method used to initiate the external login(Handel request for login with Google Account)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider = "Google", string returnUrl = null)
        {
            // Request a redirect to the external login provider (e.g., Google)
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        //This method will handel this point once the user has authenticated via Google, Google will redirect back to your application
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View(nameof(Login));
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Check if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                // If the user already has a login, redirect them to the homepage or return URL.
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user doesn't have an account, create one.
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (email != null)
                {
                    var user = new ApplicationUser { UserName = email, Email = email };

                    // Create a new user based on the external login information.
                    var createResult = await _userManager.CreateAsync(user);
                    if (createResult.Succeeded)
                    {
                        // Assign the new user to a role, e.g., "User"
                        var roleResult = await _userManager.AddToRoleAsync(user, "User");
                        if (!roleResult.Succeeded)
                        {
                            // If role assignment fails, add errors to the ModelState and show the login page.
                            foreach (var error in roleResult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                            return View(nameof(Login));
                        }

                        // Add the external login info for the newly created user.
                        await _userManager.AddLoginAsync(user, info);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }

                    // If account creation fails, add errors to the ModelState.
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                // If the email is null or account creation fails, return to the login page.
                return View(nameof(Login));
            }
        }



        //This method is used to safely redirect the user back to the returnUrl or to the home page if no return URL is provided.
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        //===========================================================================================================================

        //Forget Password Method

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        //This action will send an email with a reset password link to the user.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist or is not confirmed
                return RedirectToAction("ForgotPasswordConfirmation");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Account", new { token, email = model.Email }, Request.Scheme);

            // Send the email with the reset link (implement your email service)
            await _emailSenderRepository.SendEmailAsync(model.Email, "Reset Password", $"Please reset your password by clicking here: <a href='{resetLink}'>link</a>");

            return RedirectToAction("ForgotPasswordConfirmation");
        }


        //This action displays a confirmation view after the email has been sent.
        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //This action will render the reset password form where users can input a new password.
        [HttpGet]
        public IActionResult ResetPassword(string token = null)
        {
            if (token == null)
            {
                // Redirect to an error view with a meaningful message
                TempData["ErrorMessage"] = "Invalid password reset token. Please request a new one.";
                return RedirectToAction("Error", "Home");
            }

            return View(new ResetPasswordViewModel { Token = token });
        }


        //This action will handle the password reset functionality.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }


        //This action confirms that the password has been successfully reset.
        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }



    }
}