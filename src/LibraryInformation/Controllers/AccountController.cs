using LibraryInformation.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInformation.Controllers
{
    public class AccountController:BaseController
    {
        [FromServices]
        public SignInManager<User> signInManager { get; set; }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(string username, string password)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(username, password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch(Exception e)
            {
                return Content("登录失败，请检查用户名或密码");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /* Modify */

        [HttpGet]
        [Authorize]
        public IActionResult Modify()
        {
            return View(User.Current);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Modify(string currentpwd, string newpwd, string confirmpwd)
        {
            if (confirmpwd != newpwd)
                return Content("两次输入的密码不一致，请重新输入");

            var result = await UserManager.ChangePasswordAsync(await UserManager.FindByIdAsync(User.Current.Id), currentpwd, newpwd);

            if (!result.Succeeded)
                return Content(result.Errors.First().Description);

            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
