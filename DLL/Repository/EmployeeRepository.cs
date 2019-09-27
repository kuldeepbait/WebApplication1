using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApplication1.DLL.Repository.Interface;

namespace WebApplication1.DLL.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>,IEmployeeRepository
    {
       // TestEntities _repositoryContext;
        public EmployeeRepository(TestEntities repositoryContextxyz) :base(repositoryContextxyz)
        {

        }

        
    }
}
