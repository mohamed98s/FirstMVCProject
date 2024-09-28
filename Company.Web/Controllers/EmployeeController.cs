using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
		private readonly IEmployeeService _employeeService;
		private readonly IDepartmentService _departmentService;

		public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
		{
			_employeeService = employeeService;
			_departmentService = departmentService;
		}

        [HttpGet]
		public IActionResult Index(string searchInp)
        {
            if (string.IsNullOrEmpty(searchInp))
            {
                var emp = _employeeService.GetAll();
                return View(emp);
            }
            else
            {
                var emp = _employeeService.GetEmployeeByName(searchInp);
                return View(emp);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
			Console.WriteLine("Received Employee data:");
			Console.WriteLine("DepartmentId: " + employee.DepartmentId);
			Console.WriteLine("DepartmentName: " + employee.Department);

			try
			{
				if (ModelState.IsValid)
                {
					Console.WriteLine("Model is valid. Proceeding to add employee...");

					_employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
					Console.WriteLine("Model is not valid.");

				}
				ViewBag.Departments = _departmentService.GetAll();

				ModelState.AddModelError("EmployeeError", "ValidationErrors");
                return View(employee);
            }
            catch (Exception ex)
            {
				ViewBag.Departments = _departmentService.GetAll();

				ModelState.AddModelError("EmployeeError", ex.Message);
                return View(employee);

            }
        }
    }
}
