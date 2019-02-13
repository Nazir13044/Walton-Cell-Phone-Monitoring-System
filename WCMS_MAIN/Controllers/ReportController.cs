using System;
using System.Activities.Validation;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using WcfService2.Services;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.HelperClass;
using WCMS_MAIN.Models;
using HourlyTargetModel = WCMS_ENTITY.CustomModelEntity.HourlyTargetModel;

namespace WCMS_MAIN.Controllers
{
    public class ReportController : Controller
    {
        readonly ReportService reportService = new ReportService();
        readonly AdminService _adminService = new AdminService();
        readonly CommonService _commonService = new CommonService();
        readonly ProductionService _productionService = new ProductionService();
        readonly Dictionary<int, SessionData> _dictionary = SessionData.GetSessionValues();
        //
        // GET: /Report/
        public ActionResult HourlyChart()
        {
            //var cm = reportService.GetProductCount().ToList();
            return View();
        }

        public ActionResult ProductionDisplay()
        {
            //var cm = reportService.GetProductCount().ToList();
            return View();
        }
        public ActionResult Production_Display()
        {
            //var cm = reportService.GetProductCount().ToList();
            //2018-07-30
                DateTime serverTime = DateTime.Now;
                TempData["date"] = serverTime.ToString("yyyy/MM/dd");
               TempData["time"] = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View();
        }
        public ActionResult PackagingDisplay()
        {
            DateTime serverTime = DateTime.Now;
            TempData["datep"] = serverTime.ToString("yyyy/MM/dd");
            TempData["time"] = DateTime.Now.ToString();
            return View();
        }

        public ActionResult LogisticsDisplay()
        {
            //var cm = reportService.GetProductCount().ToList();
            //2018-07-30
            DateTime serverTime = DateTime.Now;
            TempData["date"] = serverTime.ToString("yyyy/MM/dd");
            return View();
        }




        public ActionResult HourlyTaregtEfficiencyReport()
        {
            return View();

        }

        public ActionResult TpLcdReport()
        {
            return View();

        }

        public ActionResult GlueStationReport()
        {
            return View();

        }


        public ActionResult OQcReport()
        {
            return View();

        }


        public ActionResult LogisticsReport()
        {
            return View();

        }


        public ActionResult AssemblyLinereport()
        {
            return View();

        }

        public ActionResult ModelBoxPackagingReport()
        {
            return View();

        }
        public ActionResult TopIssueReport()
        {
            return View();

        }

        public ActionResult ProductionQcFaultScenerio()
        {
            return View();

        }
        public ActionResult AssemblylineProductionStatus()
        {
            return View();

        }
        public ActionResult PackagingLineStatus()
        {
            return View();

        }
        public ActionResult RepairStationReport()
        {
            return View();

        }

        public ActionResult LotWiseAssemblyReport()
        {
            return View();

        }


        public ActionResult RepairAndSolderingReport()
        {
            return View();

        }
       

        public ActionResult LogisticsDataLoader(string fromdate, string todate, string model,string color)
        {

            ViewBag.fromdate = fromdate;
            ViewBag.todate = todate;
            ViewBag.model = model;
            ViewBag.color = color;
            return View();

        }




        public JsonResult GetLine()
        {
            List<tblProductionLine> list = new List<tblProductionLine>();
            try
            {
                list = _adminService.GetLineList().ToList();
            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);

        }



        //Project Wise Hourly Count
        [HttpPost]
        public JsonResult GetPassedRate(int projectId, string date)
        {
            var list1 = new List<DailyProductionModel>();

            var list = reportService.GetProductCount(projectId, date).ToList();

            var projectList = list.Select(i => i.ProjectName).Distinct().ToList();


            foreach (var projectName in projectList)
            {

                for (var i = 1; i <= 24; i++)
                {
                    var indx = list.FindIndex(x => x.TimeHour == i && x.ProjectName == projectName);
                    list1.Add(indx == -1
                        ? new DailyProductionModel { TimeHour = i, ProductCount = 0, ProjectName = projectName }
                        : new DailyProductionModel { TimeHour = i, ProductCount = list[indx].ProductCount, ProjectName = projectName });


                }

            }

            //var dataset = new List<DailyProductionModelDetail>();

            //foreach (var project in projectList)
            //{
            //    var detail = new DailyProductionModelDetail
            //    {
            //        label = project,
            //        data =
            //            list1.Where(i => i.ProjectName == project)
            //                .Select(i => i.ProductCount.ToString(CultureInfo.InvariantCulture))
            //                .ToList()
            //    };
            //    dataset.Add(detail);
            //}


            var dataset = projectList.Select(project => new DailyProductionModelDetail
            {
                label = project,
                data = list1.Where(i => i.ProjectName == project).Select(i => i.ProductCount.ToString(CultureInfo.InvariantCulture)).ToList()
            }).ToList();


            // var test = JsonConvert.SerializeObject(dataset);
            return Json(dataset, JsonRequestBehavior.AllowGet);
        }



        //Line Wise Hourly Count
        [HttpPost]
        public JsonResult GetLineWiseProduction(int projectId, string date)
        {
            var list1 = new List<DailyProductionModel>();

            var list = reportService.GetProductCount(projectId, date).ToList();

            var projectList = list.Select(i => i.ProjectName).Distinct().ToList();


            var lineList = _commonService.GetLineWiseProjectInfo().Select(a => a.LineName).Distinct().ToList();



            foreach (var lineName in lineList)
            {

                for (var i = 1; i <= 24; i++)
                {
                    var indx = list.FindIndex(x => x.TimeHour == i && x.LineName == lineName);
                    list1.Add(indx == -1
                        ? new DailyProductionModel { TimeHour = i, ProductCount = 0, LineName = lineName }
                        : new DailyProductionModel { TimeHour = i, ProductCount = list[indx].ProductCount, LineName = lineName });


                }

            }

            //var dataset = new List<DailyProductionModelDetail>();

            //foreach (var project in projectList)
            //{
            //    var detail = new DailyProductionModelDetail
            //    {
            //        label = project,
            //        data =
            //            list1.Where(i => i.ProjectName == project)
            //                .Select(i => i.ProductCount.ToString(CultureInfo.InvariantCulture))
            //                .ToList()
            //    };
            //    dataset.Add(detail);
            //}


            var dataset = lineList.Select(line => new DailyProductionModelDetail
            {
                label = line,
                data = list1.Where(i => i.LineName == line).Select(i => i.ProductCount.ToString(CultureInfo.InvariantCulture)).ToList()
            }).ToList();







            // var test = JsonConvert.SerializeObject(dataset);
            return Json(dataset, JsonRequestBehavior.AllowGet);
        }








