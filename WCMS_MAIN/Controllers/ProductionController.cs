using System;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using WcfService2.Services;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.HelperClass;
using WCMS_MAIN.Models;

namespace WCMS_MAIN.Controllers
{
    public class ProductionController : Controller
    {
        readonly CommonService _commonService = new CommonService();
        readonly Dictionary<int, SessionData> _dictionary = SessionData.GetSessionValues();
        readonly ProductionService _productionService = new ProductionService();

        [HttpGet]
        public ActionResult FunctionalQc()
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
        public ActionResult AestheticQc()
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
        public ActionResult AgingQc()
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;

            if (userId != 0 && projectId != 0)
            {
                return View();
            }

            else
            {
                return RedirectToAction("LogOut", "Account");

            }

        }


        [HttpGet]
        public ActionResult NewAgingQc()
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;

            if (userId != 0)
            {
                return View();
            }

            else
            {
                return RedirectToAction("LogOut", "Account");

            }
        }

        [HttpGet]
        public ActionResult AgingChargingQc()
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;

            if (userId != 0)
            {
                return View();
            }

            else
            {
                return RedirectToAction("LogOut", "Account");


            }


        }







        [HttpGet]
        public ActionResult PackegingQc()
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            var LineId = (long)_dictionary[5].Id;
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
        public ActionResult PackegingAesthQc()
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
        public ActionResult PackegingOQc()
        {
            //var userId = (long)_dictionary[2].Id;
            //var projectId = (long)_dictionary[3].Id;

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
        public ActionResult PackegingBatch()
        {
            //var userId = (long)_dictionary[2].Id;
            //var projectId = (long)_dictionary[3].Id;

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
        public ActionResult NewPackagingOqc()
        {
            //var userId = (long)_dictionary[2].Id;
            //var projectId = (long)_dictionary[3].Id;

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
        public ActionResult UpdateOqcBatch()
        {
            //var userId = (long)_dictionary[2].Id;
            //var projectId = (long)_dictionary[3].Id;

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
        public ActionResult PackagingBatchStation()
        {
            //var userId = (long)_dictionary[2].Id;
            //var projectId = (long)_dictionary[3].Id;

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
        public ActionResult ReworkStation()
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
        public ActionResult ReworkHistory()
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
        public ActionResult TplcdProduction()
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;

            if (userId != 0 && projectId != 0)
            {
                return View();
            }

            else
            {
                return RedirectToAction("LogOut", "Account");
            }

        }

        public JsonResult GetProjectName(string projectId)
        {
            var name = "";
            var projectName =
                _commonService.GetProjectNameListByParam(new ProjectMaster()
                {
                    ProjectMasterId = Convert.ToInt64(projectId)
                }).FirstOrDefault();

            if (projectName != null)
            {
                name = projectName.ProjectName + "-" + CommonConversion.AddOrdinal(projectName.OrderNuber);
            }

            return Json(name, JsonRequestBehavior.AllowGet);
        }



        #region Packaging Stations Operations




        #region Insert Functional Qc Station

        public JsonResult InsertFunctionalQcStation(List<ProductionMaster> statusList, List<tblRework> reworkList)
        {
            // WCMSEntities entities = new WCMSEntities();
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            Result result = new Result();
            if (userId != 0 && lineId != 0)
            {
                try
                {
                    var productionMaster = new ProductionMaster();
                    var listProductionMaster = new List<ProductionMaster>();
                    foreach (var items in statusList)
                    {
                        var pcbStation = _commonService.GetPCBInfo(new tblDailyIssuedComponents() { ComponentCode = items.MobileCode }).FirstOrDefault();

                        var screwStation = _commonService.GetScrewStationInfo(new tblScrew() { MobileCode = items.MobileCode.Trim() }).FirstOrDefault();
                        var isExists =
                            _commonService.ProductionMasterInfo(new ProductionMaster { MobileCode = items.MobileCode.Trim() })
                                .Any();

                        if (isExists)
                        {
                            productionMaster.MobileCode = items.MobileCode;
                            productionMaster.Passed = items.Passed.ToUpper();
                            productionMaster.QcStation = items.QcStation;
                            productionMaster.FunctionalBy = userId;
                            productionMaster.FunctionalAD = DateTime.Now;
                            listProductionMaster.Add(productionMaster);
                            result = _productionService.UpdateQcStatusHistory(listProductionMaster);
                            //Insert to rework table
                            if (result.IsSuccess == true && items.Passed.ToUpper() == "N")
                            {
                                var Reresult = new Result();
                                var rework = new tblRework();

                                foreach (tblRework item in reworkList)
                                {
                                    rework.LineId = lineId;
                                    rework.ProjectId = screwStation != null ? screwStation.ProjectId : 0; //projectId;
                                    rework.MobileCode = item.MobileCode;
                                    rework.Issues = item.Issues;
                                    rework.FailedStation = item.FailedStation;
                                    rework.Status = "P";
                                    rework.AddedBy = userId;
                                    rework.AddedDate = DateTime.Now;
                                    Reresult = _productionService.InsertFunctionalRework(rework);
                                }
                            }
                        }

                        else
                        {
                            if (screwStation != null)
                            {
                                productionMaster.MobileCode = items.MobileCode.Trim();
                                productionMaster.Passed = items.Passed.ToUpper().Trim();
                                productionMaster.QcStation = items.QcStation;
                                productionMaster.LineId = lineId;
                                productionMaster.ProjectId = pcbStation != null ? pcbStation.ProjectId : screwStation.ProjectId;
                                productionMaster.ProjectName = screwStation.ProjectName;

                                productionMaster.AddedBy = userId;
                                productionMaster.AddedDate = DateTime.Now;
                                productionMaster.FunctionalBy = userId;
                                productionMaster.FunctionalAD = DateTime.Now;
                                //Insert data
                                result = _productionService.InsertFunctionalQcStatus(productionMaster);
                                if (result.IsSuccess == true && items.Passed.ToUpper() == "N")
                                {
                                    var Reresult = new Result();
                                    var rework = new tblRework();

                                    foreach (tblRework item in reworkList)
                                    {
                                        rework.LineId = lineId;
                                        rework.ProjectId = screwStation.ProjectId; //projectId;
                                        rework.MobileCode = item.MobileCode;
                                        rework.Issues = item.Issues;
                                        rework.FailedStation = item.FailedStation;
                                        rework.Status = "P";
                                        rework.AddedBy = userId;
                                        rework.AddedDate = DateTime.Now;
                                        Reresult = _productionService.InsertFunctionalRework(rework);
                                    }
                                }
                            }

                            else
                            {
                                result.Message = "Item Not Scanned At Screw Station!";
                                return Json(result);
                            }

                        }
                    }
                }
                catch (Exception exception)
                {

                    return Json(new Result { Message = exception.ToString() });
                }

            }

            else
            {
                return Json(new Result { Id = "0" });
            }


            return Json(result);
        }

        #endregion

        #region Insert Aesthetic Qc Station
        public JsonResult InsertAestheticQcStation(List<ProductionMaster> statusList, List<tblRework> reworkList)
        {
            WCMSEntities entities = new WCMSEntities();

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            Result result = new Result();


            try
            {
                var productionMaster = new ProductionMaster();
                var listProductionMaster = new List<ProductionMaster>();

                foreach (var items in statusList)
                {
                    //var pcbStation = _commonService.GetPCBInfo(new tblDailyIssuedComponents() { ComponentCode = items.MobileCode }).FirstOrDefault();
                    //var isExists = _commonService.ProductionMasterInfo(new ProductionMaster { MobileCode = items.MobileCode }).Any();
                    //entities.ProductionMaster.Any(a => a.MobileCode == items.MobileCode);
                    //check if previously passed
                    //var previousStatus = entities.ProductionMaster.FirstOrDefault(a => a.MobileCode == items.MobileCode);
                    //entities.ProductionMaster.FirstOrDefault(a => a.MobileCode == items.MobileCode);

                    var previousStation = _commonService.ProductionMasterInfo(new ProductionMaster { MobileCode = items.MobileCode.Trim() }).FirstOrDefault();
                    //if (previousStatus != null && (isExists && previousStatus.Passed.ToUpper() == "N") && previousStatus.QcStation != "ASTQC")
                    //{
                    //    result.Message = "Item  not passed from functional QC station.";
                    //    return Json(result);

                    //}
                    //if (previousStatus != null && (isExists) && (previousStatus.QcStation.Trim() != "FUQC" && previousStatus.QcStation.Trim() != "ASTQC") && items.QcStation.Trim() == "ASTQC")
                    //{
                    //    result.Message = "Item not checked at Functional QC station.";
                    //    return Json(result);

                    //}
                    //if (previousStatus == null || !isExists)
                    //{
                    //    result.Message = "Item Not Checked at Functional QC station.";
                    //    return Json(result);

                    //}

                    if (items.QcStation == "ASTQC" && previousStation != null)
                    {
                        // var previousStatus = entities.ProductionMaster.FirstOrDefault(a => a.MobileCode == items.MobileCode);
                        productionMaster.AestheticBy = userId;
                        productionMaster.QcStation = items.QcStation;
                        productionMaster.MobileCode = items.MobileCode.Trim();
                        productionMaster.Passed = items.Passed.ToUpper();
                        productionMaster.AestheticAD = DateTime.Now;
                        productionMaster.LineId = lineId;
                        // productionMaster.Imei1 = items.Imei1;
                        //productionMaster.Imei2 = items.Imei2;
                        listProductionMaster.Add(productionMaster);
                        result = _productionService.UpdateQcStatusHistory(listProductionMaster);


                        //batching query will start from here
                        //batching query will start from here 


                        if (result.IsSuccess == true && items.Passed.ToUpper() == "Y" &&
                            items.QcStation == "ASTQC")
                        {
                            var producList = new List<ProductionMaster>();

                            var startDate = DateTime.Today;
                            var endDate = startDate.AddDays(1).AddTicks(-1);


                            //var aestheticListCount =aestheticList.Count(a => a.AddedDate >= startDate && a.AddedDate <= endDate);

                            var aestheticListCount = _commonService.
                                ProductionMasterInfo(new ProductionMaster
                                {
                                    QcStation = items.QcStation,
                                    ProjectId = previousStation.ProjectId,// projectId,
                                    Passed = items.Passed.ToUpper()
                                })
                                .Count(
                                    a =>
                                        a.AestheticAD >= startDate && a.AestheticAD <= endDate &&
                                        string.IsNullOrEmpty(a.AgingBatchNumber));


                            var aestheticListCountList = _commonService.
                                ProductionMasterInfo(new ProductionMaster
                                {
                                    QcStation = items.QcStation,
                                    ProjectId = previousStation.ProjectId,// projectId,
                                    Passed = items.Passed.ToUpper()
                                })
                                .Where(
                                    a =>
                                        a.AestheticAD >= startDate && a.AestheticAD <= endDate &&
                                        string.IsNullOrEmpty(a.AgingBatchNumber)).ToList();


                            if (aestheticListCount == 100)
                            {


                                var batchNumber = RandomString();

                                var agingSaveBatchResult = new Result();
                                var agingBatchInfo = new AgingBatchInfo();
                                agingBatchInfo.BatchNo = "WP-" + batchNumber;
                                agingBatchInfo.ProjectId = previousStation.ProjectId;// projectId;
                                agingBatchInfo.LineId = aestheticListCountList[0].LineId;
                                agingBatchInfo.AddedBy = userId;
                                agingBatchInfo.AddedDate = DateTime.Now;

                                Result agingBatchResult = _productionService.InsertAgingcBatchInfo(agingBatchInfo);

                                if (agingBatchResult.IsSuccess)
                                {
                                    foreach (var aestheticList in aestheticListCountList)
                                    {
                                        var batchingProduction = new ProductionMaster();

                                        batchingProduction.ProductionId = aestheticList.ProductionId;
                                        batchingProduction.MobileCode = aestheticList.MobileCode;
                                        batchingProduction.AgingBatchNumber = agingBatchInfo.BatchNo;

                                        producList.Add(batchingProduction);
                                    }


                                    agingSaveBatchResult =
                                        _productionService.UpdateProductionBatchStatus(producList);


                                }
                            }

                        }





                        //Insert to rework table

                        if (result.IsSuccess == true && items.Passed.ToUpper() == "N")
                        {
                            var Reresult = new Result();
                            var rework = new tblRework();

                            foreach (tblRework item in reworkList)
                            {
                                rework.LineId = lineId;
                                rework.ProjectId = previousStation.ProjectId;// projectId;
                                rework.MobileCode = item.MobileCode;
                                rework.Issues = item.Issues;
                                rework.FailedStation = item.FailedStation;
                                rework.Status = "P";
                                rework.AddedBy = userId;
                                rework.AddedDate = DateTime.Now;

                                Reresult = _productionService.InsertFunctionalRework(rework);

                            }
                        }
                    }


                    else
                    {
                        result.Message = "Item Not Scanned At Functional QC !";
                        return Json(result);
                    }




                    //else
                    //{


                    //    if (pcbStation != null)
                    //    {
                    //        productionMaster.ProjectId = pcbStation.ProjectId; //projectId;
                    //        productionMaster.AestheticBy = userId;
                    //        productionMaster.AestheticAD = DateTime.Now;
                    //        productionMaster.MobileCode = items.MobileCode;
                    //        productionMaster.Passed = items.Passed.ToUpper();
                    //        productionMaster.QcStation = items.QcStation;
                    //        productionMaster.LineId = lineId;
                    //        productionMaster.ProjectName = pcbStation.ProjectName;

                    //        //Insert data
                    //        result = _productionService.InsertFunctionalQcStatus(productionMaster);


                    //        //batching query will start from here
                    //        //batching query will start from here 


                    //        if (result.IsSuccess == true && items.Passed.ToUpper() == "Y" &&
                    //            items.QcStation == "ASTQC")
                    //        {
                    //            var producList = new List<ProductionMaster>();

                    //            var startDate = DateTime.Today;
                    //            var endDate = startDate.AddDays(1).AddTicks(-1);


                    //            //var aestheticListCount =aestheticList.Count(a => a.AddedDate >= startDate && a.AddedDate <= endDate);

                    //            var aestheticListCount = _commonService.
                    //                ProductionMasterInfo(new ProductionMaster
                    //                {
                    //                    QcStation = items.QcStation,
                    //                    ProjectId = pcbStation != null ? pcbStation.ProjectId : projectId,// projectId,
                    //                    Passed = items.Passed.ToUpper()
                    //                })
                    //                .Count(
                    //                    a =>
                    //                        a.AestheticAD >= startDate && a.AestheticAD <= endDate &&
                    //                        string.IsNullOrEmpty(a.AgingBatchNumber));


                    //            var aestheticListCountList = _commonService.
                    //                ProductionMasterInfo(new ProductionMaster
                    //                {
                    //                    QcStation = items.QcStation,
                    //                    ProjectId = pcbStation != null ? pcbStation.ProjectId : projectId, //projectId,
                    //                    Passed = items.Passed.ToUpper()
                    //                })
                    //                .Where(
                    //                    a =>
                    //                        a.AestheticAD >= startDate && a.AestheticAD <= endDate &&
                    //                        string.IsNullOrEmpty(a.AgingBatchNumber)).ToList();


                    //            if (aestheticListCount == 100)
                    //            {


                    //                var batchNumber = RandomString();

                    //                var agingSaveBatchResult = new Result();
                    //                var agingBatchInfo = new AgingBatchInfo();
                    //                agingBatchInfo.BatchNo = "WP-" + batchNumber;
                    //                agingBatchInfo.ProjectId = pcbStation != null ? pcbStation.ProjectId : projectId;// projectId;
                    //                agingBatchInfo.LineId = aestheticListCountList[0].LineId;
                    //                agingBatchInfo.AddedBy = userId;
                    //                agingBatchInfo.AddedDate = DateTime.Now;

                    //                Result agingBatchResult = _productionService.InsertAgingcBatchInfo(agingBatchInfo);

                    //                if (agingBatchResult.IsSuccess)
                    //                {
                    //                    foreach (var aestheticList in aestheticListCountList)
                    //                    {
                    //                        var batchingProduction = new ProductionMaster();

                    //                        batchingProduction.ProductionId = aestheticList.ProductionId;
                    //                        batchingProduction.MobileCode = aestheticList.MobileCode;
                    //                        batchingProduction.AgingBatchNumber = agingBatchInfo.BatchNo;

                    //                        producList.Add(batchingProduction);
                    //                    }


                    //                    agingSaveBatchResult =
                    //                        _productionService.UpdateProductionBatchStatus(producList);


                    //                }
                    //            }

                    //        }




                    //        if (result.IsSuccess == true && items.Passed.ToUpper() == "N")
                    //        {
                    //            var Reresult = new Result();
                    //            var rework = new tblRework();

                    //            foreach (tblRework item in reworkList)
                    //            {
                    //                rework.LineId = lineId;
                    //                rework.ProjectId = pcbStation != null ? pcbStation.ProjectId : projectId;// projectId;
                    //                rework.MobileCode = item.MobileCode;
                    //                rework.Issues = item.Issues;
                    //                rework.FailedStation = item.FailedStation;
                    //                rework.Status = "P";
                    //                rework.AddedBy = userId;
                    //                rework.AddedDate = DateTime.Now;

                    //                Reresult = _productionService.InsertFunctionalRework(rework);

                    //            }
                    //        }

                    //    }

                    //    else
                    //    {
                    //        result.Message = "Invalid bar code!";
                    //        return Json(result);
                    //    }
                    //}

                }


            }
            catch (Exception)
            {

                throw;
            }


            return Json(result);
        }

        #endregion Insert Aesthetic Qc Station

        #region Insert Aging Qc Info

        public JsonResult InsertAgingQcStationInfo(List<tblAgingMaster> agingMasterList, string batchStatus, string agingType)
        {
            WCMSEntities entities = new WCMSEntities();
            long userId = (long)_dictionary[2].Id;
            Result result = new Result();
            var agingResult = new Result();
            if (userId != 0)
            {
                try
                {

                    var agingCheckedList = new List<tblAgingMaster>();
                    var chargingCheckedList = new List<tblChargerMaster>();
                    var batchNumber = RandomString();
                   
                     if (agingType == "AG")
                        {
                    foreach (var agingList in agingMasterList)
                    {
                        var agingCheckedMaster = new tblAgingMaster();


                        var productionMaserInfo =
                            _commonService.ProductionMasterInfo(new ProductionMaster
                            {
                                MobileCode = agingList.MobileCode.Trim()
                            }).FirstOrDefault();
                        var isExists =
                         _commonService.AgingMasterInfo(new tblAgingMaster { MobileCode = agingList.MobileCode.Trim() })
                             .Any();
                            agingCheckedMaster.ProjectId = productionMaserInfo != null
                                ? productionMaserInfo.ProjectId
                                : agingList.ProjectId;

                            agingCheckedMaster.ProjectName=productionMaserInfo != null
                                ? productionMaserInfo.ProjectName
                                : agingList.ProjectName;

                            agingCheckedMaster.LineId=productionMaserInfo != null
                                ? productionMaserInfo.LineId
                                : agingList.LineId;

                           agingCheckedMaster.MobileCode = agingList.MobileCode;
                           agingCheckedMaster.AgingBatch = "WC-AG-" + batchNumber;


                            agingCheckedMaster.AgingPassed = agingList.AgingPassed;                          
                            agingCheckedMaster.AgingIssue = agingList.AgingIssue;
                            if (agingList.AgingPassed == "N")
                                agingCheckedMaster.Reworked = true;
                        agingCheckedMaster.AddedBy = userId;
                         if(!isExists)
                         agingCheckedList.Add(agingCheckedMaster);

                         if (agingList.AgingPassed == "N" )
                        {
                            //agingCheckedMaster.Reworked = true;

                            var Reresult = new Result();
                            var rework = new tblRework();
                            rework.LineId = agingList.LineId;
                            rework.ProjectId = agingList.ProjectId;// projectId;
                            rework.MobileCode = agingList.MobileCode;
                            rework.Issues = agingList.AgingIssue;
                            rework.FailedStation = "AGQC";
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _productionService.InsertFunctionalRework(rework);
                        }

                        }

                        agingResult = _productionService.InsertAgingQcStationinfo(agingCheckedList);

                            if (agingResult.IsSuccess)
                            {
                                var batchresult = new Result();
                                var batchesult = new AgingBatch();
                                batchesult.BatchNumber = "WC-AG-" + batchNumber;
                                batchesult.BatchType = "AGING";
                                batchesult.Passed = batchStatus;
                                batchesult.AddedBy = userId;
                                batchesult.AddedDate = DateTime.Now;
                                batchresult = _productionService.InsertAgingBatchStatus(batchesult);
                            }
                    }
                     if (agingType == "CHRG")
                    {
                        foreach (var agingList in agingMasterList)
                        {
                            var chargerCheckedMaster = new tblChargerMaster();


                            var productionMaserInfo =
                                _commonService.ProductionMasterInfo(new ProductionMaster
                                {
                                    MobileCode = agingList.MobileCode.Trim()
                                }).FirstOrDefault();
                            
                            var isExists =
                             _commonService.ChargingMasterInfo(new tblChargerMaster() { MobileCode = agingList.MobileCode.Trim() })
                                 .Any();


                            chargerCheckedMaster.ProjectId = productionMaserInfo != null
                                ? productionMaserInfo.ProjectId
                                : agingList.ProjectId;

                            chargerCheckedMaster.ProjectName = productionMaserInfo != null
                                ? productionMaserInfo.ProjectName
                                : agingList.ProjectName;

                            chargerCheckedMaster.LineId = productionMaserInfo != null
                                ? productionMaserInfo.LineId
                                : agingList.LineId;

                            chargerCheckedMaster.MobileCode = agingList.MobileCode;
                            chargerCheckedMaster.ChargingBatch = "WC-CRG-" + batchNumber;

                            chargerCheckedMaster.ChargingPassed = agingList.AgingPassed;
                            chargerCheckedMaster.ChargingIssue = agingList.AgingIssue;
                            if (agingList.AgingPassed == "N")
                                chargerCheckedMaster.Reworked = true;
                            chargerCheckedMaster.AddedBy = userId;
                            if (!isExists)
                                chargingCheckedList.Add(chargerCheckedMaster);
                            if (agingList.AgingPassed == "N")
                            {
                                //agingCheckedMaster.Reworked = true;

                                var Reresult = new Result();
                                var rework = new tblRework();


                                rework.LineId = agingList.LineId;
                                rework.ProjectId = agingList.ProjectId;// projectId;
                                rework.MobileCode = agingList.MobileCode;
                                rework.Issues = agingList.AgingIssue;
                                rework.FailedStation = "CRGQC";
                                rework.Status = "P";
                                rework.AddedBy = userId;
                                rework.AddedDate = DateTime.Now;

                                Reresult = _productionService.InsertFunctionalRework(rework);
                            }

                        }
                        agingResult = _productionService.InsertChargingQcStationinfo(chargingCheckedList);

                        if (agingResult.IsSuccess)
                        {
                            var batchresult = new Result();
                            var batchesult = new AgingBatch();
                            batchesult.BatchNumber = "WC-CRG-" + batchNumber;
                            batchesult.BatchType = "CHARGING";
                            batchesult.Passed = batchStatus;
                            batchesult.AddedBy = userId;
                            batchesult.AddedDate = DateTime.Now;
                            batchresult = _productionService.InsertAgingBatchStatus(batchesult);

                        }                     
                    }
                }
                catch (Exception exception)
                {

                    return Json(new Result { Message = exception.ToString() });
                }
            }

            else
            {
                return Json(new Result { Id = "0" });
            }


            return Json(agingResult);
        }




        #endregion

        #region Insert Packaging Qc Station/Merge Station
        public JsonResult InsertPackagingQcStation(List<ProductionMaster> statusList)
        {
            WCMSEntities entities = new WCMSEntities();

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[5].Id;

            Result result = new Result();
            try
            {
                var productionMaster = new ProductionMaster();
                var listProductionMaster = new List<ProductionMaster>();

                foreach (var items in statusList)
                {
                    var imeiList = _commonService.GetImeiRecords(items.Imei1).FirstOrDefault();

                    if (imeiList != null)
                    {
                        var previousStatus = entities.ProductionMaster.FirstOrDefault(a => a.MobileCode == items.MobileCode.Trim());

                        //var previousStation = entities.ProductionMaster.FirstOrDefault(a => a.MobileCode == items.MobileCode);
                        //if (previousStatus != null && (isExists && previousStatus.Passed.ToUpper() == "N"))
                        //if (previousStatus != null && (isExists && previousStatus.Passed.ToUpper() == "N") && previousStatus.QcStation != "PKGQC")
                        //{
                        //    result.Message = "Item not passed from Aging QC station.";
                        //    return Json(result);

                        //}
                        //// if (previousStatus != null && (isExists) && (previousStatus.QcStation.Trim() != "AGQC" || previousStatus.QcStation.Trim() != "PKGQC") && items.QcStation.Trim() == "PKGQC")
                        //if (previousStatus != null && (isExists) && (previousStatus.QcStation.Trim() != "AGQC" && previousStatus.QcStation.Trim() != "PKGQC") && items.QcStation.Trim() == "PKGQC")
                        //{
                        //    result.Message = "Item not checked in Aging QC station.";
                        //    return Json(result);

                        //}
                        //if (previousStatus == null || !isExists)
                        //{
                        //    result.Message = "Item not checked in Aging QC station.";
                        //    return Json(result);

                        //}

                        // if (previousStatus != null && (isExists && items.QcStation.Trim() == "PKGQC"))
                        if (previousStatus != null && items.QcStation.Trim() == "PKGQC")
                        {
                            productionMaster.MobileCode = items.MobileCode;
                            productionMaster.QcStation = items.QcStation;
                            productionMaster.PackagingBy = userId;
                            productionMaster.PackagingAD = DateTime.Now;
                            productionMaster.PackagingLineId = lineId;
                            productionMaster.Imei1 = imeiList.IMEI1;
                            productionMaster.Imei2 = imeiList.IMEI2;
                            listProductionMaster.Add(productionMaster);
                            result = _productionService.UpdateQcStatusHistory(listProductionMaster);
                        }
                        else
                        {
                            result.IsSuccess = false;
                            result.Message = "Invalid Code Please SCAN Again! ";
                            return Json(result, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "No IMEI Number Found";
                        return Json(result, JsonRequestBehavior.AllowGet);

                    }
                }


            }
            catch (Exception)
            {

                throw;
            }


            return Json(result);
        }

        #endregion Insert Packaging Qc Station

        #region Insert Packaging Aesthetic Station
        public JsonResult PackagingQcResult(ProductionMaster productionMaster, tblRework rework)
        {
            //WCMSEntities entities = new WCMSEntities();
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[5].Id;
            var pMaster = new ProductionMaster();

            Result result = new Result();
            try
            {
                var imeiData = _commonService.GetImeiRecords(productionMaster.Imei1.Trim()).FirstOrDefault();
                // var imeiData = _commonService.GetDetailsByImei(productionMaster.Imei1).FirstOrDefault();

                if (imeiData != null)
                {
                    var productionmasterInfo = _commonService.
                        ProductionMasterInfo(new ProductionMaster { Imei1 = imeiData.IMEI1.Trim() }).FirstOrDefault();

                    //check if previously passed
                    // var previousStatus = entities.ProductionMaster.FirstOrDefault(a => a.MobileCode == items.MobileCode);


                    //if (productionmasterInfo != null && (productionmasterInfo.Passed.ToUpper() == "N") && productionMaster.QcStation != "PACKGAESTHQC")
                    //{
                    //    result.Message = "Item not passed from Packaging QC station.";
                    //    return Json(result);

                    //}
                    //if (productionmasterInfo != null && (productionmasterInfo.QcStation.Trim() != "PKGQC" && productionmasterInfo.QcStation.Trim() != "PACKGAESTHQC") && productionMaster.QcStation.Trim() == "PACKGAESTHQC")
                    //{
                    //    result.Message = "Item not checked in Packaging QC station.";
                    //    return Json(result);

                    //}
                    //if (productionmasterInfo == null)
                    //{
                    //    result.Message = "Item not checked in Packaging QC station.";
                    //    return Json(result);

                    //}


                    if (productionmasterInfo != null && (productionMaster.QcStation == "PACKGAESTHQC")) //|| productionMaster.QcStation == "FUQC" || productionMaster.QcStation == "ASTQC")
                    {
                        var listProductionMaster = new List<ProductionMaster>();

                        pMaster.MobileCode = productionmasterInfo.MobileCode.Trim();
                        pMaster.Imei1 = imeiData.IMEI1; //productionMaster.Imei1;
                        pMaster.Imei2 = imeiData.IMEI2; //productionMaster.Imei2;
                        pMaster.Passed = productionMaster.Passed.ToUpper();
                        pMaster.QcStation = productionMaster.QcStation;
                        //pMaster.ProjectId = productionmasterInfo.ProjectId;
                        pMaster.PackagingLineId = lineId;
                        pMaster.PackagingAstheticBy = userId;
                        pMaster.PackagingAstheticAD = DateTime.Now;

                        listProductionMaster.Add(pMaster);
                        result = _productionService.UpdateQcStatusHistory(listProductionMaster);
                        //Insert to rework table

                        if (result.IsSuccess && productionMaster.Passed.ToUpper() == "N")
                        {
                            //var Reresult = new Result();;
                            var tblrework = new tblRework();

                            tblrework.ProjectId = productionmasterInfo.ProjectId;
                            tblrework.LineId = lineId;
                            tblrework.MobileCode = productionmasterInfo.MobileCode;
                            tblrework.Issues = rework.Issues;
                            tblrework.FailedStation = rework.FailedStation;
                            tblrework.Imei1 = imeiData.IMEI1; //rework.Imei1;
                            tblrework.Imei2 = imeiData.IMEI2; //rework.Imei2;
                            tblrework.Status = "P";
                            tblrework.AddedBy = userId;
                            tblrework.AddedDate = DateTime.Now;

                            result = _productionService.InsertFunctionalRework(tblrework);

                        }
                    }
                    else
                    {
                        result.Message = " Not Scanned at Merge point";
                    }
                }

                else
                {
                    result.Message = "No mobile found with these IMEI number";
                }
            }
            catch (Exception)
            {
                return Json("Error");
            }
            return Json(result);
        }

        #endregion Insert Packaging OQC Station

        #region  Insert Packaging OQC Station
        public JsonResult InsertPackagingOQcStatus(List<ProductionOQC> productionOQc, List<tblOqcCheckedItems> oqcChecked)
        {
            Result result = new Result();
            Result batchResult = new Result();

            WCMSEntities entities = new WCMSEntities();

            var randomString = RandomString();

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[5].Id;
            var checkedResult = new Result();
            //long lineId = (long)_dictionary[4].Id;
            if (userId != 0)
            {
                try
                {
//-------------------------------------------------------------//
                    //**Insert PackagingItemBatch **//
                    //**Insert PackagingItemBatch **//
                    var oQcBatchInfoList = new List<tblPackagingBatch>();
                    foreach (var items in productionOQc)
                    {
                        var oQcBatchInfo = new tblPackagingBatch();
                        var isExistsImei = _commonService.GetOQCBatchInfo(new tblPackagingBatch() { Imei1 = items.Imei1 }).FirstOrDefault();
                        var productionmasterInfo = _commonService.ProductionMasterInfo(new ProductionMaster
                            {
                                Imei1 = items.Imei1
                            }).FirstOrDefault();
                        if (isExistsImei == null)
                        {
                            if (productionmasterInfo != null)
                            oQcBatchInfo.MobileCode = productionmasterInfo.MobileCode;
                            oQcBatchInfo.Imei1 = items.Imei1;
                            oQcBatchInfo.Imei2 = items.Imei2;
                            oQcBatchInfo.MasterBatch = items.MasterBatch;
                            //oQcBatchInfo.ProjectId = productionmasterInfo.ProjectId;
                            if (items.Passed.ToUpper() == "Y")
                                oQcBatchInfo.Passed = "Y";
                            if (items.Passed.ToUpper() == "N")
                                oQcBatchInfo.Passed = "N";
                            oQcBatchInfo.Sample = items.IsSample;
                            oQcBatchInfo.Remarks = items.Remarks;
                            oQcBatchInfo.AddedBy = userId;
                            oQcBatchInfo.AddedDate = DateTime.Now;
                            oQcBatchInfoList.Add(oQcBatchInfo);
                           
                           
                        }
                    }
                    batchResult = _productionService.InsertOqcBatch(oQcBatchInfoList);

                    //**Insert PackagingItemBatch **//
                    //**Insert PackagingItemBatch **//

                    if (batchResult.IsSuccess)
                    {
                        //**Insert Checked Items**//
                        //**Insert Checked Items**//
                        foreach (var chkItems in oqcChecked)
                        {
                            //       var pmaster =
                            //_commonService.ProductionMasterInfo(new ProductionMaster
                            //{
                            //    Imei1 = chkItems.Imei1

                            //}).FirstOrDefault();
                            var checkedItems = new tblOqcCheckedItems();

                            checkedItems.Imei1 = chkItems.Imei1;
                            checkedItems.Imei2 = chkItems.Imei2;
                            //checkedItems.ProjectId = pmaster != null ? pmaster.ProjectId : 0;
                            checkedItems.OqcStatus = chkItems.OqcStatus;
                            checkedItems.Issues = chkItems.Issues;
                            checkedItems.Remarks = chkItems.Remarks;
                            checkedItems.AddedBy = userId;
                            checkedItems.AddedDate = DateTime.Now;

                            checkedResult = _productionService.InsertOqcCheckedItems(checkedItems);
                        }

                        //**Insert Checked Items**//
                        //**Insert Checked Items**//

                    }



                }
                catch (Exception)
                {
                    result.Message = "error occured while saving the information";
                    return Json(checkedResult);
                }


                return Json(checkedResult);
            }

            else
            {
                return Json(new Result { Id = "0" });

            }


        }
        #endregion  Insert Packaging OQC Station



        #endregion Packaging Stations Operations

        public JsonResult InsertFunctionalQcStatus(List<ProductionMaster> statusList, List<tblRework> reworkList)
        {
            WCMSEntities entities = new WCMSEntities();


            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;

            Result result = new Result();


            //if (userId != 0 && projectId != 0)

            if (userId != 0)
            {

                // projectId = 1; //test


                try
                {
                    var productionMaster = new ProductionMaster();
                    var listProductionMaster = new List<ProductionMaster>();
                    foreach (ProductionMaster items in statusList)
                    {
                        productionMaster.MobileCode = items.MobileCode;
                        productionMaster.Passed = items.Passed.ToUpper();
                        productionMaster.QcStation = items.QcStation;
                        productionMaster.LineId = lineId;
                        productionMaster.ProjectId = projectId;
                        productionMaster.ProjectName =
                            _commonService.GetAssemblineInfo(new tblAssemblyLineSetup()
                            {
                                ProjectId = Convert.ToInt32(projectId)
                            }).Select(x => x.ProjectName).FirstOrDefault();

                        bool isExists = entities.ProductionMaster.Any(a => a.MobileCode == items.MobileCode);
                        //check if previously passed
                        bool isPreviousPassed = entities.ProductionMaster.Any(a => a.Passed.Trim() == "Y" && a.MobileCode == items.MobileCode);
                        var previousStation = entities.ProductionMaster.FirstOrDefault(a => a.MobileCode == items.MobileCode);

                        //if (isPreviousPassed)

                        //{

                        if (isExists)
                        {
                            if (isPreviousPassed && items.Passed == "Y")
                            {



                                if (items.QcStation == "FUQC")
                                {
                                    productionMaster.FunctionalBy = userId;
                                    productionMaster.FunctionalAD = DateTime.Now;
                                }
                                else if (items.QcStation == "ASTQC")
                                {
                                    productionMaster.AestheticBy = userId;
                                    productionMaster.AestheticAD = DateTime.Now;
                                }

                                else if (items.QcStation == "AGQC")
                                {
                                    productionMaster.AgingBy = userId;
                                    productionMaster.AgingAD = DateTime.Now;
                                }

                                else if (items.QcStation == "PKGQC")
                                {
                                    productionMaster.PackagingBy = userId;
                                    productionMaster.PackagingAD = DateTime.Now;
                                }


                                else if (items.QcStation == "PACKGAESTHQC")
                                {
                                    productionMaster.PackagingAstheticBy = userId;
                                    productionMaster.PackagingAstheticAD = DateTime.Now;
                                }


                                productionMaster.UpdatedBy = userId;
                                productionMaster.UpdatedDate = DateTime.Now;
                                productionMaster.Imei1 = items.Imei1;
                                productionMaster.Imei2 = items.Imei2;
                                listProductionMaster.Add(productionMaster);
                                result = _productionService.UpdateQcStatusHistory(listProductionMaster);

                                //batching query will start from here
                                //batching query will start from here 


                                if (result.IsSuccess == true && items.Passed.ToUpper() == "Y" &&
                                    items.QcStation == "ASTQC")
                                {
                                    var producList = new List<ProductionMaster>();

                                    var startDate = DateTime.Today;
                                    var endDate = startDate.AddDays(1).AddTicks(-1);


                                    //var aestheticListCount =aestheticList.Count(a => a.AddedDate >= startDate && a.AddedDate <= endDate);

                                    var aestheticListCount = _commonService.
                                        ProductionMasterInfo(new ProductionMaster
                                        {
                                            QcStation = items.QcStation,
                                            ProjectId = projectId,
                                            Passed = items.Passed.ToUpper()
                                        })
                                        .Count(
                                            a =>
                                                a.AddedDate >= startDate && a.AddedDate <= endDate &&
                                                string.IsNullOrEmpty(a.AgingBatchNumber));


                                    var aestheticListCountList = _commonService.
                                        ProductionMasterInfo(new ProductionMaster
                                        {
                                            QcStation = items.QcStation,
                                            ProjectId = projectId,
                                            Passed = items.Passed.ToUpper()
                                        })
                                        .Where(
                                            a =>
                                                a.AddedDate >= startDate && a.AddedDate <= endDate &&
                                                string.IsNullOrEmpty(a.AgingBatchNumber)).ToList();


                                    if (aestheticListCount == 5)
                                    {


                                        var batchNumber = RandomString();

                                        var agingBatchResult = new Result();
                                        var agingSaveBatchResult = new Result();
                                        var agingBatchInfo = new AgingBatchInfo();
                                        agingBatchInfo.BatchNo = "WP-" + batchNumber;
                                        agingBatchInfo.ProjectId = projectId;
                                        agingBatchInfo.LineId = aestheticListCountList[0].LineId;
                                        agingBatchInfo.AddedBy = userId;
                                        agingBatchInfo.AddedDate = DateTime.Now;

                                        agingBatchResult = _productionService.InsertAgingcBatchInfo(agingBatchInfo);

                                        if (agingBatchResult.IsSuccess)
                                        {
                                            foreach (var aestheticList in aestheticListCountList)
                                            {
                                                var batchingProduction = new ProductionMaster();

                                                batchingProduction.ProductionId = aestheticList.ProductionId;
                                                batchingProduction.MobileCode = aestheticList.MobileCode;
                                                batchingProduction.AgingBatchNumber = agingBatchInfo.BatchNo;

                                                producList.Add(batchingProduction);
                                            }


                                            agingSaveBatchResult =
                                                _productionService.UpdateProductionBatchStatus(producList);


                                        }
                                    }

                                }

                                //Insert to rework table

                                if (result.IsSuccess == true && items.Passed.ToUpper() == "N")
                                {
                                    var Reresult = new Result();
                                    var rework = new tblRework();

                                    foreach (tblRework item in reworkList)
                                    {
                                        rework.LineId = lineId;
                                        rework.ProjectId = projectId;
                                        rework.MobileCode = item.MobileCode;
                                        rework.Issues = item.Issues;
                                        rework.FailedStation = item.FailedStation;
                                        rework.Status = "P";
                                        rework.AddedBy = userId;
                                        rework.AddedDate = DateTime.Now;

                                        Reresult = _productionService.InsertFunctionalRework(rework);

                                    }
                                }

                            }


                            else
                            {
                                result.Message = "This Item Is Not Passed From Previous Station. Item No:" + items.MobileCode + "";
                                return Json(result);
                            }


                        }

                        else
                        {





                            productionMaster.AddedBy = userId;
                            productionMaster.AddedDate = DateTime.Now;


                            switch (items.QcStation)
                            {
                                case "FUQC":
                                    productionMaster.FunctionalBy = userId;
                                    productionMaster.FunctionalAD = DateTime.Now;
                                    break;
                                case "ASTQC":
                                    productionMaster.AestheticBy = userId;
                                    productionMaster.AestheticAD = DateTime.Now;
                                    break;
                                case "AGQC":
                                    productionMaster.AgingBy = userId;
                                    productionMaster.AgingAD = DateTime.Now;
                                    break;
                                case "PKGQC":
                                    productionMaster.PackagingBy = userId;
                                    productionMaster.PackagingAD = DateTime.Now;
                                    break;
                                case "PACKGAESTHQC":
                                    productionMaster.PackagingAstheticBy = userId;
                                    productionMaster.PackagingAstheticAD = DateTime.Now;
                                    break;
                            }

                            result = _productionService.InsertFunctionalQcStatus(productionMaster);


                            //batching query will start from here
                            //batching query will start from here 


                            if (result.IsSuccess == true && items.Passed.ToUpper() == "Y" &&
                                items.QcStation == "ASTQC")
                            {
                                var producList = new List<ProductionMaster>();

                                var startDate = DateTime.Today;
                                var endDate = startDate.AddDays(1).AddTicks(-1);


                                //var aestheticListCount =aestheticList.Count(a => a.AddedDate >= startDate && a.AddedDate <= endDate);

                                var aestheticListCount = _commonService.
                                    ProductionMasterInfo(new ProductionMaster
                                    {
                                        QcStation = items.QcStation,
                                        ProjectId = projectId,
                                        Passed = items.Passed.ToUpper()
                                    })
                                    .Count(
                                        a =>
                                            a.AddedDate >= startDate && a.AddedDate <= endDate &&
                                            string.IsNullOrEmpty(a.AgingBatchNumber));


                                var aestheticListCountList = _commonService.
                                    ProductionMasterInfo(new ProductionMaster
                                    {
                                        QcStation = items.QcStation,
                                        ProjectId = projectId,
                                        Passed = items.Passed.ToUpper()
                                    })
                                    .Where(
                                        a =>
                                            a.AddedDate >= startDate && a.AddedDate <= endDate &&
                                            string.IsNullOrEmpty(a.AgingBatchNumber)).ToList();


                                if (aestheticListCount == 5)
                                {


                                    var batchNumber = RandomString();

                                    var agingBatchResult = new Result();
                                    var agingSaveBatchResult = new Result();
                                    var agingBatchInfo = new AgingBatchInfo();
                                    agingBatchInfo.BatchNo = "WP-" + batchNumber;
                                    agingBatchInfo.ProjectId = projectId;
                                    agingBatchInfo.LineId = lineId;
                                    agingBatchInfo.AddedBy = userId;
                                    agingBatchInfo.AddedDate = DateTime.Now;

                                    agingBatchResult = _productionService.InsertAgingcBatchInfo(agingBatchInfo);

                                    if (agingBatchResult.IsSuccess)
                                    {
                                        foreach (var aestheticList in aestheticListCountList)
                                        {
                                            var batchingProduction = new ProductionMaster();

                                            batchingProduction.ProductionId = aestheticList.ProductionId;
                                            batchingProduction.MobileCode = aestheticList.MobileCode;
                                            batchingProduction.AgingBatchNumber = agingBatchInfo.BatchNo;

                                            producList.Add(batchingProduction);
                                        }


                                        agingSaveBatchResult =
                                            _productionService.UpdateProductionBatchStatus(producList);


                                    }



                                }

                            }





                            if (result.IsSuccess == true && items.Passed.ToUpper() == "N")
                            {
                                var Reresult = new Result();
                                var rework = new tblRework();

                                foreach (tblRework item in reworkList)
                                {
                                    rework.LineId = lineId;
                                    rework.ProjectId = projectId;
                                    rework.MobileCode = item.MobileCode;
                                    rework.Issues = item.Issues;
                                    rework.FailedStation = item.FailedStation;
                                    rework.Status = "P";
                                    rework.AddedBy = userId;
                                    rework.AddedDate = DateTime.Now;

                                    Reresult = _productionService.InsertFunctionalRework(rework);

                                }
                            }


                        }
                        //}

                        //else
                        //{
                        //    result.Message = "Not Passed From Previous Station";

                        //    return Json(result);
                        //}


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


        public JsonResult GetImeiByCode(string code)
        {
            Result result = new Result();
            var productionmasterInfo = _commonService.ProductionMasterInfoByImei(code).ToList();
            return Json(productionmasterInfo, JsonRequestBehavior.AllowGet);
        }





        private static readonly Random Random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }


        public JsonResult GetQcStatusHistory(string mobileCode)
        {
            // ProductionService productionService = new ProductionService();

            long UserId = (long)_dictionary[2].Id;

            tblRework rework = new tblRework();
            List<tblRework> result;
            rework.MobileCode = mobileCode;
            result = _productionService.GetQcStatusHistory(rework);
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetAllIssueListFunctional()
        {
            var eList = new List<Issues>();
            try
            {
                eList = _commonService.GetAllIssueList().Where(a => a.FaultType == "F").OrderBy(s => s.Name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // var objstate = e_List.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(eList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllIssueListAesthetic()
        {
            var eList = new List<Issues>();
            try
            {
                eList = _commonService.GetAllIssueList().Where(a => a.FaultType == "A").OrderBy(s => s.Name).ToList();
            }
            catch (Exception ex)
            {

            }
            // var objstate = e_List.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(eList, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetAllIssueList()
        {
            var e_List = new List<Issues>();
            try
            {
                e_List = _commonService.GetAllIssueList().ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = e_List.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateQcStatusHistory(List<ProductionMaster> productionList)
        {


            long userId = (long)_dictionary[2].Id;
            ProductionMaster productionMaster = new ProductionMaster();
            var _Result = new Result();
            _Result = _productionService.UpdateQcStatusHistory(productionList);

            return Json(_Result);
        }

        //StartPending Work
        public JsonResult StartRework(List<tblRework> reworks)
        {

            Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            long userId = (long)IDictionary[2].Id;

            var _Result = new Result();
            _Result = _productionService.UpdateRework(reworks);

            return Json(_Result);
        }

        //New Rework Station Task
        //New Rework Station Task
        public JsonResult InsertreworkStationInfo(tblRework reworks, List<tblRepairStatus> repairStatus, List<tblRepairComponents> repairComponents)
        {
            long userId = (long)_dictionary[2].Id;
            var reworkResult = new Result();
            var repairStatusResult = new Result();
            var repairComponentsResult = new Result();

            if (userId != 0)
            {

                try
                {
                    if (reworks != null)
                    {
                        reworks.FinishedDate = DateTime.Now;
                        reworks.FinishedBy = userId;
                        reworks.Status = "D";
                        reworks.UpdatedBy = userId;
                        reworks.UpdatedDate = DateTime.Now;
                        reworkResult = _productionService.UpdateReworkTask(reworks);
                    }




                    if (repairStatus != null && reworkResult.IsSuccess)


                        repairStatusResult = _productionService.InsertRepairStatus(repairStatus);
                    //Insert into components 
                    if (reworkResult.IsSuccess && repairStatusResult.IsSuccess && repairComponents != null)
                    {
                        repairComponentsResult = _productionService.InsertRepairComponents(repairComponents);


                    }



                    return Json(reworkResult);
                }
                catch (Exception exception)
                {

                    throw exception;
                }

                //Insert into repair 

            }


            else
            {
                return Json(new Result { Id = "0" });

            }




        }





        //Update ReworkTask
        public JsonResult UpdateReworkTask(tblRework reworks)
        {

            long userId = (long)_dictionary[2].Id;


            Result _Result;
            Result productionMasterResult;
            if (userId != 0)
            {


                if (reworks.Status == "S")
                {
                    reworks.StartDate = DateTime.Now;
                    reworks.StartedBy = userId;
                }

                else
                {
                    reworks.FinishedDate = DateTime.Now;
                    reworks.FinishedBy = userId;
                }

                reworks.UpdatedBy = userId;
                reworks.UpdatedDate = DateTime.Now;
                _Result = _productionService.UpdateReworkTask(reworks);


                if (_Result.IsSuccess)
                {
                    var productionMaster = new ProductionMaster();
                    var produvtionMasterList = new List<ProductionMaster>();
                    var mobileCd = _productionService.GetIssueResult(new tblRework() { ReworkId = reworks.ReworkId }).Select(a => a.MobileCode).FirstOrDefault();

                    productionMaster.MobileCode = mobileCd;
                    productionMaster.Passed = "Y";
                    productionMaster.UpdatedBy = userId;
                    productionMaster.UpdatedDate = DateTime.Now;
                    produvtionMasterList.Add(productionMaster);
                    productionMasterResult = _productionService.UpdateQcStatusHistory(produvtionMasterList);


                }

                return Json(_Result);
            }

            else
            {
                return Json(new Result { Id = "0" });

            }



        }


        //get issues Result
        public JsonResult GetIssueResult(string mobileCode)
        {

            long userId = (long)_dictionary[2].Id;
            tblRework rework = new tblRework();


            List<tblRework> result;

            rework.MobileCode = mobileCode;
            rework.Status = "P";
            var results = _productionService.GetIssueResult(rework);
            return Json(results, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetFaultyMobileHistory(string mobileCode, string checkedcategory)
        {
            if (checkedcategory == "code")
            {
                var list = _commonService.GetFaultyMobileHistory(mobileCode);
                return Json(list, JsonRequestBehavior.AllowGet);

            }

            else
            {

                var mbCode = _commonService.ProductionMasterInfoByImei(mobileCode).ToList();
                var list = _commonService.GetFaultyMobileHistory(mbCode[0].MobileCode);
                return Json(list, JsonRequestBehavior.AllowGet);
            }



        }


        //get issues Result by Imei
        public JsonResult GetIssueResultByImei(string imei1, string imei2)
        {

            Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            long userId = (long)_dictionary[2].Id;
            tblRework rework = new tblRework();

            var results = _productionService.GetIssueResult(new tblRework { Imei1 = imei1, Imei2 = imei2, Status = "P" }).ToList();


            return Json(results, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetIssuesCount()
        {
            long projectId = (long)_dictionary[3].Id;
            // WCMSEntities _entity = new WCMSEntities();
            // var List = _entity.tblRework.ToList();

            // var list = _commonService.GetAllIssuesList().Where(a=>a.ProjectId==projectId).ToList();
            var list = _commonService.GetAllIssuesList();
            var pendingList = list.Where(x => x.Status == "P");

            var startedList = list.Where(x => x.Status == "S");
            var completedList = list.Where(x => x.Status == "D");
            var wastedList = list.Where(x => x.Status == "W");
            var objstate = list.Select(x => new { pendingListCount = pendingList.Count(), startedListCount = startedList.Count(), completedListCount = completedList.Count(), wastedListCount = wastedList.Count() }).ToList();
            return Json(objstate, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetCompletedRepairCountIndvidual()
        {
            long userId = (long)_dictionary[2].Id;
            var list = _commonService.GetCompletedRepairCount().Where(a => a.FinishedBy == userId).ToList();
            var objstate = list.Count();
            return Json(objstate, JsonRequestBehavior.AllowGet);
        }

        //Get On going task

        [HttpGet]
        public JsonResult GetOnGoingTask()
        {

            long userId = (long)_dictionary[2].Id;


            WCMSEntities _entity = new WCMSEntities();
            var startedWorkList = _entity.tblRework.Where(x => x.Status == "S" && x.StartedBy == userId).ToList();
            return Json(startedWorkList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult InsertBomList(BomList bomList)
        {
            Result result = new Result();
            result = _productionService.InsertBomList(bomList);
            return Json(result);

        }


        [HttpGet]
        public JsonResult GetComponentsByProjectId()
        {

            long projectId = (long)_dictionary[3].Id;
            List<ProjectBomList> List = new List<ProjectBomList>();
            try
            {
                List = _commonService.GetComponentsByProjectId(new ProjectBomList() { ProjectMasterId = projectId });

            }
            catch (Exception ex)
            {

            }
            var objstate = List.Select(x => new { value = x.ComponentName, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);

        }


        public JsonResult InsertSolderingInfo(List<tblSolderingOthers> solderiList)
        {


            Result result = new Result();

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;

            tblSolderingOthers oSolderList = new tblSolderingOthers();

            try
            {
                foreach (tblSolderingOthers items in solderiList)
                {
                    oSolderList.ReworkId = items.ReworkId;
                    oSolderList.ProjectId = projectId;
                    oSolderList.ComponentId = items.ComponentId;
                    oSolderList.ComponentName = items.ComponentName;

                    oSolderList.RequsitionQuantity = items.RequsitionQuantity;
                    oSolderList.UsedQuantity = items.UsedQuantity;
                    oSolderList.WastedQuantity = items.WastedQuantity;
                    oSolderList.AddedBy = userId;
                    oSolderList.AddedDate = DateTime.Now;
                    oSolderList.Remarks = items.Remarks;
                    result = _productionService.InsertSolderingInfo(oSolderList);

                }
            }
            catch (Exception)
            {

                return Json("Error");
            }

            return Json(result);

        }



        public JsonResult GetDetailsByImei(string imei)
        {
            var imeiInfo = _commonService.GetDetailsByImei(imei);

            return Json(imeiInfo, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetQcStatusHistoryByImei(string imei)
        {
            // ProductionService productionService = new ProductionService();



            var historyInfo = _productionService.IssueHistoryByImei(imei);

            return Json(historyInfo, JsonRequestBehavior.AllowGet);



        }

        public JsonResult GetReworkDetailsByImei(string imei)
        {
            // ProductionService productionService = new ProductionService();



            var historyInfo = _productionService.GetReworkDetailsByImei(imei);

            return Json(historyInfo, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetMobileCodeInfo(string mobileCode)
        {

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            Result result = new Result();
            try
            {
                var batchNumber = _commonService.ProductionMasterInfo(new ProductionMaster() { MobileCode = mobileCode }).ToList();

                //var agingBatchInformation = _commonService.GetAgingBatchData(new AgingBatchInfo() { BatchNo = batchNumber }).FirstOrDefault();

                if (batchNumber.Count > 0 && batchNumber[0].MobileCode != null)
                {
                    // var batchList =batchNumber.ToList();
                    //var newvar=
                    return Json(batchNumber, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    batchNumber.Clear();
                    return Json(batchNumber, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }



        }





















        public JsonResult GetAgingBatchData(string mobileCode)
        {

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            Result result = new Result();
            try
            {
                var batchNumber = _commonService.ProductionMasterInfo(new ProductionMaster() { MobileCode = mobileCode }).Select(a => a.AgingBatchNumber).FirstOrDefault();

                var agingBatchInformation = _commonService.GetAgingBatchData(new AgingBatchInfo() { BatchNo = batchNumber }).FirstOrDefault();

                if (agingBatchInformation != null && (batchNumber != null && agingBatchInformation.Status == null))
                {
                    var batchList =
                        _commonService.ProductionMasterInfo(new ProductionMaster() { AgingBatchNumber = batchNumber })
                            .ToList();

                    return Json(batchList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "No Batch Found With This Code! Please Check Again";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }



        }

        [HttpGet]
        public JsonResult GetFunctionalQcCount()
        {
            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                var userId = (long)_dictionary[2].Id;
                var projectId = (long)_dictionary[3].Id;
                var lineId = (long)_dictionary[4].Id;
                //var totalQcComponentsCount = _commonService.GetFunctionalQcCount().Where(a => a.ProjectId == projectId && a.FunctionalBy == userId).ToList();
                var totalQcComponentsCount = _commonService.GetFunctionalQcCount().Where(a => a.FunctionalBy == userId).ToList();

                var passedCount = totalQcComponentsCount.Where(x => x.Passed == "Y").ToList();
                var currentFail = totalQcComponentsCount.Count(x => x.Passed == "N" && x.QcStation == "FUQC");
                var passedCount1 = totalQcComponentsCount.Count(x => x.QcStation == "ASTQC" && x.Passed == "N");
                var totalpassed = passedCount.Count() + passedCount1;


                //var failedCount = _productionService.GetIssueResult(new tblRework() { ProjectId = projectId, AddedBy = userId, FailedStation = "FUQC" })
                var failedCount = _productionService.GetIssueResult(new tblRework() { AddedBy = userId, FailedStation = "FUQC" })
                    .Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();



                //totalQcComponentsCount.Where(x => x.Passed == "N").ToList();



                var objstate = totalQcComponentsCount.Select(x => new { totalFunctionQc = totalQcComponentsCount.Count(), passedCount = totalpassed, failedCount = failedCount.Count(), cuFail = currentFail }).ToList(); //passedCount.Count()
                return Json(objstate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

        [HttpGet]
        public JsonResult GetAestheticQcCount()
        {

            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                long userId = (long)_dictionary[2].Id;
                long projectId = (long)_dictionary[3].Id;
                long lineId = (long)_dictionary[4].Id;
                //var totalQcComponentsCount = _commonService.GetAestheticQcCount().Where(a => a.ProjectId == projectId && a.AestheticBy == userId).ToList();
                var totalQcComponentsCount = _commonService.GetAestheticQcCount().Where(a => a.AestheticBy == userId).ToList();

                var passedCount = totalQcComponentsCount.Where(x => x.Passed == "Y").ToList();
                var currentFailed = totalQcComponentsCount.Count(x => x.Passed == "N");
                // var failedCount = _productionService.GetIssueResult(new tblRework() { ProjectId = projectId, AddedBy = userId, FailedStation = "ASTQC" })
                var failedCount = _productionService.GetIssueResult(new tblRework() { AddedBy = userId, FailedStation = "ASTQC" })
               .Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
                //var failedCount = totalQcComponentsCount.Where(x => x.Passed == "N").ToList();



                var objstate = totalQcComponentsCount.Select(x => new { totalFunctionQc = totalQcComponentsCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count(), cufailed = currentFailed }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        [HttpGet]
        public JsonResult GetPackagingCount()
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            var totalQcComponentsCount = _commonService.GetPackagingCount().Where(a => a.PackagingBy == userId).ToList();
            //var passedCount = totalQcComponentsCount.Where(x => x.Passed == "Y").ToList();
            //var failedCount = _productionService.GetIssueResult(new tblRework() { ProjectId = projectId, AddedBy = userId, FailedStation = "PKGQC" })
            // var failedCount = _productionService.GetIssueResult(new tblRework() { AddedBy = userId, FailedStation = "PKGQC" })
            //.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
            //var failedCount = totalQcComponentsCount.Where(x => x.Passed == "N").ToList();
            var objstate = totalQcComponentsCount.Select(x => new { totalFunctionQc = totalQcComponentsCount.Count() }).ToList();
            return Json(objstate, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public JsonResult GetPackagingAestheticCount()
        {

            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                long userId = (long)_dictionary[2].Id;
                long projectId = (long)_dictionary[3].Id;
                long lineId = (long)_dictionary[4].Id;
                var totalQcComponentsCount = _commonService.GetPackagingAestheticCount().Where(a => a.PackagingAstheticBy == userId).ToList();
                var passedCount = totalQcComponentsCount.Where(x => x.Passed == "Y").ToList();
                // var failedCount = _productionService.GetIssueResult(new tblRework() { ProjectId = projectId, AddedBy = userId, FailedStation = "PACKGAESTHQC" })
                var failedCount = _productionService.GetIssueResult(new tblRework() { AddedBy = userId, FailedStation = "PACKGAESTHQC" })
               .Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
                //var failedCount = totalQcComponentsCount.Where(x => x.Passed == "N").ToList();
                var objstate = totalQcComponentsCount.Select(x => new { totalFunctionQc = totalQcComponentsCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count() }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpGet]
        public JsonResult GetPackagingOqcCount()
        {


            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                long userId = (long)_dictionary[2].Id;
                long projectId = (long)_dictionary[3].Id;
                long lineId = (long)_dictionary[4].Id;
                // var totalQcComponentsCount = _commonService.GetPackagingOqcCount().Where(a => a.ProjectId == projectId && a.AestheticBy == userId).ToList();

                var totalQcComponentsCount = _commonService.GetPackagingOqcCount().Where(a => a.AestheticBy == userId).ToList();
                var passedCount = totalQcComponentsCount.Where(x => x.Passed == "Y").ToList();
                //var failedCount = _productionService.GetIssueResult(new tblRework() { ProjectId = projectId, AddedBy = userId, FailedStation = "PACKGAESTHQC" })
                var failedCount = _productionService.GetIssueResult(new tblRework() { AddedBy = userId, FailedStation = "PACKGAESTHQC" })
              .Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
                var objstate = totalQcComponentsCount.Select(x => new { totalFunctionQc = totalQcComponentsCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count() }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }


        public JsonResult InsertAgingQc(List<ProductionMaster> productionAgingQc, string batchStatus)
        {
            WCMSEntities entities = new WCMSEntities();

            var randomString = RandomString();

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            if (userId != 0)
            {

                try
                {
                    foreach (var agQc in productionAgingQc)
                    {
                        var firstOrDefault = _commonService.ProductionMasterInfo(new ProductionMaster() { MobileCode = agQc.MobileCode }).Select(a => a.ProjectId).FirstOrDefault();
                        if (
                            firstOrDefault != null)
                            projectId = (long)firstOrDefault;
                    }



                    var result = _productionService.InsertAgingBatchQcInfo(productionAgingQc, batchStatus, userId, lineId, projectId);
                    return Json(result);
                }
                catch (Exception)
                {

                    throw;
                }

            }

            else
            {
                return Json(new Result { Id = "0" });
            }


        }

        [HttpGet]
        public JsonResult GetLastThreeCount(string flag)
        {
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            var list = new List<ProductionMaster>();
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);

            switch (flag)
            {
                case "FUQC":
                    list = _commonService.ProductionMasterInfo(new ProductionMaster() { ProjectId = projectId, FunctionalBy = userId }).Where(a => a.FunctionalAD >= startDate && a.FunctionalAD <= endDate).OrderByDescending(y => y.FunctionalAD)
                        .Take(3)
                        .ToList();
                    break;
                case "ASTQC":
                    list = _commonService.ProductionMasterInfo(new ProductionMaster() { ProjectId = projectId, AestheticBy = userId }).Where(a => a.AestheticAD >= startDate && a.AestheticAD <= endDate).OrderByDescending(y => y.AestheticAD)
                        .Take(3)
                        .ToList();
                    break;
                case "AGQC":
                    list = _commonService.ProductionMasterInfo(new ProductionMaster() { ProjectId = projectId, AgingBy = userId }).Where(a => a.AgingAD >= startDate && a.AgingAD <= endDate).OrderByDescending(y => y.AgingAD)
                        .Take(3)
                        .ToList();
                    break;
                case "PKGQC":
                    list = _commonService.ProductionMasterInfo(new ProductionMaster() { ProjectId = projectId, PackagingBy = userId }).Where(a => a.PackagingAD >= startDate && a.PackagingAD <= endDate).OrderByDescending(y => y.PackagingAD)
                        .Take(3)
                        .ToList();
                    break;
                case "PACKGAESTHQC":
                    list = _commonService.ProductionMasterInfo(new ProductionMaster() { ProjectId = projectId, PackagingAstheticBy = userId }).Where(a => a.PackagingAstheticAD >= startDate && a.PackagingAstheticAD <= endDate).OrderByDescending(y => y.PackagingAD)
                        .Take(3)
                        .ToList();
                    break;
                case "PACKGOQC":
                    list = _commonService.ProductionMasterInfo(new ProductionMaster() { ProjectId = projectId, PackagingOQCBy = userId }).Where(a => a.PackagingOQCAD >= startDate && a.PackagingOQCAD <= endDate).OrderByDescending(y => y.PackagingAD)
                        .Take(3)
                        .ToList();
                    break;
            }

            return Json(list, JsonRequestBehavior.AllowGet);
            // return Json(list.ToArray(), JsonRequestBehavior.AllowGet);

        }





        [HttpPost]
        //public JsonResult CreateOQCBacthInfo(string imeiCode)


        //{

        //    long userId = (long)_dictionary[2].Id;
        //    long projectId = (long)_dictionary[3].Id;
        //    long lineId = (long)_dictionary[4].Id;
        //    var list = new List<ProductionMaster>();
        //    var startDate = DateTime.Today;
        //    var endDate = startDate.AddDays(1).AddTicks(-1);
        //    var batchResult = new Result();
        //    try
        //    {


        //       // var imeiData = _commonService.ProductionMasterInfo(new ProductionMaster{Imei1 = imeiCode.Trim(),Passed ="Y"}).FirstOrDefault();
        //        var imeiData = _commonService.ProductionMasterInfoByImei(imeiCode).FirstOrDefault(a => a.Passed == "Y");

        //        if (imeiData != null)
        //        {

        //            var packaginOQC = new OQcBatchInfo();


        //            //packaginOQC.BatchNo = randomString;
        //            packaginOQC.Imei1 = imeiData.Imei1;
        //            packaginOQC.Imei2 = imeiData.Imei2;
        //            packaginOQC.LineId = imeiData.LineId;
        //            packaginOQC.ProjectId = imeiData.ProjectId;
        //            packaginOQC.Passed = imeiData.Passed.ToUpper();
        //            packaginOQC.MobileCode = imeiData.MobileCode;
        //            //packaginOQC.IsSample = items.IsSample;
        //            //packaginOQC.Remarks = items.Remarks;
        //            packaginOQC.AddedBy = userId;
        //            packaginOQC.AddedDate = DateTime.Now;

        //            batchResult = _productionService.InsertOQcBatchInfo(packaginOQC);

        //            if (batchResult.IsSuccess)
        //            {
        //                var oqCBatchList = _commonService.
        //                                    GetOQCBatchInfo(new OQcBatchInfo
        //                                    {
        //                                      AddedBy = userId,
        //                                        ProjectId = projectId,
        //                                        Passed ="Y"
        //                                    })
        //                                    .Where(
        //                                        a =>
        //                                            a.AddedDate >= startDate && a.AddedDate <= endDate &&
        //                                            string.IsNullOrEmpty(a.BatchNo)).ToList();

        //                if (oqCBatchList.Count ==5)
        //                {
        //                    var agingUpdateBatchResult = new Result();
        //                    var batchNumber = RandomString();



        //                    var batchInfoList = new List <OQcBatchInfo>();


        //                    foreach (var items in oqCBatchList)
        //                    {

        //                        var batchInfo = new OQcBatchInfo();
        //                        batchInfo.BatchNo = "WP-" + batchNumber;

        //                        batchInfo.Imei1 =items.Imei1;
        //                        batchInfo.Imei2 = items.Imei2;
        //                        batchInfo.MobileCode = items.MobileCode;
        //                        batchInfo.AddedBy = userId;
        //                        batchInfoList.Add(batchInfo);

        //                    }

        //                    agingUpdateBatchResult = _productionService.UpdateOQCBatchInfo(batchInfoList);					
        //                }

        //            }




        //        }

        //        else
        //        {
        //            batchResult.Message = "No Data Found";
        //            return Json(batchResult);
        //        }


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //    return Json(batchResult);


        //}



        //public JsonResult CountOqcBatch()
        //{
        //    long userId = (long)_dictionary[2].Id;
        //    long projectId = (long)_dictionary[3].Id;
        //    long lineId = (long)_dictionary[4].Id;
        //    var startDate = DateTime.Today;
        //    var endDate = startDate.AddDays(1).AddTicks(-1);

        //    var oqCBatchList = _commonService.
        //                                     GetOQCBatchInfo(new OQcBatchInfo
        //                                     {
        //                                         AddedBy = userId,
        //                                         ProjectId = projectId

        //                                     })
        //                                     .Where(
        //                                         a =>
        //                                             a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();


        //    var objstate = oqCBatchList.Select(x => new { batchComponentcount = oqCBatchList.Count() }).ToList();
        //    return Json(objstate, JsonRequestBehavior.AllowGet);

        //}



        public JsonResult GetOqcBatchData(string imeiCode)
        {
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            Result result = new Result();
            try
            {
                string batchNumber = _commonService.GetOQCBatchInfoByImei(imeiCode).Select(a => a.SystemBatch).FirstOrDefault();

                if (batchNumber != null)
                {
                    var batchList =
                        _commonService.GetOQCBatchInfo(new tblPackagingBatch() { SystemBatch = batchNumber })
                            .ToList();

                    ///if (batchList.Count==5)
                    return Json(batchList, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "No Batch Found With This Code! Please Check Again";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public JsonResult GetUpdateOQCBatchData(string imeiCode)
        {
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            Result result = new Result();
            try
            {
                var batchNumber = _commonService.GetOQCBatchInfoByImei(imeiCode).Where(a => a.SystemBatch == null).ToList();

                if (batchNumber != null)
                {

                    return Json(batchNumber.ToList(), JsonRequestBehavior.AllowGet);

                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Already in a batch! Try with another";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {


                result.Message = ex.ToString();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult GeneratePackagingImeiBatch(string imeiCode)
        {
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            Result result = new Result();

            try
            {

                result = _productionService.GenerateImeiBatch(userId, projectId, imeiCode);

            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();
                return Json(result);
            }
            return Json(result);
        }



        [HttpGet]
        public JsonResult CountPackagingBatchInfo()
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            var totalQcComponentsCount = _productionService.CountPackagingBatch(projectId, userId).ToList();
            var totalBatchCreated = totalQcComponentsCount.Count(a => a.SystemBatch != null);
            var waitingforbatch = totalQcComponentsCount.Count(a => a.SystemBatch == null);
            var batchData = totalQcComponentsCount.Where(a => a.SystemBatch != null).GroupBy(a => a.SystemBatch).Select(a => a.Key).ToList();



            //totalQcComponentsCount.Where(x => x.Passed == "N").ToList();



            var objstate = totalQcComponentsCount
                .Select(x => new { totalPackagingBatchCount = totalQcComponentsCount.Count(), batchName = batchData, totalBatchCreated = totalBatchCreated, waitingforbatch = waitingforbatch }).ToList();
            return Json(objstate, JsonRequestBehavior.AllowGet);


        }


        public JsonResult UpdateOQCBatchInfo(List<tblPackagingBatch> packagingBatche, string batchNumber)
        {
            try
            {
                long userId = (long)_dictionary[2].Id;
                long projectId = (long)_dictionary[3].Id;
                Result result = new Result();
                var packagingBatcheList = new List<tblPackagingBatch>();
                foreach (var items in packagingBatche)
                {

                    if (items.SystemBatch.ToLower() == "new")
                    {
                        var oQcBatchInfoList = new tblPackagingBatch();
                        oQcBatchInfoList.SystemBatch = batchNumber;
                        oQcBatchInfoList.Imei1 = items.Imei1;
                        oQcBatchInfoList.Imei2 = items.Imei2;


                        packagingBatcheList.Add(oQcBatchInfoList);

                    }



                }

                result = _productionService.UpdateOQCBatchInfo(packagingBatcheList);

                return Json(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }



        [HttpPost]
        public JsonResult GetLogisticBatchData(string batchCode)
        {
            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            Result result = new Result();
            try
            {
                //var batcbatchData = _commonService.GetOQCBatchInfo(new tblPackagingBatch() { MasterBatch = batchCode }).Where(a => a.Delivered == null).ToList();

                var batcbatchData = _commonService.GetOQCBatchInfo(new tblPackagingBatch() { MasterBatch = batchCode }).ToList();

                if (batcbatchData.Count == 0)
                {
                    result.IsSuccess = false;
                    result.Message = "No Data Found With This Code(Not Scanned At OQC) !";
                    return Json(result, JsonRequestBehavior.AllowGet);

                }


                var checkDelivered = batcbatchData.Where(a => a.Delivered == null).ToList();

                if (checkDelivered.Count == 0)
                {

                    result.IsSuccess = false;
                    result.Message = " Already Received !";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                //if (batchNumber != null)
                //{

                //    var batchList =
                //        _commonService.GetOQCBatchInfo(new tblPackagingBatch() { MasterBatch = batchNumber })
                //            .ToList();

                else    // if (checkDelivered.Count != 0)
                {
                    return Json(batcbatchData, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        //Pause
        //public JsonResult GetLogisticReceivedList()
        //{
        //    long userId = (long)_dictionary[2].Id;
        //    long projectId = (long)_dictionary[3].Id;
        //    Result result = new Result();
        //     var startDate = DateTime.Today;
        //    var endDate = startDate.AddDays(1).AddTicks(-1);
        //    try
        //    {

        //        var batcbatchData = _commonService.GetOQCBatchInfo(new tblPackagingBatch() { AddedBy = userId }).Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();









        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }


        //}

        public JsonResult GetImeiData(string code)
        {
            var imeiData = _commonService.GetImeiRecords(code).FirstOrDefault();
            return Json(imeiData);
        }



        public JsonResult ReceiveLogisticItems(List<tblLogistics> logistics)
        {

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;
            Result result = new Result();
            Result logisticSaveResult = new Result();
            try
            {

                var packBatchListList = new List<tblPackagingBatch>();
                foreach (var items in logistics)
                {

                    var isExists = _commonService.GetLogisticsList(new tblLogistics() { Imei1 = items.Imei1 }).FirstOrDefault();

                    if (isExists == null)
                    {

                        var imeiData = _commonService.GetImeiRecords(items.Imei1).FirstOrDefault();
                        var logisticst = new tblLogistics();
                        var tblpackbatch = new tblPackagingBatch();
                        logisticst.BoxCode = items.BoxCode;
                        logisticst.Model = imeiData != null ? imeiData.Model : null;
                        logisticst.Color = imeiData != null ? imeiData.Color : null;
                        logisticst.Imei1 = items.Imei1;
                        logisticst.Imei2 = items.Imei2;
                        logisticst.AddedBy = userId;
                        logisticst.AddedDate = DateTime.Now;

                        //logisticsList.Add(logisticst);


                        logisticSaveResult = _productionService.InsertLogisticsData(logisticst);



                        //update packaging batch info

                        tblpackbatch.Delivered = "Y";
                        tblpackbatch.Imei1 = items.Imei1;
                        tblpackbatch.Imei2 = items.Imei2;
                        tblpackbatch.MasterBatch = items.BoxCode;
                        packBatchListList.Add(tblpackbatch);



                    }





                    // packBatchListList.Add(tblpackbatch);
                }

                if (logisticSaveResult.IsSuccess && packBatchListList.Count > 0)
                    result = _productionService.UpdateOQCBatchInfo(packBatchListList);



                return Json(logisticSaveResult);
            }
            catch (Exception ex)
            {
                logisticSaveResult.Message = ex.ToString();
                throw;
            }



        }


        public JsonResult GetImeiRecords(string imei)
        {
            Result result = new Result();
            try
            {
                var imeiList = _commonService.GetImeiRecords(imei).ToList();
                if (imeiList.Count != 0)
                {
                    return Json(imeiList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "No IMEI Number Found";
                    return Json(result, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public JsonResult GetMasterBoxData(string boxCode, string project)
        {
            List<MasterBoxModel> hourlyLineWiseStations = new List<MasterBoxModel>();

            var list = _commonService.GetMasterBoxData(boxCode, project).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetLogisticDataCount()
        {

            long userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;


            try
            {
                //var list = _commonService.GetLogisticData().Where(a => a.AddedBy == userId).ToList();
                var list = _commonService.GetLogisticData().ToList();
                return Json(list.Count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ecException)
            {

                throw ecException;
            }







            //var oQcList = reportService.GetLogisticsReport(date, project).ToList();


        }

        [HttpPost]
        public JsonResult InsertImeidata(List<ImeiModelUpload> imeiModelUpload)
        {
            Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            var userId = (long)IDictionary[2].Id;

            var result = new Result();
            var result1 = new Result();


            //var upload=new  List<ImeiModelUpload>();

            result = _commonService.InsertModelsImeiData(imeiModelUpload);

            if (result.IsSuccess)
            {
                result1 = _productionService.UpdateLogisticsData(imeiModelUpload);

            }
            else
            {
                result1.Message = result.Message;

            }



            return Json(result1);

        }


    }




}