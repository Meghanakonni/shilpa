using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models.Repository;
using MyProject.Models;
using System.Web.Security;

namespace MyProject.Controllers
{
    public class ProjectController : Controller
    {
        IRepository<EmployeeLogin> _employeeRepository = null;
        IRepository<ManagerLogin> _managerRepository = null;

        public ProjectController()
        {
            _employeeRepository = new Repository<EmployeeLogin>();
            _managerRepository = new Repository<ManagerLogin>();
        }
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUpEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUpEmployee(EmployeeLogin employee)
        {
            _employeeRepository.Insert(employee);
            _employeeRepository.Save();
            return RedirectToAction("EmployeeLogin");
        }
        // Action method for EmployeeLogin
        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogin(EmployeeLogin model)
        {
            if (ModelState.IsValid)
            {
                if (IsValidEmployee(model.Name, model.Password))
                {
                    return RedirectToAction("EmployeeDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }

        public ActionResult EmployeeDashboard()
        {
            return View();
        }

        public ActionResult SignUpManager()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUpManager(ManagerLogin manager)
        {
            _managerRepository.Insert(manager);
            _managerRepository.Save();
            return RedirectToAction("ManagerLogin");
        }
        // Action method for ManagerLogin
        public ActionResult ManagerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManagerLogin(ManagerLogin model)
        {
            if (ModelState.IsValid)
            {
                if (IsValidManager(model.Name, model.Password))
                {
                    return RedirectToAction("ManagerDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }

        public ActionResult ManagerDashboard()
        {
            return View();
        }

        private bool IsValidEmployee(string name, string password)
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.Name == name && e.Password == password);
            return employee != null;
        }

        private bool IsValidManager(string name, string password)
        {
            var manager = _managerRepository.GetAll().FirstOrDefault(e => e.Name == name && e.Password == password);
            return manager != null;
        }

        // Additional action method for Employee details
        public ActionResult EmployeeDetails(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return View(employee);
        }

        // Additional action method for Manager details
        public ActionResult ManagerDetails(int id)
        {
            var manager = _managerRepository.GetById(id);
            return View(manager);
        }

        // Additional action method for Employee creation
        public ActionResult CreateEmployee()
        {
            return View();
        }

        // Additional action method for Manager creation
        public ActionResult CreateManager()
        {
            return View();
        }

        // Additional action method to handle form submission for creating Employee
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeLogin employee)
        {
            _employeeRepository.Insert(employee);
            _employeeRepository.Save();

            return RedirectToAction("EmployeeLogin");
        }

        // Additional action method to handle form submission for creating Manager
        [HttpPost]
        public ActionResult CreateManager(ManagerLogin manager)
        {
            _managerRepository.Insert(manager);
            _managerRepository.Save();

            return RedirectToAction("ManagerLogin");
        }
    }
}