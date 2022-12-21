using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmpoyees);
        }
        // HTTP GET VERSION
        public IActionResult Create()
        {
            return View();
        }

        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            Repository.Create(employee);
            return View("Thanks", employee);
        }

        public IActionResult Update(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee, string empname)
        {
            Employee e = Repository.AllEmpoyees.FirstOrDefault(b=>b.Name==empname);
            e.Age = employee.Age;
            e.Salary = employee.Salary;
            e.Department = employee.Department;
            e.Sex = employee.Sex;
            e.Name = employee.Name;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}
