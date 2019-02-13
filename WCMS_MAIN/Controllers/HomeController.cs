using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfService2.Services;
using WCMS_MAIN.HelperClass;

namespace WCMS_MAIN.Controllers
{

    public class HomeController : Controller
    {
        CommonService _commonService = new CommonService();
        Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
        ProductionService productionService = new ProductionService();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            Dictionary<int,SessionData> IDictionary = SessionData.GetSessionValues();
            long UserRoleId = (long)IDictionary[1].Id;
            //string UserRoleName = (string)IDictionary[4].Name;
            //string UserName = (string)IDictionary[1].Id;


            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult UserDashboard()
        {
            return View();
        }



        [HttpGet]
        public JsonResult GetLineWiseProjectInfo()
        {
        
            var list = _commonService.GetLineWiseProjectInfo();
            return Json(list, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public JsonResult GetFaultyMobileList()
        {

            var list = _commonService.GetFaultyMobileList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }


	}
}