        [HttpPost]
        public JsonResult OQcReport(int projectId, string date)
        {
            var oQcList = reportService.GetOQcReport(projectId, date).ToList();

            var oQcReportList = new List<OQcReportModel>();

            foreach (var items in oQcList)
            {

                var oQcReportModel = new OQcReportModel();

                oQcReportModel.Dates = items.Date.ToString("dd/MM/yyyy");
                oQcReportModel.BatchQuantity = items.BatchQuantity;
                oQcReportModel.SampleQuantity = items.SampleQuantity;
                oQcReportModel.TotalFault = items.TotalFault;
                oQcReportModel.FaultPercentage = items.TotalFault == 0 ? 0 : Math.Round((Convert.ToDouble(items.TotalFault) * 100) / Convert.ToDouble(items.BatchQuantity), 2);
                oQcReportModel.GiftBoxCheck = "Y";
                oQcReportModel.ImeiCheck = "Y";
                oQcReportModel.SoftwareCheck = "Y";
                oQcReportModel.PictureCheck = "Y";
                oQcReportModel.VideoCheck = "Y";
                oQcReportModel.VideoRecordingCheck = "Y";
                oQcReportModel.Mp3Check = "Y";
                oQcReportModel.Mp4Check = "Y";
                oQcReportModel.FmCheck = "Y";
                oQcReportModel.InternetCheck = "Y";
                oQcReportModel.BluetoothCheck = "Y";
                oQcReportModel.WifiCheck = "Y";
                oQcReportModel.SmsCheck = "Y";
                oQcReportModel.PhoneCallingCheck = "Y";
                oQcReportModel.SensorCheck = "Y";
                oQcReportModel.MemoryCheck = "Y";
                oQcReportModel.LockScreenCheck = "Y";
                oQcReportModel.LcdCheck = "Y";
                oQcReportModel.Reset = "Y";
                oQcReportModel.ShareitCheck = "Y";
                oQcReportModel.AppearanceCheck = "Y";
                oQcReportModel.FaultyhandsetImeiNo = items.FaultyhandsetImeiNo;
                oQcReportModel.Remarks = items.Remarks;
                oQcReportModel.Solution = "";
                oQcReportList.Add(oQcReportModel);

            }



            return Json(new { data = oQcReportList }, JsonRequestBehavior.AllowGet);
        }

