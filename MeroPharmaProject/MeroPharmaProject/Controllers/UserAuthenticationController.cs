
using MeroPharmaProject.Models;
using MeroPharmaProject.Models.Domain;
using MeroPharmaProject.Models.DTO;
using MeroPharmaProject.Repository.Abstaract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeroPharmaProject.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this._authService = authService;
        }

        


        public IActionResult Login()
        
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await this._authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }
      

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> RegisterAdmin()
        {
            RegistrationModel model = new RegistrationModel
            {
                Name = "admin1",
                Username = "admin1",
                Email = "admin@gmail.com",
                Password = "Admin12345#"
            };
            model.Role = "admin";
            var result = await this._authService.RegisterAsync(model);
            return Ok(result);
        }

        //[Authorize]
        //public IActionResult ChangePassword()
        //{
        //    return View();
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);
        //    var result = await _authService.ChangePasswordAsync(model, User.Identity.Name);
        //    TempData["msg"] = result.Message;
        //    return RedirectToAction(nameof(ChangePassword));
        //}

    }
}