using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BLL.Interface;
using WebApplication1.DLL;
using WebApplication1.DLL.Repository.Interface;

namespace WebApplication1.BLL
{
    public class DepartmentBLL : IDepartmentBLL
    {
        IDepartmentRepository departRepository;
        IEmployeeRepository employeeRepository;
        public DepartmentBLL(IDepartmentRepository departRepository, IEmployeeRepository employeeRepository)
        {
            this.departRepository = departRepository;
            this.employeeRepository = employeeRepository;
        }

        public List<emp> GetemployeeList()
        {
            try
            {
               
                return departRepository.FindAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
       

    }
}
