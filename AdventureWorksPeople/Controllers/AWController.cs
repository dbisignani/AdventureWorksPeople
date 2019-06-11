using AdventureWorksPeople.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksPeople.Controllers
{
    [HttpClientActionFilter]
    public class AWController : Controller
    {
        public APIConnect APIConnector;
        public ActionResult AW()
        {
            return View();
        }
        // GET: AW
        public ActionResult Index()
        {
            Departments ds = new Departments(APIConnector);
            if (ds.GetDepartmentsSync())
            {
                return View(ds);
            }
            else
            {
                return View("Error");
            }
           
        }

        public JsonResult GetDepartmentEmployees(int Id)
        {
            DepartmentEmployees de = new DepartmentEmployees(APIConnector);
            string temp = de.GetEmployeesInDepartment(Id);
            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateEmployeeAddress(EmployeeAddressDepartment ead)
        {
            return null;
        }
    }
}