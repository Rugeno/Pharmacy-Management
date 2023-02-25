using MeroPharmaProject.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MeroPharmaProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
            [HttpGet]
        public IActionResult ListUser()
        {
            var users = userManager.Users;
            return View(users);
        }

        public IActionResult Display()
        {
           return View();
        }
    }
}
