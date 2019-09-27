using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FinanceController : Controller
    {
        TestEntities db = new TestEntities();

        public ActionResult FinanceHome()
        {
            FinanceModel model = new FinanceModel();
            GetCity();
            GetEmployeeList();
            model.Gender = "M";


            return View(model);
        }
        [HttpPost]
        public ActionResult FinancePost(FinanceModel model)
        {
            if (ModelState.IsValid)
            {
                Employee objEmployee = new Employee();
                objEmployee.EmpName = model.name;
                objEmployee.EmpSalary = model.Salary;
                db.Employees.Add(objEmployee);
                db.SaveChanges();
            }
            GetCity();
            GetEmployeeList();
            return View("FinanceHome");
        }
        public void GetCity()
        {
            //ViewBag.CityList = new SelectList(db.Cities.ToList(), "Id", "City");
            List<SelectListItem> CityList = new List<SelectListItem>();
            foreach (var item in db.Cities)
            {
                CityList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.CityName.ToString()
                });
            }
            ViewBag.CityList = CityList;

        }
        public void GetEmployeeList()
        {
            ViewBag.EmployeeList = db.Employees.ToList();
        }

        #region ClientSide
        public ActionResult IndexClientSide()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult GetGridInfo()
        {
            GetEmployeeList();
            return PartialView("GridDetails");
        }

        [HttpGet]
        public ActionResult GetFormDetailClientSide()
        {
            GetCity();
            return PartialView("ClientSideForm");
        }
        [HttpGet]
        public ActionResult GetFormDetails(int id)
        {
          
            EmployeeModel emp = new EmployeeModel();
            if (id>0)
            {
                var empDetails = db.Employees.Where(t => t.EmpId == id).FirstOrDefault();
                emp.id = id;
                emp.name = empDetails.EmpName;
                emp.Salary = Convert.ToDecimal(empDetails.EmpSalary);
            }
            
            GetCity();
            return PartialView("ClientSideForm", emp);
        }

        [HttpPost]
        public JsonResult DeleteGrid(int id)
        {
            Employee e = db.Employees.Where(t => t.EmpId == id).FirstOrDefault();
            db.Employees.Remove(e);
            db.SaveChanges();

            return Json("Success");
        }

        [HttpPost]
        public ActionResult SaveGridDetails(EmployeeModel emp)
        {
            //if (ModelState.IsValid)
            //{
            if (emp.id == 0)
            {
                Employee e = new Employee();
                // e.EmpId = emp.id;
                e.EmpName = emp.name;
                e.EmpSalary = emp.Salary;

                db.Employees.Add(e);
                db.SaveChanges();
            }
            else
            {
                var empObj = db.Employees.Where(t => t.EmpId == emp.id).FirstOrDefault();
                empObj.EmpName = emp.name;
                empObj.EmpSalary = emp.Salary;
                db.SaveChanges();
            }
            // }
            // GetCity();
            GetEmployeeList();
            return PartialView("GridDetails");
            //return Json("success");
        }
        #endregion
    }
}