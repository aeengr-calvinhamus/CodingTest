using CodingTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using CodingTest.Data;

namespace CodingTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static FakeData s_data = new();
        private static Repository<Employee> s_employees = new(s_data.GetEmployees());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Employee()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete([FromForm] Employee employee)
        {
            RemoveEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit([FromForm] int employeeId, String name, String Address)
        {
            Employee employee = new()
            {
                Name = name,
                Address = Address,
                EmployeeId = employeeId
            };
            UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] String name, String Address)
        {
            Employee employee = new()
            {
                Name = name,
                Address = Address
            };
            Random rand = new();
            int employeeId;
            do
            {
                employeeId = rand.Next(int.MaxValue);
            } while (GetEmployee(employeeId) != null);
            employee.EmployeeId = employeeId;
            AddEmployee(employee);
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static List<Employee> GetEmployees()
        {
            return s_employees.GetEntities();
        }

        public static Employee? GetEmployee(int _id)
        {
            List<Employee> _employees = GetEmployees();
            foreach (Employee employee in _employees)
            {
                if (employee.EmployeeId == _id)
                {
                    return employee;
                }
            }
            return null;
        }

        public static void AddEmployee(Employee employee)
        {
            s_employees.AddEntity(employee);
        }

        public static bool RemoveEmployee(Employee employee)
        {

            return s_employees.RemoveEntity(employee);
        }

        public static void UpdateEmployee(Employee employee)
        {
            s_employees.UpdateEntity(employee);
        }

    }
}