using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfService2.Services;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_MAIN.HelperClass;
using WCMS_MAIN.Models;


namespace WCMS_MAIN.Controllers
{
    public class ProjectController : Controller
    {
        readonly CommonService _commonService = new CommonService();
        readonly Dictionary<int, SessionData> _dictionary = SessionData.GetSessionValues();
        //
        // GET: /Project/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetComponentList(string term)
        {
            List<BomList> eList;
            try
            {

                eList = _commonService.GetComponentList().Where(x => x.ComponentName.ToLower().Contains(term.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            var objstate = eList.Select(x => new { value = x.ComponentName, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }

        //for project Name Auto Complete

        public JsonResult GetProjectNameList(string term)
        {
            List<ProjectMaster> eList;
            try
            {
                eList = _commonService.GetProjectNameList().Where(x => x.ProjectName.ToLower().Contains(term.ToLower())).OrderBy(x => x.ProjectName).ThenByDescending(x => x.OrderNuber).ToList();

            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            var objstate = eList.Select(x => new { value = x.ProjectName + "-" + CommonConversion.AddOrdinal(x.OrderNuber) + " Order", Id = x.ProjectMasterId, display = x.DisplaySize, ram = x.Ram, rom = x.Rom }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateProjectBomList(List<ProjectBomList> _projectBomLists)
        {


            var result = new Result();
            var userId = (long)_dictionary[2].Id;


            var oProjectBomList = new ProjectBomList();


            if (userId != 0)
            {

                try
                {
                    foreach (ProjectBomList items in _projectBomLists)
                    {
                        oProjectBomList.ProjectMasterId = items.ProjectMasterId;
                        oProjectBomList.ProjectName = items.ProjectName;
                        oProjectBomList.ComponentId = items.ComponentId;
                        oProjectBomList.ComponentName = items.ComponentName;
                        oProjectBomList.ComponentNumber = items.ComponentNumber;
                        oProjectBomList.IcVendor = items.IcVendor;
                        oProjectBomList.Quantity = items.Quantity;
                        oProjectBomList.Remarks = items.Remarks;
                        oProjectBomList.AddedBy = userId;
                        oProjectBomList.AddedDate = DateTime.Now;
                        result = _commonService.InsertProjectBomList(oProjectBomList);


                    }
                }
                catch (Exception)
                {

                    return Json("Error");
                }

                return Json(result);
            }

            else
            {
                return Json(new Result { Id = "0" });
            }

        }

        public JsonResult GetProjec()
        {
            var eList = new List<ProjectMaster>();
            try
            {
                eList = _commonService.GetProjectNameList().ToList();

            }
            catch (Exception ex)
            {

            }
            var objstate = eList.Select(x => new { value = x.ProjectName + "-" + CommonConversion.AddOrdinal(x.OrderNuber) + " Order", Id = x.ProjectMasterId, display = x.DisplaySize, ram = x.Ram, rom = x.Rom }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetColors()
        
        {
            var eList = new List<tblColors>();
            try
            {
                eList = _commonService.GetColors().ToList();

            }
            catch (Exception ex)
            {

            }
            var objstate = eList.Select(x => new { value = x.Name, Id =x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }






        public JsonResult CreateDailyPackagingList(List<tblDailyPacking> dailyPackings)
        {

            var result = new Result();
            var oDailyPacking = new tblDailyPacking();
            var userId = (long)_dictionary[2].Id;
            if (userId != 0)
            {
                try
                {
                    foreach (tblDailyPacking items in dailyPackings)
                    {
                        oDailyPacking.ProjectId = items.ProjectId;
                        oDailyPacking.ProjectName = items.ProjectName;
                        oDailyPacking.ComponentId = items.ComponentId;
                        oDailyPacking.ComponentName = items.ComponentName;
                        oDailyPacking.ComponentName = items.ComponentNumber;
                        oDailyPacking.IcVendor = items.IcVendor;
                        oDailyPacking.Quantity = items.Quantity;
                        oDailyPacking.Remarks = items.Remarks;
                        oDailyPacking.AddedBy = userId;
                        result = _commonService.CreateDailyPackagingList(oDailyPacking);


                    }
                }
                catch (Exception)
                {

                    return Json("Error");
                }

                return Json(result);
            }

            else
            {
                return Json(new Result { Id = "0" });
            }

        }

        [HttpGet]
        public JsonResult GetAllComponentList()
        {
            List<BomList> eList;
            try
            {
                eList = _commonService.GetComponentList().ToList();
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            var objstate = eList.Select(x => new { value = x.ComponentName + '-' + x.ComponentCode, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllIssueList()
        {
            List<Issues> eList;
            try
            {
                eList = _commonService.GetAllIssueList().ToList();
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            var objstate = eList.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetProjecFormvsunDb()
        {
            var eList = new List<F_Projects>();
            try
            {
                eList = _commonService.GetProjecFormvsunDb().ToList();

            }
            catch (Exception ex)
            {

            }
            var objstate = eList.Select(x => new { value = x.T_Project, Id = x.T_Project }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }


    }
}