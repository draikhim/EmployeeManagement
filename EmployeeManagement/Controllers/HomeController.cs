using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        public ViewResult Details()
        {
            /********************************************************************************************************************
             * Different methods to pass data from controller to view
             * 1.ViewData --> loosely typed view, no compile-time type checking and intellisense
             * 2.ViewBag --> loosely typed view, wrapper around viewdata, dynamic, no compile-time type checking and intellisense
             * 3.Strongly Typed View --> Has intellisense and compile time error checking
             * ********************************************************************************************************************/
            Employee model = _employeeRepository.GetEmployee(1);
            ViewBag.PageTitle = "Employee Details";
            return View(model);
        }
    }
}
