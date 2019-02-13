using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCMS_ENTITY;
using WcfService2.Services;
using WCMS_COMMON;
using WCMS_MAIN.HelperClass;
using WCMS_MAIN.Models;

namespace WCMS_MAIN.Controllers
{
    public class AssemblyAttendenceController : Controller
    {


        CommonService _CommonService = new CommonService();
        Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
        //
        // GET: /AssemblyAttendence/
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CreateNewAttendence()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewAttendence(ProjectMaster master )
        {
            
            long roleId = (long)IDictionary[1].Id;


            return View();
        }



        public JsonResult GetEmployeeList(string term)
        {
            List<Employee> e_List = new List<Employee>();
            try
            {
                //Dictionary<int, CheckSessionData> IDictionary = CheckSessionData.GetSessionValues();
                // long companyId = (long)IDictionary[1].Id;
                //long locationId = (long)IDictionary[2].Id;
                //if (companyId != 0 && term != null)
                //{
                e_List = _CommonService.GetEmployeeList(term).ToList();
                // }
                //e_List = _CommonService.GetComponentList();
            }
            catch (Exception ex)
            {
                //_ErrorHelper.ErrorProcess(ex);
            }
            var objstate = e_List.Select(x => new { value = x.EmployeeId, Id = x.EmployeeId,name=x.Name }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
            
        }

	}
}