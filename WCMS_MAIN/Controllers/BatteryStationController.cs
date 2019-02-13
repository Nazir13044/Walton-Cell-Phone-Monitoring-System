using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfService2.Services;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_MAIN.HelperClass;

namespace WCMS_MAIN.Controllers
{
    public class BatteryStationController : Controller
    {
        private readonly CommonService _commonService = new CommonService();
        private readonly Dictionary<int, SessionData> _dictionary = SessionData.GetSessionValues();
        private readonly ProductionService _productionService = new ProductionService();
        private readonly LcdGlueStationService _lcdGlueStationService = new LcdGlueStationService();
        private readonly BatteryService _batteryService = new BatteryService();
        //
        // GET: /BatteryStation/
        public ActionResult BatteryComponentInfo()
        {
            return View();
        }

        public ActionResult DailyIssuedBatteryComponents()
        {
            return View();
        }

       

        public ActionResult BatteryScanner()
        {
            var userId = (long) _dictionary[2].Id;
            var projectId = (long) _dictionary[3].Id;


            return View();

        }

        public JsonResult InsertBatteryComponentInfo(tblBatteryComponentInfo batteryComponent)
        {
            var userId = (long) _dictionary[2].Id;
            var projectId = (long) _dictionary[3].Id;
            var result = new Result();
            batteryComponent.AddedBy = (int) userId;
            batteryComponent.AddedDate = DateTime.Now;

            var tblBatteryComponentInfo = new tblBatteryComponentInfo();
            try
            {
                var existUser =
                    _batteryService.ProjectNameExist(new tblBatteryComponentInfo()
                    {
                        ProjectName = batteryComponent.ProjectName
                    }).FirstOrDefault();

                if (existUser == null)
                {
                    //tblBatteryComponentInfo.PorjectId = batteryComponent.PorjectId;
                    //tblBatteryComponentInfo.ProjectName = batteryComponent.ProjectName;
                    //tblBatteryComponentInfo.LineId = batteryComponent.LineId;
                    //tblBatteryComponentInfo.LineName = batteryComponent.LineName;
                    //tblBatteryComponentInfo.PcbIssued = batteryComponent.PcbIssued;
                    //tblBatteryComponentInfo.PcbPassed = batteryComponent.PcbPassed;
                    //tblBatteryComponentInfo.PcbFailed = batteryComponent.PcbFailed;
                    //tblBatteryComponentInfo.CellIssued = batteryComponent.CellIssued;
                    //tblBatteryComponentInfo.CellPassed = batteryComponent.CellPassed;
                    //tblBatteryComponentInfo.CellFailed = batteryComponent.CellFailed;
                    
                    result = _batteryService.InsertBatteryComponentInfo(batteryComponent);
                }
                else
                {
                    result.Message = "Current Project Already Exists";
                }
            }
            catch (Exception ex)
            {
                
            }

            return Json(result);

        }

        public JsonResult GetListByPcbIssue()
        {

            var list = new List<tblBatteryComponentInfo>();
            try
            {
                list = _batteryService.GetListByPcbIssue().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLineListById(int id)
        {

            var list = new List<tblBatteryComponentInfo>();
            try
            {
                list = _batteryService.GetLineListById(id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBatteryLine(tblBatteryComponentInfo productionLine)
        
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            Result result=new Result();
            productionLine.UpdateBy = (int)userId;
            productionLine.UpdateDate = DateTime.Now;
          
            

            result = _batteryService.UpdateBatteryLine(productionLine);
            return Json(result);
        }

        public JsonResult DeleteProductionLine(int id)
        {

            var result = new Result();
            result = _batteryService.DeleteProductionLine(id);
            return Json(result);
        }


        //public JsonResult InsertProductionLine(tblBatteryComponentInfo productionLine)
        //{
        //    var userId = (long)_dictionary[2].Id;
        //    var result = new Result();

        //    if (userId != 0)
        //    {
        //        try
        //        {


        //            productionLine.ProjectName = productionLine.ProjectName;


        //            productionLine.AddedBy = userId;
        //            productionLine.AddedDate = DateTime.Now;
        //            result = _batteryService.InsertProductionLine(productionLine);
        //            return Json(result);

        //        }
        //        catch (Exception ex)
        //        {

        //            return Json(ex);
        //        }
        //    }

        //    else
        //    {
        //        return Json(new Result { Id = "0" });
        //    }



        //}




        }
    }

