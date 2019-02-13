using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfService2.Services;
using WCMS_COMMON;
using WCMS_MAIN.HelperClass;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.HelperClass;
using WCMS_MAIN.Models;
using HourlyTargetModel = WCMS_ENTITY.CustomModelEntity.HourlyTargetModel;

namespace WCMS_MAIN.Controllers
{
    public class LogisticController : Controller
    {
        private readonly CommonService _commonService = new CommonService();
        private readonly Dictionary<int, SessionData> _dictionary = SessionData.GetSessionValues();
        private readonly ProductionService _productionService = new ProductionService();
        private readonly ReportService _reportService = new ReportService();

        [HttpGet]
        public ActionResult LogisticRelease()
        {
            var userId = (long) _dictionary[2].Id;
            var projectId = (long) _dictionary[3].Id;

            //if (userId != 0 && projectId != 0)
            //{
            //    return View();
            //}

            //else
            //{
            //    return RedirectToAction("LogOut", "Account");


            //}
            return View();

        }
        [HttpGet]
        public ActionResult Warehouse()
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;

            //if (userId != 0 && projectId != 0)
            //{
            //    return View();
            //}

            //else
            //{
            //    return RedirectToAction("LogOut", "Account");


            //}
            return View();

        }

        [HttpGet]
        public ActionResult ImeiOracleUoload()
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;

            //if (userId != 0 && projectId != 0)
            //{
            //    return View();
            //}

            //else
            //{
            //    return RedirectToAction("LogOut", "Account");


