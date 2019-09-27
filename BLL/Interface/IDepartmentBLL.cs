using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DLL;

namespace WebApplication1.BLL.Interface
{
    public interface IDepartmentBLL
    {
        List<emp> GetemployeeList();
    }
}
