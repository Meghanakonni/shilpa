using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Models.Repository;

namespace Project.Controllers
{
    public class RegisterController : Controller
    {
        
        IRepository<Register> _registerRepository = null;

        public RegisterController()
        {
            _registerRepository = new Repository<Register>();
        }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegister(Register register)
        {
            _registerRepository.Insert(register);
            _registerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}