            //}
            return View();

        }






        public JsonResult GetLogisticsitems(string boxCode)
        {
            // ProductionService productionService = new ProductionService();

            var userId = (long) _dictionary[2].Id;
            var result = new Result();



            try
            {
                var logisticsReleaselist =
              _commonService.GetLogisticsReleaselist(new tblLogisticsSentItems() { BoxCode = boxCode }).ToList();

                if (logisticsReleaselist.Count > 0 || logisticsReleaselist.Count == 20)
                {
                    result.IsSuccess = false;
                    result.Message = "Already Sent to warehouse";
                    result.Id = "1";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                else
                {



                    var logisticslist = _commonService.GetLogisticsList(new tblLogistics() { BoxCode = boxCode }).ToList();
                    if (logisticslist.Count != 0)
                    {
                        return Json(logisticslist, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "No data found";

                        return Json(result, JsonRequestBehavior.AllowGet);
                    }


                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public JsonResult LogisticItemsSend(List<tblLogisticsSentItems> logisticsSentItemses)
        {

            var userId = (long) _dictionary[2].Id;
            var projectId = (long) _dictionary[3].Id;

            Result logisticSendResult;


            try
            {
                var logisticsSendList = logisticsSentItemses.Select(items => new tblLogisticsSentItems
                {
                    BoxCode = items.BoxCode,
                    Imei1 = items.Imei1,
                    Imei2 = items.Imei2,
                    Color = items.Color,
                    Model = items.Model,
                    AddedBy = userId,
                    AddedDate = DateTime.Now
                }).ToList();
                logisticSendResult = _commonService.InsertLogisticsSendData(logisticsSendList);
                return Json(logisticSendResult);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

          

        }



        public JsonResult GetLogisticsSentItems(string boxCode)
        {
            // ProductionService productionService = new ProductionService();

            var userId = (long)_dictionary[2].Id;
            var result = new Result();

            try
            {
                var warehouseReceivedlist =
               _commonService.GetWarehouseReceivedlist(new tblWarehouse() { BoxCode = boxCode }).ToList();

                if (warehouseReceivedlist.Count > 0 || warehouseReceivedlist.Count == 20)
                {
                    result.IsSuccess = false;
                    result.Message = "Already Received";
                    result.Id = "1";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                else
                {



                    var logisticsReleaselist =
                      _commonService.GetLogisticsReleaselist(new tblLogisticsSentItems() { BoxCode = boxCode }).ToList();
                    if (logisticsReleaselist.Count != 0)
                    {
                        return Json(logisticsReleaselist, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "No data found";

                        return Json(result, JsonRequestBehavior.AllowGet);
                    }


                }
            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();

                return Json(result, JsonRequestBehavior.AllowGet);
              
            }


           


        }



        public JsonResult InsertWarehouseDate(List<tblWarehouse> warehouses)
        {

            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            var warehousesResult=new Result();

            try
            {

                var wareHouseData = warehouses.Select(items => new tblWarehouse
                {
                    BoxCode = items.BoxCode,
                    Imei1 = items.Imei1,
                    Imei2 = items.Imei2,
                    Color = items.Color,
                    Model = items.Model,
                    AddedBy = userId,
                    AddedDate = DateTime.Now
                }).ToList();
                warehousesResult = _commonService.InsertWareHouseData(wareHouseData);
                return Json(warehousesResult);
            }
            catch (Exception exception)
            {

               
               warehousesResult.Message = exception.ToString();
               return Json(warehousesResult, JsonRequestBehavior.AllowGet);
               
            }
            

        }





        public JsonResult LogisticSentAndReceivedListCount()
        {

            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;

            try
            {
                var startDate = DateTime.Today;
                var logisticsReceivedlist = _commonService.GetLogisticData().ToList();
                var logisticsSendList = _commonService.GetLogisticsReleaselist(new tblLogisticsSentItems() { AddedDate = startDate }).ToList();

                var list = new List<int>();
                list.Add(logisticsReceivedlist.Count());
                list.Add(logisticsSendList.Count());

                //var objstate = list.Select(x => new { LogisticsReceivedlist = list.Count(), logisticsSendList = logisticsSendList.Count() }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {

                throw exception;
            }
            

        }

        public JsonResult WareHouseReceivedAndSentCount()
        {

            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;


            try
            {
                var startDate = DateTime.Today;
                var logisticsSendList = _commonService.GetLogisticsReleaselist(new tblLogisticsSentItems() { AddedDate = startDate }).ToList();
                var warehouseReceivedlist =
                      _commonService.GetWarehouseReceivedlist(new tblWarehouse() { AddedDate = startDate }).ToList();

                var list = new List<int>();
                list.Add(warehouseReceivedlist.Count());
                list.Add(logisticsSendList.Count());

                //var objstate = list.Select(x => new { LogisticsReceivedlist = list.Count(), logisticsSendList = logisticsSendList.Count() }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {

                throw exception;
            }
            

        }


        public JsonResult GetLogisticsDisplayData()
        {
            try
            {

                var logisDisplays=new List<LogsticDisplay>();

                var startDate = DateTime.Today;

                var logisticsReceivedlist = _commonService.GetLogisticData().ToList().GroupBy(a => a.Model).Select(i => new { Model = i.Key, logisticsReceivedCount = i.Count() });
                var logisticsSendList = _commonService.GetLogisticsReleaselist(new tblLogisticsSentItems() { AddedDate = startDate }).OrderByDescending(a => a.AddedDate).ToList().GroupBy(a => a.Model).Select(i => new { Model = i.Key ,logisticsSendCount = i.Count() });
              
                var warehouseReceivedlist =
                      _commonService.GetWarehouseReceivedlist(new tblWarehouse() { AddedDate = startDate }).OrderByDescending(a => a.AddedDate).ToList().GroupBy(a => a.Model).Select(i => new { Model = i.Key, warehouseReceivedCount = i.Count() });


                foreach (var items in logisticsReceivedlist )
                {
                    var a = new LogsticDisplay();
                    a.Model = items.Model;
                    a.LogisticReceived = items.logisticsReceivedCount;
                    logisDisplays.Add(a);

                }


                foreach (var items in logisticsSendList)
                {
                    var a = new LogsticDisplay();

                    var b = logisDisplays.FindIndex(x => x.Model == items.Model);
                    if (b >= 0)
                    {
                        logisDisplays[b].LogisticSent = items.logisticsSendCount;
                        //logisDisplays[b].LogisticsLastSent = items;

                    }
                }

                foreach (var items in warehouseReceivedlist)
                {
                    var a = new LogsticDisplay();

                    var b = logisDisplays.FindIndex(x => x.Model == items.Model);
                    if (b >= 0)
                    {
                        logisDisplays[b].WarehouseReceived = items.warehouseReceivedCount;


                    }
                }
                var logisDisplays1 = new List<LogsticDisplay>();
                foreach (var logsticDisplay in logisDisplays)
                {
                    var ax = new LogsticDisplay();
                    var awarehouseReceivedate = _commonService.GetWarehouseReceivedlist(new tblWarehouse() { AddedDate = startDate }).Where(a => a.Model == logsticDisplay.Model).OrderByDescending(a => a.AddedDate).Select(a => a.AddedDate).FirstOrDefault();
                    var logisticsSenddate = _commonService.GetLogisticsReleaselist(new tblLogisticsSentItems() { AddedDate = startDate }).Where(a => a.Model == logsticDisplay.Model).OrderByDescending(a => a.AddedDate).Select(a => a.AddedDate).FirstOrDefault();
                    ax.Model = logsticDisplay.Model;

                    ax.LogisticReceived = logsticDisplay.LogisticReceived;
                    ax.LogisticSent = logsticDisplay.LogisticSent;
                    ax.WarehouseReceived = logsticDisplay.WarehouseReceived;
                   // ax.LogisticsLastSent = (Convert.ToDateTime(logisticsSenddate)).ToString("hh:mm tt");
                    ax.LogisticsLastSent = (Convert.ToDateTime(logisticsSenddate)).ToString("dd/MM/yyyy hh:mm:ss tt");
                    ax.WarehouseLastReceived = (Convert.ToDateTime(awarehouseReceivedate)).ToString("dd/MM/yyyy hh:mm:ss tt");
                    //ax.WarehouseLastReceived = (Convert.ToDateTime(awarehouseReceivedate)).ToString("hh:mm tt");

                    logisDisplays1.Add(ax);
                }


                //var warehouseReceivedate = _commonService.GetWarehouseReceivedlist(new tblWarehouse() { AddedDate = startDate }).OrderByDescending(a => a.AddedDate).Select(a => a.AddedDate).FirstOrDefault();
                //var date = Convert.ToDateTime(warehouseReceivedate);
                //strdate.tostring("hh:mm tt");
                //var list = new List<object>();
                //list.Add(logisticsReceivedlist.Count());
               // list.Add(logisticsSendList);
                //list.Add(warehouseReceivedlist.Count());
               // list.Add(date.ToString("hh:mm tt"));
               

                //var objstate = list.Select(x => new { LogisticsReceivedlist = list.Count(), logisticsSendList = logisticsSendList.Count() }).ToList();
                return Json(logisDisplays1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public JsonResult GetLogisticsReportFroOracleUpload(DateTime fromdate, DateTime todate, string project)
        {

            // if (date != null && project == null)



            var list = _reportService.GetLogisticsReportByDate(fromdate, todate).ToList();

            var oQcListByDate = list.GroupBy(x => new { x.Model, x.Color, x.ProjectName }).Select(n => new HourlyTargetModel
            {
                Model = n.Key.Model,
                ProjectName = n.Key.ProjectName,
                Color = n.Key.Color,
                ProductionCount = n.Count(),
                OracleUploadedCount = n.Count(a=>a.OracleUploaded=="Y")
            }).ToList();




            //var oQcList = reportService.GetLogisticsReport(date, project).ToList();

            return Json(oQcListByDate, JsonRequestBehavior.AllowGet);

        }

    }
}