﻿using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
			_departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var dept = _departmentService.GetAll();
            return View(dept);
        }
		[HttpGet]
		public IActionResult Create() 
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Department department)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_departmentService.Add(department);
					return RedirectToAction(nameof(Index));
				}
				ModelState.AddModelError("DepartmentError", "ValidationErrors");
				return View(department);
			}
			catch (Exception ex) 
			{
				ModelState.AddModelError("DepartmentError", ex.Message);
				return View(department);

			}
		}

		public IActionResult Details(int id)
		{
			var dept = _departmentService.GetById(id);
			if(dept is null)
			{
				return NotFound();
			}
			return View(dept);
		}
	}
}
