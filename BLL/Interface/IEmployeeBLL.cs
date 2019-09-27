using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DLL;
 using WebApplication1.Models;

namespace WebApplication1.BLL.Interface
{
    public interface IEmployeeBLL
    {
        List<Employee> GetemployeeList();
        void CreateEmp(EmployeeModel emp);
        void DeleteEmp(int id);
        void UpdateEmp(EmployeeModel emp);
        EmployeeModel GetEmployeeDetailsById(int id);
    }
}
