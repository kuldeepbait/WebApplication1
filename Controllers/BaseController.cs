using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using WebApplication1.Filter;

namespace WebApplication1.Controllers
{
    [AuthFilter]
    public class BaseController : Controller
    {
    }
   
}