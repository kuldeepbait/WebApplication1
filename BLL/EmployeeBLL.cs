using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BLL.Interface;
using WebApplication1.DLL;
using WebApplication1.DLL.Repository.Interface;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public class EmployeeBLL : IEmployeeBLL
    {
        IEmployeeRepository employeeRepository;
        public EmployeeBLL(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void CreateEmp(EmployeeModel emp)
        {
            try
            {
                 
                Employee e = new Employee();
                // e.EmpId = emp.id;
                e.EmpName = emp.name;
                e.EmpSalary = emp.Salary;
                e.Email = emp.Email;
                e.Gender = emp.Gender;
                e.CityId = Convert.ToInt32(emp.cityId);

                this.employeeRepository.Create(e);
                this.employeeRepository.Save();
                if (emp.File.ContentLength > 0)
                {
                    int fileSize = emp.File.ContentLength;
                    var fileName = Path.GetFileName(emp.File.FileName);
                    
                    MemoryStream ms = new MemoryStream();
                    emp.File.InputStream.CopyTo(ms);
                    byte[] data = ms.ToArray();
                   
                    TestEntities test = new TestEntities();
                    EmployeeAttachment attach = new EmployeeAttachment();
                    attach.Attachment = data;
                    attach.FileName = fileName;
                    attach.EmpId = e.EmpId;
                    attach.FileType = emp.File.ContentType;
                    test.EmployeeAttachments.Add(attach);
                    test.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void DeleteEmp(int id)
        {
            try
            {
                Employee emp = employeeRepository.FindByCondition(e => e.EmpId == id).FirstOrDefault();
                this.employeeRepository.Delete(emp);
                this.employeeRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeeModel GetEmployeeDetailsById(int id)
        {
            EmployeeModel emp = new EmployeeModel();
            try
            {
                var empDetails = employeeRepository.FindByCondition(e => e.EmpId == id).FirstOrDefault();
                emp.id = id;
                emp.name = empDetails.EmpName;
                emp.Salary = Convert.ToDecimal(empDetails.EmpSalary);
                emp.Email = empDetails.Email;
                emp.Gender = empDetails.Gender;
                emp.cityId = Convert.ToString(empDetails.CityId);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }

        public List<Employee> GetemployeeList()
        {
            try
            {
                return employeeRepository.FindAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEmp(EmployeeModel emp)
        {
            try
            {
                var empObj = employeeRepository.FindByCondition(e => e.EmpId == emp.id).FirstOrDefault();
                empObj.EmpName = emp.name;
                empObj.EmpSalary = emp.Salary;
                empObj.Email = emp.Email;
                empObj.Gender = emp.Gender;
                empObj.CityId = Convert.ToInt32(emp.cityId);
                this.employeeRepository.Update(empObj);
                this.employeeRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