           [HttpPost]
        public JsonResult GetHourlyTaregtEfficiencyReport(int projectId,int lineId, string date )
        {
            //var hourlyTargetList = reportService.GetHourlyTaregtEfficiencyReport(projectId, date).OrderBy(a=>a.HourCount).ToList();
            var hourlyTargetList = reportService.GetHourlyTaregtEfficiencyReport(projectId,lineId, date ).OrderBy(a => a.HourCount).ToList();

            var totalFunctionalFault = hourlyTargetList.Sum(i => i.FunctionalFault);
            var totalAestheticFault = hourlyTargetList.Sum(i => i.AestheticFault);


            var nowHour = hourlyTargetList.Where(a => a.HourCount == System.DateTime.Now.Hour).ToList();
            var newsList = new List<HourlyTargetModel>();
            foreach (var targetModel in hourlyTargetList)
            {
                var hourlyTargetModel = new HourlyTargetModel();

                if (totalFunctionalFault == 0 && totalAestheticFault == 0)
                {
                    targetModel.FunctionalFaultRate = 0;
                    targetModel.AestheticFaultRate = 0;
                }

                if (totalFunctionalFault != 0 && totalAestheticFault == 0)
                {
                   targetModel.FunctionalFaultRate =
                        Math.Round((double)(targetModel.FunctionalFault * 100) / totalFunctionalFault, 2);
                    targetModel.AestheticFaultRate = 0;
                }

                    if (totalFunctionalFault == 0 && totalAestheticFault != 0)
                    {
                        targetModel.FunctionalFaultRate = 0;
                       
                   targetModel.AestheticFaultRate = Math.Round((double)(targetModel.AestheticFault * 100) / totalAestheticFault, 2);
                }


                    if (totalFunctionalFault != 0 && totalAestheticFault != 0)
                {

                    targetModel.FunctionalFaultRate =
                        Math.Round((double)(targetModel.FunctionalFault * 100) / totalFunctionalFault, 2);
                    targetModel.AestheticFaultRate = Math.Round((double)(targetModel.AestheticFault * 100) / totalAestheticFault, 2);
                }


                hourlyTargetModel.HourCount = targetModel.HourCount;
                hourlyTargetModel.TimeRange = targetModel.TimeRange;
                hourlyTargetModel.TargrtedQ = targetModel.TargrtedQ;
                hourlyTargetModel.QcPassed = targetModel.QcPassed;
                hourlyTargetModel.TotalQcPassed = targetModel.TotalQcPassed;
                hourlyTargetModel.FunctionalFault = targetModel.FunctionalFault;
                hourlyTargetModel.FunctionalFaultRate = targetModel.FunctionalFaultRate;
                hourlyTargetModel.AestheticFault = targetModel.AestheticFault;
                hourlyTargetModel.AestheticFaultRate = targetModel.AestheticFaultRate;
                hourlyTargetModel.TotalReworked = targetModel.TotalReworked;
                hourlyTargetModel.TotalReworkPending = targetModel.TotalReworkPending;

                newsList.Add(hourlyTargetModel);


            }


            return Json(new { data = newsList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRegisterdeEmployee()
        {
            var list = _commonService.GetRegisterdeEmployee().ToList();


            var news = new List<tblLogin>();

            foreach (var item in list)
            {

                var test = new tblLogin();

                test.EmployeeName = item.EmployeeName;
                test.EmployeeId = item.EmployeeId;
                test.UserName = item.UserName;
                test.RoleName = item.RoleName;
                test.LineName = item.LineName;
                news.Add(test);
            }




            return Json(new { data = news }, JsonRequestBehavior.AllowGet);

        }


        //new for test
        //StationLineWise
        public JsonResult HourlyStationineWiseFault(int projectId, string date)
        {


            List<HourlyLineWiseStation> hourlyLineWiseStations = new List<HourlyLineWiseStation>();



            var list = reportService.HourlyStationineWiseFault(projectId, date).OrderBy(a => a.HourCount).ToList();




            var lineList = _commonService.GetLineWiseProjectInfo().Select(a => a.LineName).Distinct().ToList();
            string[] stations = { "FunctionalFault", "AestheticFault", "AgingFault", "PackagingFault" };

            foreach (var lineName in lineList)
            {
                var details = new List<DailyProductionModelDetail>();
                //var details1 = new List<DailyProductionModelDetail>();
                var detail = new DailyProductionModelDetail();
                foreach (var station in stations)
                {
                    var list1 = new List<DailyProductionModel>();
                    for (var i = 1; i <= 24; i++)
                    {

                        if (station.Equals("FunctionalFault"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].FunctionalFault, LineName = lineName, StationName = station });
                            //details.Add(new DailyProductionModelDetail { label = "FunctionalFault", data = list1.});
                        }
                        else if (station.Equals("AestheticFault"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].AestheticFault, LineName = lineName, StationName = station });
                        }
                        else if (station.Equals("AgingFault"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].AgingFault, LineName = lineName, StationName = station });
                        }
                        else if (station.Equals("PackagingFault"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].AgingFault, LineName = lineName, StationName = station });
                        }

                    }
                    details.Add(new DailyProductionModelDetail
                    {
                        label = station,
                        data =
                            list1.Where(i => i.StationName == station)
                                .Select(i => i.ProductCount.ToString(CultureInfo.InvariantCulture))
                                .ToList()
                    });

                    //details1.AddRange(details);

                    //hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });
                    //hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });
                }
                hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });

            }

            return Json(hourlyLineWiseStations, JsonRequestBehavior.AllowGet);

        }

        //new for line wise fault 





        //Line Wise Stations Status
        //Line Wise Stations Status 


        public JsonResult HourlyLineWiseStationsStatus(string date)
        
       {

            List<HourlyLineWiseStation> hourlyLineWiseStations = new List<HourlyLineWiseStation>();

            var list = reportService.HourlyStationineWisestatus(date).OrderBy(a => a.HourCount).ToList();
            //var list = reportService.HourlyStationineWiseFault(projectId, date).OrderBy(a => a.HourCount).ToList();



            var lineList = _commonService.GetLineWiseProjectInfo().Select(a => a.LineName).Distinct().ToList();
            string[] stations = { "IssuedComponent", "FunctionalQc", "AestheticQc", "AgingQc", "PackagingQc", "TotalReworkPending" };

            foreach (var lineName in lineList)
            {
                var details = new List<DailyProductionModelDetail>();
                //var details1 = new List<DailyProductionModelDetail>();
                var detail = new DailyProductionModelDetail();
                foreach (var station in stations)
                {
                    var list1 = new List<DailyProductionModel>();
                    for (var i = 1; i <= 24; i++)
                    {

                        if (station.Equals("IssuedComponent"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].IssuedComponent, LineName = lineName, StationName = station });
                            //details.Add(new DailyProductionModelDetail { label = "FunctionalFault", data = list1.});
                        }
                        else if (station.Equals("FunctionalQc"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].FunctionalQC, LineName = lineName, StationName = station });
                        }
                        else if (station.Equals("AestheticQc"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].AestheticQc, LineName = lineName, StationName = station });
                        }
                        else if (station.Equals("AgingQc"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].AgingQc, LineName = lineName, StationName = station });
                        }

                        else if (station.Equals("PackagingQc"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].PackagingQc, LineName = lineName, StationName = station });
                        }


                        else if (station.Equals("TotalReworkPending"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].TotalReworkPending, LineName = lineName, StationName = station });
                        }



                    }
                    details.Add(new DailyProductionModelDetail
                    {
                        label = station,
                        data =
                            list1.Where(i => i.StationName == station)
                                .Select(i => i.ProductCount.ToString(CultureInfo.InvariantCulture))
                                .ToList()
                    });

                    //details1.AddRange(details);

                    //hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });
                    //hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });
                }
                hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });

            }

            return Json(hourlyLineWiseStations, JsonRequestBehavior.AllowGet);

        }


        //Line Wise Stations Status
        //Line Wise Stations Status 


        //Production Count  For Pre Assembly Line
        //Production Count   For Pre Assembly Line

        public JsonResult DisplayProductionCount(string date)
        
        {
            var list = reportService.DisplayProductionCount(date).Where(a => a.LineCriteria.Trim() == "AssemblyLine").OrderBy(a=>a.LineId).ThenBy(
                a=>a.AddedDate).ToList();

            var list1 = new List<HourlyTargetModel>();
            var startTime = DateTime.Today.AddHours(8).Hour;
            var current = DateTime.Now.Hour;
            var divider = current - startTime;

            if (divider > 5)
            {
                divider = divider - 1;
            }


            foreach (var hourlyTargetModel in list)
            {
               

               // x.ProjectName + "-" + CommonConversion.AddOrdinal(x.OrderNuber) + " Order"

                //var projName = _commonService.GetProjectNameListByParam(new ProjectMaster()).FirstOrDefault();

                var projectId = hourlyTargetModel.CountProjectId ?? 0;

                var projName = _commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId = projectId }).FirstOrDefault();
                var a = new HourlyTargetModel();

                a.LineName = hourlyTargetModel.LineName;
                a.IssuedComponent = hourlyTargetModel.IssuedComponent;
                a.ScrewDone = hourlyTargetModel.ScrewDone;
                a.AssemblyPassed = hourlyTargetModel.AssemblyPassed;
                a.Fault = hourlyTargetModel.Fault;
                a.AddedDate = hourlyTargetModel.AddedDate;
                a.LineId = hourlyTargetModel.LineId;
                if (projName != null)
                    a.ProjectName = (projName.ProjectName).Substring(5);// + "-" +"O"+projName.OrderNuber ;                               //hourlyTargetModel.ProjectName;
                //var newc =Math.Round( Convert.ToDouble((a.AssemblyPassed)) / Convert.ToDouble(divider),2);
                

               

                list1.Add(a);
            }
           List<HourlyTargetModel>list2 = new List<HourlyTargetModel>();
            if (list1.Any())
            {
                foreach (var targetModel in list1)
                {
                    var indx = list2.FindIndex(i => i.LineId == targetModel.LineId);
                    if (indx == -1)
                    {
                        list2.Add(targetModel);
                    }
                    else
                    {
                        list2[indx].ProjectName = list2[indx].ProjectName + "," + targetModel.ProjectName;
                        list2[indx].IssuedComponent += targetModel.IssuedComponent;
                        list2[indx].ScrewDone += targetModel.ScrewDone;
                        list2[indx].AssemblyPassed += targetModel.AssemblyPassed;
                        list2[indx].Fault += targetModel.Fault;
                        //list2[indx].AverageSpeed+= targetModel.AverageSpeed;
                        //list2[indx].FaultRate += targetModel.FaultRate;
                        //if (Double.IsNaN(targetModel.FaultRate) || Double.IsInfinity(targetModel.FaultRate))
                        //{
                        //    list2[indx].FaultRate +=0;
                        //}
                  
                           
                        //if (targetModel.AddedDate > list2[indx].AddedDate)
                        //{
                        //    list2[indx].FaultRate = targetModel.FaultRate;

                    } 
                }
                if (list2.Any())
                {
                    foreach (var model in list2)
                    {
                        model.AverageSpeed = Math.Floor(Convert.ToDouble((model.AssemblyPassed)) / Convert.ToDouble(divider));

                        if (Double.IsNaN(model.AverageSpeed) || Double.IsInfinity(model.AverageSpeed))
                        {
                            model.AverageSpeed = 0;
                        }


                        model.FaultRate = Math.Floor((Convert.ToDouble((model.Fault)) / Convert.ToDouble(model.AssemblyPassed)) * 100);

                        if (Double.IsNaN(model.FaultRate) || Double.IsInfinity(model.FaultRate))
                        {
                            model.FaultRate = 0;
                        }

                    }
                }
            }


            return Json(list2, JsonRequestBehavior.AllowGet);

        }



        //Production Count  For Pre Assembly Line
        //Production Count   For Pre Assembly Line



        //line wise stations status production display


        //Production Count  For Packaging Line
        //Production Count   For Packaging Line

        public JsonResult DisplayPackagingCount(string date)
        
        {
            var list = reportService.DisplayPackagingCount(date).OrderBy(a=>a.LineName).ToList();
            var list1 = new List<HourlyTargetModel>();
            var startTime = 8;


            foreach (var hourlyTargetModel in list)
            {
                var current = DateTime.Now.Hour;
                var divider = current - startTime;

                if (divider > 5)
                {
                    divider = divider - 1;
                }


                var a = new HourlyTargetModel();

                a.LineName = hourlyTargetModel.LineName;
                a.PackagingLineId = hourlyTargetModel.PackagingLineId;
                a.ProjectName = hourlyTargetModel.ProjectName;

                




                //file.Substring(0, file.IndexOf(',')).Trim();

                if (hourlyTargetModel.ProjectName != null)
                {
                    a.ProjectName = hourlyTargetModel.ProjectName.Substring(5);
                    //a.ProjectName = a.ProjectName.Remove(a.ProjectName.Length - 10, 10);
                }


                if (a.ProjectName != null && a.ProjectName.ToLower().Contains('-'))
                {
                    a.ProjectName = a.ProjectName.Split('-')[0].Trim();
                }
                a.PackagingPass = hourlyTargetModel.PackagingPass;
                a.PackagingIssued = hourlyTargetModel.PackagingIssued; //packing issued

                a.PackagingFault = hourlyTargetModel.PackagingFault;
                //var newc =Math.Round( Convert.ToDouble((a.AssemblyPassed)) / Convert.ToDouble(divider),2);
                a.AverageSpeed = Math.Floor(Convert.ToDouble((a.PackagingPass)) / Convert.ToDouble(divider));


                if (Double.IsNaN(a.AverageSpeed))
                {
                    a.AverageSpeed = 0;
                }


                a.PackagingFaultRate = Math.Floor((Convert.ToDouble((a.PackagingFault)) / Convert.ToDouble(a.PackagingPass)) * 100);

                if (Double.IsNaN(a.PackagingFaultRate))
                {
                    a.PackagingFaultRate = 0;
                }



                list1.Add(a);
            }

            List<HourlyTargetModel> list2 = new List<HourlyTargetModel>();
            if (list1.Any())
            {
                foreach (var targetModel in list1)
                {
                    var indx = list2.FindIndex(i => i.PackagingLineId == targetModel.PackagingLineId);
                    if (indx == -1)
                    {
                        list2.Add(targetModel);
                    }
                    else
                    {
                        list2[indx].ProjectName += "," + targetModel.ProjectName;
                        list2[indx].PackagingIssued += targetModel.PackagingIssued;
                        list2[indx].PackagingPass += targetModel.PackagingPass;
                        list2[indx].PackagingFault += targetModel.PackagingFault;
                        if (Double.IsNaN(targetModel.PackagingFaultRate))
                        {
                            list2[indx].PackagingFaultRate += 0;
                        }
                        else
                        list2[indx].PackagingFaultRate += targetModel.PackagingFaultRate;
                        list2[indx].AverageSpeed+= targetModel.AverageSpeed;
                        

                    }
                }
            }



            return Json(list2, JsonRequestBehavior.AllowGet);

        }




        public JsonResult DisplayLineWiseStationsStatus(string date)
        {

            List<HourlyLineWiseStation> hourlyLineWiseStations = new List<HourlyLineWiseStation>();

            var list = reportService.HourlyStationineWisestatus(date).OrderBy(a => a.HourCount).ToList();
            //var list = reportService.HourlyStationineWiseFault(projectId, date).OrderBy(a => a.HourCount).ToList();



            var lineList = _commonService.GetLineWiseProjectInfo().Select(a => a.LineName).Distinct().ToList();
            string[] stations = { "IssuedComponent", "FunctionalQc", "AestheticQc", "TotalReworkPending" };

            foreach (var lineName in lineList)
            {
                var details = new List<DailyProductionModelDetail>();
                //var details1 = new List<DailyProductionModelDetail>();
                var detail = new DailyProductionModelDetail();
                foreach (var station in stations)
                {
                    var list1 = new List<DailyProductionModel>();
                    for (var i = 1; i <= 24; i++)
                    {

                        if (station.Equals("IssuedComponent"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].IssuedComponent, LineName = lineName, StationName = station });
                            //details.Add(new DailyProductionModelDetail { label = "FunctionalFault", data = list1.});
                        }
                        else if (station.Equals("FunctionalQc"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].FunctionalQC, LineName = lineName, StationName = station });
                        }
                        else if (station.Equals("AestheticQc"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].AestheticQc, LineName = lineName, StationName = station });
                        }
                        //else if (station.Equals("AgingQc"))
                        //{
                        //    var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                        //    list1.Add(indx == -1
                        //        ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                        //        : new DailyProductionModel { HourCount = i, ProductCount = list[indx].AgingQc, LineName = lineName, StationName = station });
                        //}

                        //else if (station.Equals("PackagingQc"))
                        //{
                        //    var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                        //    list1.Add(indx == -1
                        //        ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                        //        : new DailyProductionModel { HourCount = i, ProductCount = list[indx].PackagingQc, LineName = lineName, StationName = station });
                        //}


                        else if (station.Equals("TotalReworkPending"))
                        {
                            var indx = list.FindIndex(x => x.HourCount == i && x.LineName == lineName);
                            list1.Add(indx == -1
                                ? new DailyProductionModel { HourCount = i, ProductCount = 0, LineName = lineName, StationName = station }
                                : new DailyProductionModel { HourCount = i, ProductCount = list[indx].TotalReworkPending, LineName = lineName, StationName = station });
                        }



                    }
                    details.Add(new DailyProductionModelDetail
                    {
                        label = station,
                        data =
                            list1.Where(i => i.StationName == station)
                                .Select(i => i.ProductCount.ToString(CultureInfo.InvariantCulture))
                                .ToList()
                    });

                    //details1.AddRange(details);

                    //hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });
                    //hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });
                }
                hourlyLineWiseStations.Add(new HourlyLineWiseStation { LineName = lineName, Details = details });

            }

            return Json(hourlyLineWiseStations, JsonRequestBehavior.AllowGet);

        }



        public JsonResult GetLogisticsReport(DateTime fromdate, DateTime todate, string project)
        {

           // if (date != null && project == null)



            var list = reportService.GetLogisticsReportByDate(fromdate, todate).ToList();

                var oQcListByDate = list.GroupBy(x => new { x.Model, x.Color,x.ProjectName }).Select(n => new HourlyTargetModel
            {
                Model = n.Key.Model,
                ProjectName=n.Key.ProjectName,
                Color = n.Key.Color,
               
                
                ProductionCount =n.Count()
            }).ToList();

            


            //var oQcList = reportService.GetLogisticsReport(date, project).ToList();

            return Json(oQcListByDate, JsonRequestBehavior.AllowGet);
             
        }

      

        public JsonResult GetLogisticsReportForUpload(DateTime fromdate, DateTime todate, string project)
        {

            // if (date != null && project == null)



            var list = reportService.GetLogisticsReportByDate(fromdate, todate).Where(a=>a.Uploaded==null ).ToList();

            var oQcListByDate = list.GroupBy(x => new { x.Model, x.Color,x.Uploaded }).Select(n => new HourlyTargetModel
            {
                Model = n.Key.Model,
                Color = n.Key.Color,
                Uploaded = n.Key.Uploaded,

                ProductionCount = n.Count()
            }).ToList();

            return Json(oQcListByDate, JsonRequestBehavior.AllowGet);
        }





        public JsonResult GetLogisticsReportWithDateModel(DateTime fromdate,DateTime todate, string model,string color)
        {

            
            var list = reportService.GetLogisticsReportWithDateModel(fromdate, todate, model, color).OrderBy(a=>a.AddedDate).ToList();
            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
       
        }


        public JsonResult GetDetailsImeiData(DateTime fromdate, DateTime todate, string model, string color)
        {

         
            var list = reportService.GetDetailsImeiData(fromdate, todate, model, color).ToList();

            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;




            //return Json(list, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetTpLcdReport( int project,DateTime fromdate, DateTime todate)
        {

           // if (date != null && project == null)



            var list = reportService.GetTpLcdReport(project,fromdate, todate).ToList();
            var oQcListByDate = list.GroupBy(x => new { x.ProjectName, x.AddedBy,x.AddedName}).Select(n => new TpLcdReport
            {
                ProjectName = n.Key.ProjectName,

                AddedBy = n.Key.AddedBy,
                AddedName = n.Key.AddedName,
                ProductionCount =n.Count()
            }).ToList();


            return Json(new { data = oQcListByDate }, JsonRequestBehavior.AllowGet);
              
        
        }


        public JsonResult GetTpLcdOverAllReport(int project, string fromdate, string todate)
        {

           // if (date != null && project == null)



            var list = reportService.GetTpLcdOverAllReport(project, fromdate, todate).ToList();


          
            var overAlllist = new List<TpLcdReport>();
            foreach (var items in list)
            {
                var overAlll = new TpLcdReport();
                if (items.ProjectId != null)
                //var projectname =_commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId= (long) items.ProjectId }).FirstOrDefault();
                {
                    var projName = _commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId = Convert.ToInt64(items.ProjectId) }).FirstOrDefault();
                    overAlll.ProjectName = projName.ProjectName+"-"+projName.OrderNuber;
                
                }

               
                overAlll.Date = items.AddedDate.ToString("yyyy-MM-dd");
                overAlll.Worked = items.Worked;
                overAlll.QcPass = items.QcPass;
                overAlll.QcFail = items.QcFail;
                overAlll.FaultPercent =
                    Math.Floor((Convert.ToDouble(overAlll.QcFail)/Convert.ToDouble(overAlll.Worked))*100);
                overAlll.Reworked = items.Reworked;
                overAlll.ReworkPending = items.ReworkPending;
                overAlll.NonReparable = items.NonReparable;

                if (overAlll.NonReparable != 0 && overAlll.Reworked != 0)
                overAlll.NonReparablePercent =Math.Floor( Convert.ToDouble(overAlll.NonReparable) / Convert.ToDouble(overAlll.Reworked) * 100);
                else
                {
                    overAlll.NonReparablePercent = 0;
                }


                overAlllist.Add(overAlll);
            }


            return Json(new { data = overAlllist }, JsonRequestBehavior.AllowGet);
              
        
        }


        




        public JsonResult GetTpLcdIssuesReport(int project, DateTime fromdate, DateTime todate)
        {
            var list = reportService.GetTpLcdIssuesReport(project, fromdate, todate).ToList();         
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetTpLcdAllReport(string project, string dateFrom, string dateTo)
        {
            var list = reportService.GetTpLcdAllReport(project, dateFrom, dateTo).ToList();
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetTGlueStationReport(int project, DateTime fromdate, DateTime todate)
        {

            // if (date != null && project == null)



            var list = reportService.GetTGlueStationReport(project, fromdate, todate).ToList();
            var oQcListByDate = list.GroupBy(x => new { x.ProjectName, x.AddedBy, x.AddedName }).Select(n => new TpLcdReport
            {
                ProjectName = n.Key.ProjectName,

                AddedBy = n.Key.AddedBy,
                AddedName = n.Key.AddedName,
                ProductionCount = n.Count()
            }).ToList();


            return Json(new { data = oQcListByDate }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetGlueIssuesReport(int project, DateTime fromdate, DateTime todate)
        {
            var list = reportService.GetGlueIssuesReport(project, fromdate, todate).ToList();
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetGlueAllReport(string project, string dateFrom, string dateTo)
        {
            var list = reportService.GetGlueAllReport(project, dateFrom, dateTo).ToList();


            var overAlllist = new List<GlueStationReport>();
            foreach (var items in list)
            {
                var overAlll = new GlueStationReport();
                if (items.ProjectId != null)
                //var projectname =_commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId= (long) items.ProjectId }).FirstOrDefault();
                {
                    var projName = _commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId = Convert.ToInt64(items.ProjectId) }).FirstOrDefault();
                    overAlll.ProjectName = projName.ProjectName + "-" + projName.OrderNuber;

                }


                overAlll.Date = items.AddedDate.ToString("yyyy-MM-dd");
                overAlll.Worked = items.Worked;
                overAlll.QcPass = items.QcPass;
                overAlll.QcFail = items.QcFail;
                overAlll.FaultPercent =
                    Math.Floor((Convert.ToDouble(overAlll.QcFail) / Convert.ToDouble(overAlll.Worked)) * 100);
                overAlll.Reworked = items.Reworked;
                overAlll.ReworkPending = items.ReworkPending;
                overAlll.NonReparable = items.NonReparable;

                if (overAlll.NonReparable != 0 && overAlll.Reworked != 0)
                    overAlll.NonReparablePercent = Math.Floor(Convert.ToDouble(overAlll.NonReparable) / Convert.ToDouble(overAlll.Reworked) * 100);
                else
                {
                    overAlll.NonReparablePercent = 0;
                }


                overAlllist.Add(overAlll);
            }


            return Json(new { data = overAlllist }, JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetBoxPackingData(string fromdate, string todate, string project)
        {
            var list = reportService.GetBoxPackingData(fromdate, todate, project).ToList();

            var oQcListByDate = list.GroupBy(x => new { x.WoId }).Select(n => new PackingBoxModel
            {
                WoId = n.Key.WoId,
                //Color = n.Key.Color,
                ProductionCount = n.Count()
            }).ToList();


            return Json(oQcListByDate, JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetVsunWoDetails(string woid, string project, string fromdate, string todate)
        {
            var list = reportService.GetVsunWoDetails(woid, project,fromdate, todate).ToList();

            var jsonResult = Json(new { data = list }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

            //return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetFaultListByDate(DateTime fromdate, DateTime todate, long project, long line)
        {
            var list = reportService.GetFaultListByDate( fromdate, todate).ToList();

            var namesList1 = new List<ReworkList>();
            foreach (var tblRework in list)
            {

                if (tblRework.Issues != "")
                {
                    string[] issuesArray = tblRework.Issues.Split(',');

                    var issueList = new List<string>(issuesArray.Length);
                    issueList.AddRange(issuesArray);
                    issueList.Reverse();

                    foreach (var variable in issueList)
                    {
                        if (!String.IsNullOrEmpty(variable))
                        {
                            var issues = new ReworkList();

                            issues.Issues = variable.Trim();//Regex.Replace(variable, @"\t|\n|\r", "");
                            issues.ProjectName = tblRework.ProjectName;
                            issues.ProjectId = tblRework.ProjectId;
                            issues.LineName = tblRework.LineName;
                            issues.LineId = tblRework.LineId;
                            namesList1.Add(issues);

                        }

                    }
                }

               
            }



            if (project!=0)
            {

                var newList = namesList1.Where(a => a.ProjectId == project).GroupBy(x => new { x.Issues, x.LineName, x.ProjectName }).Select(n => new ReworkList
                {
                    Issues = n.Key.Issues,
                    ProjectName = n.Key.ProjectName,
                    LineName = n.Key.LineName,
                    //Color = n.Key.Color,
                    IssueCount = n.Count()
                }).OrderByDescending(a => a.IssueCount).ToList();
                return Json(new { data = newList }, JsonRequestBehavior.AllowGet);
            }


             if (line!=0)
            {
                var newList = namesList1.Where(a=>a.LineId==Convert.ToInt64(line)).GroupBy(x => new { x.Issues, x.LineName, x.ProjectName }).Select(n => new ReworkList
                {
                    Issues = n.Key.Issues,
                    ProjectName = n.Key.ProjectName,
                    LineName = n.Key.LineName,
                    //Color = n.Key.Color,
                    IssueCount = n.Count()
                }).OrderByDescending(a => a.IssueCount).ToList();
                return Json(new { data = newList }, JsonRequestBehavior.AllowGet);

            }

            else
            {
                var newList = namesList1.GroupBy(x => new { x.Issues, x.LineName, x.ProjectName }).Select(n => new ReworkList
                {
                    Issues = n.Key.Issues,
                    ProjectName = n.Key.ProjectName,
                    LineName = n.Key.LineName,
                    //Color = n.Key.Color,
                    IssueCount = n.Count()
                }).OrderByDescending(a => a.IssueCount).ToList();
                return Json(new { data = newList }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetProductionQcStatus(string fromdate,int projectId)
         {
             var list = reportService.GetProductionQcStatus(fromdate, projectId).ToList();


            var productionList = new List<ProductionQcFaultScenerioModel>();

            foreach (var items in list)
            {
                var production = new ProductionQcFaultScenerioModel();

                production.ProjectName = items.ProjectName;
                production.LineName = items.LineName;
                production.TotalChecked = items.TotalChecked;
                production.TotalPassed = items.TotalPassed;
                production.Fault = items.Fault;

                if (production.Fault == 0)

                    production.FaultRatio = 0;

                if (production.Fault != 0)
                {

                    production.FaultRatio = Math.Round(((Convert.ToDouble((production.Fault)) / Convert.ToDouble(production.TotalChecked)) * 100),2);
                }


                productionList.Add(production);

            }


            var result = new { productionQc = productionList };
            return Json(result, JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetFaultsData(DateTime fromdate, DateTime todate, string date, int projectId)
        {

             // WCMSEntities entity = new WCMSEntities();

            var list = reportService.GetFaultListByDate(fromdate, todate).OrderBy(a => a.LineId).ToList();

            
            var assemblyissueList = reportService.GetAssemblyLineissuesByDate(date,projectId);









            //var functionalList = list.Where(a => a.FailedStation == "FUQC").OrderBy(a => a.LineId).ToList();
            //var aestheticList = list.Where(a => a.FailedStation == "ASTQC").OrderBy(a => a.LineId).ToList();


            ////For Funcxtional Data
            //var functionalIssueList = new List<ReworkList>();
            //foreach (var tblRework in functionalList)
            //{

            //    if (!string.IsNullOrEmpty(tblRework.Issues))
            //    {
            //        string[] issuesArray = tblRework.Issues.Split(',');

            //        var issueList = new List<string>(issuesArray.Length);
            //        issueList.AddRange(issuesArray);
            //        issueList.Reverse();

            //        foreach (var variable in issueList)
            //        {
            //            if (!String.IsNullOrEmpty(variable))
            //            {
            //                var issues = new ReworkList();

            //                issues.Issues = variable.Trim(); //Regex.Replace(variable, @"\t|\n|\r", "");
            //                issues.ProjectName = tblRework.ProjectName;
            //                issues.ProjectId = tblRework.ProjectId;
            //                issues.LineName = tblRework.LineName;
            //                issues.LineId = tblRework.LineId;
            //                functionalIssueList.Add(issues);

            //            }

            //        }
            //    }


            //}



            ////For Aesthetic Data
            //var aestheticIssueList = new List<ReworkList>();
            //foreach (var tblRework in aestheticList)
            //{

            //    if (tblRework.Issues != "")
            //    {
            //        string[] issuesArray = tblRework.Issues.Split(',');

            //        var issueList = new List<string>(issuesArray.Length);
            //        issueList.AddRange(issuesArray);
            //        issueList.Reverse();

            //        foreach (var variable in issueList)
            //        {
            //            if (!String.IsNullOrEmpty(variable))
            //            {
            //                var issues = new ReworkList();

            //                issues.Issues = variable.Trim(); //Regex.Replace(variable, @"\t|\n|\r", "");
            //                issues.ProjectName = tblRework.ProjectName;
            //                issues.ProjectId = tblRework.ProjectId;
            //                issues.LineName = tblRework.LineName;
            //                issues.LineId = tblRework.LineId;
            //                aestheticIssueList.Add(issues);

            //            }

            //        }
            //    }


            //}


            //var newfunctionalList = functionalIssueList.GroupBy(x => new { x.Issues, x.LineName, x.ProjectName }).Select(n => new ReworkList
            //{
            //    Issues = n.Key.Issues,
            //    ProjectName = n.Key.ProjectName,
            //    LineName = n.Key.LineName,
            //    //Color = n.Key.Color,
            //    IssueCount = n.Count()
            //}).OrderByDescending(a => a.IssueCount).ToList();

            //var newaestheticList = aestheticIssueList.GroupBy(x => new { x.Issues, x.LineName, x.ProjectName }).Select(n => new ReworkList
            //{
            //    Issues = n.Key.Issues,
            //    ProjectName = n.Key.ProjectName,
            //    LineName = n.Key.LineName,
            //    //Color = n.Key.Color,
            //    IssueCount = n.Count()
            //}).OrderByDescending(a => a.IssueCount).ToList();


            //var result = new { functional = newfunctionalList, aesthetic = newaestheticList };
            //return Json(result, JsonRequestBehavior.AllowGet);
            //JsonConvert.SerializeObject(dt);

            return Json(JsonConvert.SerializeObject(assemblyissueList), JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetRepairAndSolderingReport(string fromdate, string todate, int projectId)
        {
            var repairList = reportService.GetRepairAndSolderingReport(fromdate, todate, projectId);
            DateTime startDate = Convert.ToDateTime(fromdate);

            DateTime endDate = Convert.ToDateTime(todate);
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);

            var reworkList = _productionService.GetIssueResult(new tblRework() { ProjectId = projectId }).Count(a => a.AddedDate >= startDate && a.AddedDate <= toDate);
            var result = new { repairList = JsonConvert.SerializeObject(repairList), reworkListCount = reworkList };
            //return Json(JsonConvert.SerializeObject(repairList), JsonRequestBehavior.AllowGet);
            return Json(result, JsonRequestBehavior.AllowGet);

        }








        public JsonResult GetFunctionalFaultsData(DateTime fromdate, DateTime todate, string date, int projectId)
        {

            // WCMSEntities entity = new WCMSEntities();
            var assemblyissueList = reportService.GetFuAssemblyLineissuesByDate(date,projectId);
            return Json(JsonConvert.SerializeObject(assemblyissueList), JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetAssemblyLineReport(string date,long line)
        {
            List<AssemblyLineInfo> list = reportService.GetAssemblyLineReport(date,line).ToList();

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }




        public JsonResult GetFullRepairStationReport(int project, DateTime fromdate, DateTime todate)
        {

            // if (date != null && project == null)
            List<RepairStationInfoModel> list ;
            list = project == 0 ? reportService.GetFullRepairStationReport(project, fromdate, todate).ToList() : reportService.GetFullRepairStationReport(project, fromdate, todate).Where(a => a.ProjectId == project).ToList();
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }


        public JsonResult IndividualRepairReport(int project, DateTime fromdate, DateTime todate)
        {
            var userId = (long)_dictionary[2].Id;
            // if (date != null && project == null)
            List<RepairStationInfoModel> list1;
            list1 = project == 0 ? reportService.GetFullRepairStationReport(project, fromdate, todate).ToList() : reportService.GetFullRepairStationReport(project, fromdate, todate).Where(a => a.ProjectId == project).ToList();

            var list = list1.Where(a => a.FinishedBy== userId).ToList();
            
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetAssemblylineProductionStatusReport(int project, string fromdate, string todate)
        {

            // if (date != null && project == null)



            var list = reportService.GetAssemblylineProductionStatusReport(project, fromdate, todate).ToList();



            var overAlllist = new List<AssemblyLineproductionStatusModel>();
            foreach (var items in list)
            {
                var overAlll = new AssemblyLineproductionStatusModel();
                //if (items.ProjectId != null)
                ////var projectname =_commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId= (long) items.ProjectId }).FirstOrDefault();
                //{
                //    var projName = _commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId = Convert.ToInt64(items.ProjectId) }).FirstOrDefault();
                //    overAlll.ProjectName = projName.ProjectName + "-" + projName.OrderNuber;

                //}

                overAlll.AddedDate=items.Date.ToString("yyyy-MM-dd");

                overAlll.IssuedInLine = items.IssuedInLine;
                overAlll.WaitingBeforeQc = items.IssuedInLine;
                overAlll.TotalQcChecked = items.TotalQcChecked;
                overAlll.QcPassed = items.QcPassed;
                overAlll.FunctionalFault = items.FunctionalFault;
                overAlll.AestheticFault = items.AestheticFault;

                overAlll.FunctionalFaultPercentage = overAlll.FunctionalFault == 0 ? 0 : Math.Round(((Convert.ToDouble(overAlll.FunctionalFault) / Convert.ToDouble(overAlll.TotalQcChecked)) * 100),2);
                overAlll.AestheticFaultFaultPercentage = overAlll.AestheticFault == 0 ? 0 : Math.Round(((Convert.ToDouble(overAlll.AestheticFault) / Convert.ToDouble(overAlll.TotalQcChecked)) * 100), 2);


                overAlll.Reworked = items.Reworked;
                overAlll.ReworkPending = items.ReworkPending;
                overAlll.Nonreparable = items.ReworkPending;

                if (overAlll.Nonreparable != 0 && overAlll.Reworked != 0)
                    overAlll.NonReparablePercentage = Math.Floor(Convert.ToDouble(overAlll.Nonreparable) / Convert.ToDouble(overAlll.Reworked) * 100);
                else
                {
                    overAlll.NonReparablePercentage = 0;
                }


                overAlllist.Add(overAlll);
            }


            return Json(new { data = overAlllist }, JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetLotWiseFaultReport(long project)
        {
            var list = reportService.GetFaultListByProject(project);
            var productionCount = list[0].TotalProduction;
                //For Funcxtional Data
            var allIssueList = new List<ReworkList>();
            foreach (var tblRework in list)
            {

                if (!string.IsNullOrEmpty(tblRework.Issues))
                {
                    string[] issuesArray = tblRework.Issues.Split(',');

                    var issueList = new List<string>(issuesArray.Length);
                    issueList.AddRange(issuesArray);
                    issueList.Reverse();

                    foreach (var variable in issueList)
                    {
                        if (!String.IsNullOrEmpty(variable))
                        {
                            var issues = new ReworkList();

                            issues.Issues = variable.Trim(); 
                            issues.ProjectName = tblRework.ProjectName;
                            issues.ProjectId = tblRework.ProjectId;
                            issues.LineName = tblRework.LineName;
                            issues.LineId = tblRework.LineId;
                            allIssueList.Add(issues);

                        }

                    }
                }


            }

            
            
            var issueWithCriteria = new List<ReworkList>();
            foreach (var reworkList in allIssueList)
            {

                var issuecriteria = new ReworkList();

                var issueCategory = _commonService.GetIssueCriteria(new Issues() {Name = reworkList.Issues.Trim()});

                if (issueCategory != null)

                {

                    issuecriteria.Issues = issueCategory.Name.Trim();
                    issuecriteria.Category = issueCategory.Category.Trim();
                    issuecriteria.Type = issueCategory.FaultType.Trim();

                    issueWithCriteria.Add(issuecriteria);

                }


            }

            var totalIssueCount = issueWithCriteria.Count();
            var faultratio = Math.Round((Convert.ToDouble(totalIssueCount)/Convert.ToDouble(productionCount)*100), 2);

            var newList = issueWithCriteria.GroupBy(a => new {a.Category, a.Type}).Select(n => new ReworkList()
            {

                Category = n.Key.Category,
                Type = n.Key.Type,
                IssueCriteriaPercent= Math.Floor(Convert.ToDouble(n.Count()) / Convert.ToDouble(totalIssueCount) * 100),
                IssueCriteriaWiseCount = n.Count()



            }).OrderByDescending(a => a.IssueCriteriaWiseCount).ToList();






            var result = new { data = newList, production = productionCount, faultr = faultratio };
            return Json(result, JsonRequestBehavior.AllowGet);



            //return Json(newList, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetPackagingProductionStatusReport(int project, string fromdate, string todate)
        {

            // if (date != null && project == null)



            var list = reportService.GetPackagingProductionStatusReport(project, fromdate, todate).ToList();



            var overAlllist = new List<AssemblyLineproductionStatusModel>();
            foreach (var items in list)
            {
                var overAlll = new AssemblyLineproductionStatusModel();
                //if (items.ProjectId != null)
                ////var projectname =_commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId= (long) items.ProjectId }).FirstOrDefault();
                //{
                //    var projName = _commonService.GetProjectNameListByParam(new ProjectMaster() { ProjectMasterId = Convert.ToInt64(items.ProjectId) }).FirstOrDefault();
                //    overAlll.ProjectName = projName.ProjectName + "-" + projName.OrderNuber;

                //}

                overAlll.AddedDate = items.Date.ToString("yyyy-MM-dd");

                overAlll.IssuedInLine = items.IssuedInLine;
               
           
                overAlll.QcPassed = items.QcPassed;
                overAlll.PackagingFault = items.PackagingFault;


                overAlll.PackagingFaultFaultPercentage = overAlll.PackagingFault == 0 ? 0 : Math.Round(((Convert.ToDouble(overAlll.PackagingFault) / Convert.ToDouble(overAlll.QcPassed)) * 100), 2);


                overAlll.Reworked = items.Reworked;
                overAlll.ReworkPending = items.ReworkPending;
                overAlll.Nonreparable = items.ReworkPending;

                if (overAlll.Nonreparable != 0 && overAlll.Reworked != 0)
                    overAlll.NonReparablePercentage = Math.Floor(Convert.ToDouble(overAlll.Nonreparable) / Convert.ToDouble(overAlll.Reworked) * 100);
                else
                {
                    overAlll.NonReparablePercentage = 0;
                }


                overAlllist.Add(overAlll);
            }


            return Json(new { data = overAlllist }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost] 
        public JsonResult GetAgingQcReport(DateTime fromdate, DateTime todate, long? project, string reportType)
        {
            object result = null;
            object agresult = null;
            object crgresult = null;
            try
            {

                var agingBatchList = new List<AgingQcStationModel>();
                var chargerBatchList = new List<AgingChargingModel>();
                if (reportType.Trim() == "AG")
                {
                    var agingReportlist = reportService.GetAgingReport(fromdate, todate, project).ToList();

                    //var passedCount = agingReportlist.Count(x => x.AgingPass == "Y");
                    //var failedCount = agingReportlist.Count(x => x.AgingPass == "N");

                    var batchList = agingReportlist.GroupBy(x => new { x.AgingBatch,x.ProjectName }).Select(n => new AgingQcStationModel
                    {
                        AgingBatch = n.Key.AgingBatch,
                        BatchProjectName = n.Key.ProjectName,
                        BatchCount =n.Count(),
                        AgingPassedCount = n.Count(x=>x.AgingPass=="Y"),
                        AgingFailedCount = n.Count(x=>x.AgingPass=="N")
                    }).ToList();

                    foreach (var items in batchList)
                    {
                        var agingBatch = new AgingQcStationModel();
                        var batchTestResult = _commonService.AgingBatcInfo(new AgingBatch() { BatchNumber = items.AgingBatch }).FirstOrDefault();
                        if (batchTestResult != null) agingBatch.AgingBatch = batchTestResult.BatchNumber;
                        if (batchTestResult != null) agingBatch.BatchProjectName = items.BatchProjectName;
                        if (batchTestResult != null) agingBatch.BatchStatus = batchTestResult.Passed;
                        if (batchTestResult != null) agingBatch.BatchCount = items.BatchCount;
                        if (batchTestResult != null) agingBatch.AgingPassedCount = items.AgingPassedCount;
                        if (batchTestResult != null) agingBatch.AgingFailedCount = items.AgingFailedCount;
                        agingBatchList.Add(agingBatch);
                    }


                    result = new { agingReportlists = agingReportlist, batchStatus = agingBatchList };

                    
                }
                if (reportType.Trim() == "CRG")
                {

                    var chargingReportlist = reportService.GetChargerAgingReport(fromdate, todate, project).ToList();



                    var batchList = chargingReportlist.GroupBy(x => new { x.ChargerBatch, x.ProjectName }).Select(n => new AgingChargingModel
                    {
                        ChargerBatch = n.Key.ChargerBatch,
                        BatchProjectName = n.Key.ProjectName,
                        BatchCount = n.Count(),
                        ChargerPassedCount = n.Count(x => x.ChargingPass == "Y"),
                        ChargerFailedCount = n.Count(x => x.ChargingPass == "N")
                    }).ToList();

                    foreach (var items in batchList)
                    {
                        var agingBatch = new AgingChargingModel();
                        var batchTestResult = _commonService.AgingBatcInfo(new AgingBatch() { BatchNumber = items.ChargerBatch }).FirstOrDefault();
                        if (batchTestResult != null) agingBatch.ChargerBatch = batchTestResult.BatchNumber;
                        if (batchTestResult != null) agingBatch.BatchProjectName = items.BatchProjectName;
                        if (batchTestResult != null) agingBatch.BatchStatus = batchTestResult.Passed;
                        if (batchTestResult != null) agingBatch.BatchCount = items.BatchCount;
                        if (batchTestResult != null) agingBatch.ChargerPassedCount = items.ChargerPassedCount;
                        if (batchTestResult != null) agingBatch.ChargerFailedCount = items.ChargerFailedCount;
                        chargerBatchList.Add(agingBatch);
                    }


                    result = new { chargerReportlists = chargingReportlist, crgbatchStatus = chargerBatchList };
                   
                }
                if (reportType.Trim() == "ALL")
                {

                    var agingBatchListAll = new List<AgBatchModel>();
                    var agingReportlist = reportService.GetAgingReport(fromdate, todate, project).ToList();

                    //var passedCount = agingReportlist.Count(x => x.AgingPass == "Y");
                    //var failedCount = agingReportlist.Count(x => x.AgingPass == "N");

                    var batchList = agingReportlist.GroupBy(x => new { x.AgingBatch, x.ProjectName }).Select(n => new AgBatchModel
                    {
                        AgingBatch = n.Key.AgingBatch,
                        BatchProjectName = n.Key.ProjectName,
                        BatchCount = n.Count(),
                        AgingPassedCount = n.Count(x => x.AgingPass == "Y"),
                        AgingFailedCount = n.Count(x => x.AgingPass == "N")
                    }).ToList();

                    foreach (var items in batchList)
                    {
                        var agingBatch = new AgBatchModel();
                        var batchTestResult = _commonService.AgingBatcInfo(new AgingBatch() { BatchNumber = items.AgingBatch }).FirstOrDefault();
                        if (batchTestResult != null) agingBatch.AgingBatch = batchTestResult.BatchNumber;
                        if (batchTestResult != null) agingBatch.BatchProjectName = items.BatchProjectName;
                        if (batchTestResult != null) agingBatch.BatchStatus = batchTestResult.Passed;
                        if (batchTestResult != null) agingBatch.BatchCount = items.BatchCount;
                        if (batchTestResult != null) agingBatch.AgingPassedCount = items.AgingPassedCount;
                        if (batchTestResult != null) agingBatch.AgingFailedCount = items.AgingFailedCount;
                        agingBatchListAll.Add(agingBatch);
                    }

                    //for charger 

                    var chargingReportlist = reportService.GetChargerAgingReport(fromdate, todate, project).ToList();



                    var cbatchList = chargingReportlist.GroupBy(x => new { x.ChargerBatch, x.ProjectName }).Select(n => new AgingChargingModel
                    {
                        ChargerBatch = n.Key.ChargerBatch,
                        BatchProjectName = n.Key.ProjectName,
                        BatchCount = n.Count(),
                        ChargerPassedCount = n.Count(x => x.ChargingPass == "Y"),
                        ChargerFailedCount = n.Count(x => x.ChargingPass == "N")
                    }).ToList();

                    foreach (var items in cbatchList)
                    {
                        var agingBatch = new AgingChargingModel();
                        var batchTestResult = _commonService.AgingBatcInfo(new AgingBatch() { BatchNumber = items.ChargerBatch }).FirstOrDefault();
                        if (batchTestResult != null) agingBatch.ChargerBatch = batchTestResult.BatchNumber;
                        if (batchTestResult != null) agingBatch.BatchProjectName = items.BatchProjectName;
                        if (batchTestResult != null) agingBatch.BatchStatus = batchTestResult.Passed;
                        if (batchTestResult != null) agingBatch.BatchCount = items.BatchCount;
                        if (batchTestResult != null) agingBatch.ChargerPassedCount = items.ChargerPassedCount;
                        if (batchTestResult != null) agingBatch.ChargerFailedCount = items.ChargerFailedCount;
                        chargerBatchList.Add(agingBatch);
                    }


                    agresult = new { agingReportlists = agingReportlist, batchStatus = agingBatchListAll };
                    crgresult = new { chargerReportlists = chargingReportlist, crgbatchStatus = chargerBatchList };

                    result = new { agingReportdata = agresult, chargerReportdata = crgresult };
                   

                }
                
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }



            return Json(result, JsonRequestBehavior.AllowGet);
           

        }


        [HttpPost]
        public JsonResult GetOQCDetailsReport(DateTime fromdate, DateTime todate, long? project, string reportType)
        {

            object result = null;
            object agresult = null;
            object crgresult = null;

            try
            {
                var oqcReportlist = reportService.GetOQCDetailsReport(fromdate, todate, project).ToList();


                var allCount = oqcReportlist.GroupBy(x => new { x.Model, x.Color, x.Project }).Select(n => new PackagingOQCModel
                {
                    Model = n.Key.Model,
                    Project = n.Key.Project,
                    Color = n.Key.Color,
                    Total = n.Count(),
                    PassedCount = n.Count(x => x.Status == "PASSED"),
                    FailedCount = n.Count(x => x.Status == "FAILED")
                }).ToList();




                if (reportType.Trim() == "DET")
                {
                  
                    result = new { ovarAllCount = allCount, details = oqcReportlist };
                }


                if (reportType.Trim() == "TOT")
                {

                    result = allCount.ToList();
                }


            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private static readonly Random Random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars,5 )
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public JsonResult CheckAndUploadImeiToOracle(DateTime fromdate, DateTime todate, string model, string color, int quantity)
        {
            var list = reportService.GetLogisticsDataToUploadOracle(fromdate, todate, model, color).ToList();
            var uploadResult = new Result();
            var logisticsUpdateresult = new Result();
            var oracletranscationCode = RandomString();
            uploadResult = reportService.CheckAndUploadImeiToOracle(fromdate, todate, model, color, quantity, list, oracletranscationCode);


            if (uploadResult.IsSuccess)
            {
                var logisticsoracleList = new List<ImeiModelUpload>();
                foreach (var items in list)
                {
                    var logisticsoracle = new ImeiModelUpload();
                    var isExists = _commonService.GetLogisticsList(new tblLogistics() { Imei1 = items.Imei1 }).FirstOrDefault(a=>a.OracleUploaded!=null&&a.OracleTransactionCode!=null);

                    if (isExists == null)
                    {
                        logisticsoracle.Imei1 = items.Imei1;
                        logisticsoracle.Imei2 = items.Imei2;
                        logisticsoracle.WO = items.WO;

                        logisticsoracleList.Add(logisticsoracle);
                    }

                }

               if (logisticsoracleList.Count > 0)
                {
                    
                    logisticsUpdateresult = _productionService.UpdateLogisticsDataForOracleUpload(list, oracletranscationCode);
                    logisticsUpdateresult.Id = "1";
                }
                else
                {
                    logisticsUpdateresult.Id = "0";
                    logisticsUpdateresult.IsSuccess = true;
                }



               

            }
            return Json(logisticsUpdateresult, JsonRequestBehavior.AllowGet);
        }


    }



    public class SalesOrderCurrencyRate
    {
    }


    public class Test
    {


        public List<string> StyringList { get; set; }
        public List<string> StyringList1 { get; set; }
        public List<string> ProjectNameList { get; set; }

    }



}