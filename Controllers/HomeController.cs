using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
   
    public class HomeController : Controller
    {

        TestEntities db = new TestEntities(); 

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                //  return RedirectToAction("Home", "Home");
                return RedirectToAction("Home", "Home");
                //var x = db.Employees.ToList().FirstOrDefault();

                //if(x!=null)
                //{
                //    if (x.EmpName == model.Passowrd)
                //    {

                //    }
                //    else
                //    {
                //        ModelState.AddModelError(model.UserId, "you have entered wrong password");
                //    }
                //}
                //else
                //{
                //    ModelState.AddModelError(model.UserId, "User does not exist kindly register");
                //}


            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Home");
                //var x = db.Employees.ToList().FirstOrDefault();

                //if(x!=null)
                //{
                //    if (x.EmpName == model.Passowrd)
                //    {

                //    }
                //    else
                //    {
                //        ModelState.AddModelError(model.UserId, "you have entered wrong password");
                //    }
                //}
                //else
                //{
                //    ModelState.AddModelError(model.UserId, "User does not exist kindly register");
                //}


            }
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}