using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DLL.Repository.Interface;

namespace WebApplication1.DLL.Repository
{
    public class DepartmentRepository : RepositoryBase<emp>, IDepartmentRepository
    {
        
        public DepartmentRepository(kuldeepEntities repositoryContext) :base(repositoryContext)
        {

        }
    }
}
