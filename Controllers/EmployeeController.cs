using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BLL.Interface;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : BaseController
    {
        TestEntities db = new TestEntities();
        IDepartmentBLL _departmentBLL;
        IEmployeeBLL _employeeBLL;
        public  EmployeeController(IEmployeeBLL employeeBLL,IDepartmentBLL departmentBLL)
        {
            _employeeBLL = employeeBLL;
            _departmentBLL = departmentBLL;
        }

        #region Server Side
        // GET: Employee
        public ActionResult Index()
        {
            GetCity();
            GetEmployeeList();
            return View();
        }
        [HttpPost]
        public ActionResult SavedFormDetailsServerSide(EmployeeModel emp)
        {
            if(ModelState.IsValid)
            {
                Employee e = new Employee();
                e.EmpId = emp.id;
                e.EmpName = emp.name;
                e.EmpSalary = emp.Salary;

                db.Employees.Add(e);
                db.SaveChanges();
            }
            GetCity();
            GetEmployeeList();


            return View("Index");
        }
        #endregion
        #region Client Side
        public ActionResult IndexClientSide()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult GetGridInfo()
        {

            var model = GetEmployeeList();
            return PartialView("GridDetails", model);
        }
        [HttpGet]
        public ActionResult GetFormDetailClientSide()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.listCity= GetCity();
            return PartialView("ClientSideForm", emp);
        }
        [HttpGet]
        public ActionResult EditDetailsClientSide(int id)
        {
            var emp = id == 0 ?  new EmployeeModel() : _employeeBLL.GetEmployeeDetailsById(id);
            if(id>0)
            {
                emp.listAttachment = db.EmployeeAttachments.Where(a => a.EmpId == id).ToList();
            }
            emp.listCity = GetCity();
            return PartialView("ClientSideForm", emp);
        }
        
        public FileResult DownLoad(int attachId)
        {
            var attach = db.EmployeeAttachments.Where(a => a.Id == attachId).FirstOrDefault();
            return File(attach.Attachment, System.Net.Mime.MediaTypeNames.Application.Octet, attach.FileName);
        }
        [HttpPost]
        public ActionResult SaveGridDetails(EmployeeModel emp)
        {
            //if (ModelState.IsValid)
            //{
            if (emp.id == 0)
            {
                _employeeBLL.CreateEmp(emp);
            }
            else
            {
                _employeeBLL.UpdateEmp(emp);
            }
            // }
            EmployeeModel empM = new EmployeeModel();
            empM.listCity = GetCity();
            GetEmployeeList();
            return View("ClientSideForm", empM);
          //  return Json("success");
        }
        [HttpPost]
        public JsonResult DeleteGrid(int id)
        {
            _employeeBLL.DeleteEmp(id);
            return Json("Success");
        }
        #endregion
        public List<WebApplication1.DLL.Employee> GetEmployeeList()
        {
            var data = _employeeBLL.GetemployeeList(); ;
            var data1 = _departmentBLL.GetemployeeList(); ;
            return data;
           // return db.Employees.ToList().Select(m=> new Employee() { EmpId = m.EmpId, EmpName = m.EmpName, EmpSalary = Convert.ToDecimal(m.EmpSalary) }).ToList();
        }
        public List<City> GetCity()
        {

            //  db.Cities.ToList().Select(c => new City { Id = c.Id, CityName = c.CityName }).ToList();
            //inner join
            List<City> listCity = (from A in db.Cities.ToList()
                                   join B in db.Employees.ToList() on A.Id equals B.CityId
                                   select new City()
                                   {
                                       Id = A.Id,
                                       CityName = A.CityName
                                   }).ToList();
            //left join
            //List<City> listCityLeft = (from A in db.Cities.ToList()
            //                       join B in db.Employees.ToList() on A.Id equals B.CityId
            //                       into B from xyz in B.DefaultIfEmpty()
            //                        select new City()
            //                       {
            //                           Id = A.Id,
            //                           CityName = A.CityName
            //                       }).ToList();

            //right join
            //List<City> listCityRight = (from A in db.Employees.ToList()
            //                            join B in db.Cities.ToList() on A.CityId equals B.Id
            //                            into B
            //                            from xyz in B.DefaultIfEmpty()
            //                            select new City
            //                            {
            //                                Id = Convert.ToInt32(A.CityId),
            //                                CityName = xyz.CityName
            //                            }).ToList();

            return listCity;
           
        }
    }
}