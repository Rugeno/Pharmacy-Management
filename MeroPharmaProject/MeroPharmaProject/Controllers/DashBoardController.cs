using MeroPharmaProject.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeroPharmaProject.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private DatabaseContext _database;
        public DashBoardController(DatabaseContext database)
        {
            _database = database;
        }

        public IActionResult ViewEmployees()
        {
            return View(_database.Users.ToList());
        }
        public IActionResult Display()
        {
            return View();
        }
    }
}
