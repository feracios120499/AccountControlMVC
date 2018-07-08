using AccountControlMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountControlMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserRepository _repository = UserRepository._Instance;
        RoleRepository _roles = RoleRepository._Instance;
        public ActionResult Index()
        {
            ViewBag.Users = _repository.GetAll();
            ViewBag.Roles = _roles.GetAll();
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            _roles.Create(new Role { Name = "123" });
            ViewBag.Roles = _roles.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                _repository.Create(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("~/Views/Error.cshtml");
            }
        }
    }
}