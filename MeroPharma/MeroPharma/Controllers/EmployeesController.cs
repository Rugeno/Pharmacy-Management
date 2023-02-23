using MeroPharma.Data;
using MeroPharma.Models;
using MeroPharma.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace MeroPharma.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDBContext mvcDbContext;

        public EmployeesController(MVCDBContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ViewEmployees()
        {
            var employess = await mvcDbContext.Employees.ToListAsync();
            return View(employess);

        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                EmployeeID = Guid.NewGuid(),
                Email= addEmployeeRequest.Email,
                EmployeeName = addEmployeeRequest.EmployeeName,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Password = addEmployeeRequest.Password,
                Contact = addEmployeeRequest.Contact,
            };

            await mvcDbContext.Employees.AddAsync(employee);
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("AddEmployee");
        }


        [HttpGet]
        public async Task<IActionResult> ViewDetails(Guid id)
        {
            var employee = await mvcDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);

            if(employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    EmployeeID = employee.EmployeeID,
                    Email = employee.Email,
                    EmployeeName = employee.EmployeeName,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Password = employee.Password,
                    Contact = employee.Contact
                };

                return View(viewModel);
            }

            
            return RedirectToAction("ViewEmployees");
        }

        [HttpPost]
        public async Task<IActionResult> ViewDetails(UpdateEmployeeViewModel model)
        {
            var employee = await mvcDbContext.Employees.FindAsync(model.EmployeeID);

            if (employee != null)
            {
                employee.EmployeeName = model.EmployeeName;
                employee.Email= model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth= model.DateOfBirth;    
                employee.Password = model.Password;
                employee.Contact = model.Contact;

                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("ViewEmployees");
            }

            return RedirectToAction("ViewEmployees");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(UpdateEmployeeViewModel model)
        {
            var employee = await mvcDbContext.Employees.FindAsync(model.EmployeeID);

            if (employee != null)
            {
                mvcDbContext.Employees.Remove(employee);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("ViewEmployees");
            };

            return RedirectToAction("ViewEmployees");
        }
    }
}
