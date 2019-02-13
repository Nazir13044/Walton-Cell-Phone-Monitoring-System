using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfService2.Services;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.HelperClass;

namespace WCMS_MAIN.Controllers
{
    public class CKDController : Controller
    {

        private readonly CommonService _commonService = new CommonService();
        private readonly Dictionary<int, SessionData> _dictionary = SessionData.GetSessionValues();
        private readonly ProductionService _productionService = new ProductionService();
        private readonly LcdGlueStationService _lcdGlueStationService = new LcdGlueStationService();
        private readonly CKDService _ckdService = new CKDService();
        readonly CkdReportService _ckdReportService = new CkdReportService();

        //
        // GET: /CKD/



        public ActionResult SMT()
        {
            return View();
        }

        public ActionResult SoftwareLoad()
        {
            return View();
        }

        public ActionResult RF()
        {
            return View();
        }

        public ActionResult MMI()
        {
            return View();
        }


        #region  MMI Station Insert Code
        //For MMI
        [HttpPost]
        public JsonResult InsertCkdMmiStationInformation(tblCkdMmiMaster mmItabltestComponent, List<tblCkdRework> reworkList)
        {
            WCMSEntities entities = new WCMSEntities();
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            var result = new Result();

            try
            {
                var isBarCodeExists =
                    _ckdService.GetCkdMmiMasterInfo(new tblCkdMmiMaster { BarCode = mmItabltestComponent.BarCode })
                        .Any();

                if (isBarCodeExists)
                {

                    mmItabltestComponent.AddedBy = userId;
                    mmItabltestComponent.AddedDate = DateTime.Now;
                    mmItabltestComponent.UpdatedBy = userId;
                    mmItabltestComponent.UpdatedDate = DateTime.Now;

                    result = _ckdService.UpdateCkdMmiInfo(mmItabltestComponent);

                    if (result.IsSuccess == true && mmItabltestComponent.Passed.ToUpper() == "N")
                    {
                        var Reresult = new Result();
                        var rework = new tblCkdRework();

                        foreach (tblCkdRework item in reworkList)
                        {
                            rework.LineId = lineId;
                            rework.ProjectId = userId; //projectId;
                            rework.BarCode = item.BarCode;
                            rework.Issues = item.Issues;
                            rework.FailedStation = item.FailedStation;
                            rework.Type = item.Type;
                            rework.Model = item.Model;
                            rework.LotNumber = item.LotNumber;
                            rework.Supplier = item.Supplier;
                            rework.Code = item.Code;
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _ckdService.InsertCkdRework(rework);

                        }
                    }
                }



                else
                {
                    mmItabltestComponent.LineId = lineId;
                    mmItabltestComponent.AddedBy = userId;
                    mmItabltestComponent.AddedDate = DateTime.Now;
                    mmItabltestComponent.UpdatedBy = userId;
                    mmItabltestComponent.UpdatedDate = DateTime.Now;
                    result = _ckdService.InsertCkdMmiComponentInfo(mmItabltestComponent);

                    if (result.IsSuccess == true && mmItabltestComponent.Passed.ToUpper() == "N")
                    {
                        var Reresult = new Result();
                        tblCkdRework rework = new tblCkdRework();

                        foreach (tblCkdRework item in reworkList)
                        {
                            rework.LineId = lineId;
                            rework.ProjectId = userId; //projectId;
                            rework.BarCode = item.BarCode;
                            rework.Issues = item.Issues;
                            rework.FailedStation = item.FailedStation;
                            rework.Type = item.Type;
                            rework.Model = item.Model;
                            rework.LotNumber = item.LotNumber;
                            rework.Supplier = item.Supplier;
                            rework.Code = item.Code;
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _ckdService.InsertCkdRework(rework);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result.Message = ex.ToString();

            }
            return Json(result);
        }
        //For SMT
        #endregion

        [HttpPost]
        public JsonResult InsertSmtStationInformation(tblCkdSmtMaster smtTableTestComponent, List<tblCkdRework> reworkList)
        {
            WCMSEntities entities = new WCMSEntities();
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            var result = new Result();
            try
            {

                var isBarCodeExists =
                    _ckdService.GetCkdSmtMasterInfo(new tblCkdSmtMaster { BarCode = smtTableTestComponent.BarCode })
                        .Any();



                if (isBarCodeExists)
                {

                    smtTableTestComponent.AddedBy = userId;
                    smtTableTestComponent.AddedDate = DateTime.Now;
                    smtTableTestComponent.UpdatedBy = userId;
                    smtTableTestComponent.UpdatedDate = DateTime.Now;

                    result = _ckdService.UpdateCkdSmtInfo(smtTableTestComponent);

                    if (result.IsSuccess == true && smtTableTestComponent.Passed.ToUpper() == "N")
                    {
                        var Reresult = new Result();
                        var rework = new tblCkdRework();

                        foreach (tblCkdRework item in reworkList)
                        {
                            rework.LineId = lineId;
                            rework.ProjectId = projectId;
                            rework.BarCode = item.BarCode;
                            rework.Issues = item.Issues;
                            rework.FailedStation = item.FailedStation;
                            rework.Type = item.Type;
                            rework.Model = item.Model;
                            rework.LotNumber = item.LotNumber;
                            rework.Supplier = item.Supplier;
                            rework.Code = item.Code;
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _ckdService.InsertCkdRework(rework);

                        }
                    }
                }
                else
                {
                    smtTableTestComponent.LineId = lineId;
                    smtTableTestComponent.AddedBy = userId;
                    smtTableTestComponent.AddedDate = DateTime.Now;
                    smtTableTestComponent.UpdatedBy = userId;
                    smtTableTestComponent.UpdatedDate = DateTime.Now;
                    result = _ckdService.InsertCkdSmtComponentInfo(smtTableTestComponent);

                    if (result.IsSuccess == true && smtTableTestComponent.Passed.ToUpper() == "N")
                    {
                        var Reresult = new Result();
                        tblCkdRework rework = new tblCkdRework();

                        foreach (tblCkdRework item in reworkList)
                        {
                            rework.LineId = lineId;
                            rework.ProjectId = userId; //projectId;
                            rework.BarCode = item.BarCode;
                            rework.Issues = item.Issues;
                            rework.FailedStation = item.FailedStation;
                            rework.Type = item.Type;
                            rework.Model = item.Model;
                            rework.LotNumber = item.LotNumber;
                            rework.Supplier = item.Supplier;
                            rework.Code = item.Code;
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _ckdService.InsertCkdRework(rework);

                        }
                    }
                }




            }

            //}
            catch (Exception ex)
            {
                //throw ex;
                result.Message = ex.ToString();

            }
            return Json(result);
        }


        //For RF
        public JsonResult InsertRfStationInformation(tblCkdRfMaster rfTableTestComponent, List<tblCkdRework> reworkList)
        {

            WCMSEntities entities = new WCMSEntities();
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            var result = new Result();
            try
            {



                var isBarCodeExists =
                    _ckdService.GetCkdRfMasterInfo(new tblCkdRfMaster { BarCode = rfTableTestComponent.BarCode })
                        .Any();



                if (isBarCodeExists)
                {

                    rfTableTestComponent.AddedBy = userId;
                    rfTableTestComponent.AddedDate = DateTime.Now;
                    rfTableTestComponent.UpdatedBy = userId;
                    rfTableTestComponent.UpdatedDate = DateTime.Now;

                    result = _ckdService.UpdateCkdRfInfo(rfTableTestComponent);

                    if (result.IsSuccess == true && rfTableTestComponent.Passed.ToUpper() == "N")
                    {
                        var Reresult = new Result();
                        var rework = new tblCkdRework();

                        foreach (tblCkdRework item in reworkList)
                        {
                            rework.LineId = lineId;
                            rework.ProjectId = userId; //projectId;
                            rework.BarCode = item.BarCode;
                            rework.Issues = item.Issues;
                            rework.FailedStation = item.FailedStation;
                            rework.Type = item.Type;
                            rework.Model = item.Model;
                            rework.LotNumber = item.LotNumber;
                            rework.Supplier = item.Supplier;
                            rework.Code = item.Code;
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _ckdService.InsertCkdRework(rework);

                        }
                    }
                }


                else
                {
                    rfTableTestComponent.LineId = lineId;
                    rfTableTestComponent.AddedBy = userId;
                    rfTableTestComponent.AddedDate = DateTime.Now;
                    rfTableTestComponent.UpdatedBy = userId;
                    rfTableTestComponent.UpdatedDate = DateTime.Now;
                    result = _ckdService.InsertCkdRfComponentInfo(rfTableTestComponent);

                    if (result.IsSuccess == true && rfTableTestComponent.Passed.ToUpper() == "N")
                    {
                        var Reresult = new Result();
                        tblCkdRework rework = new tblCkdRework();

                        foreach (tblCkdRework item in reworkList)
                        {
                            rework.LineId = lineId;
                            rework.ProjectId = userId; //projectId;
                            rework.BarCode = item.BarCode;
                            rework.Issues = item.Issues;
                            rework.FailedStation = item.FailedStation;
                            rework.Type = item.Type;
                            rework.Model = item.Model;
                            rework.LotNumber = item.LotNumber;
                            rework.Supplier = item.Supplier;
                            rework.Code = item.Code;
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _ckdService.InsertCkdRework(rework);

                        }
                    }
                }







            }
            catch (Exception ex)
            {
                result.Message = ex.ToString();
                //throw ex;
            }
            return Json(result);
        }

        //For Software Load
        public JsonResult InsertSoftwareLoadStationInformation(tblCkdSoftwareLoadMaster softwareLoadTableTestComponent, List<tblCkdRework> reworkList)
        {
            WCMSEntities entities = new WCMSEntities();
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            long lineId = (long)_dictionary[4].Id;
            var result = new Result();
            try
            {



                var isBarCodeExists =
                    _ckdService.GetCkdSoftwareLoadMasterInfo(new tblCkdSoftwareLoadMaster { BarCode = softwareLoadTableTestComponent.BarCode })
                        .Any();



                if (isBarCodeExists)
                {

                    softwareLoadTableTestComponent.AddedBy = userId;
                    softwareLoadTableTestComponent.AddedDate = DateTime.Now;
                    softwareLoadTableTestComponent.UpdatedBy = userId;
                    softwareLoadTableTestComponent.UpdatedDate = DateTime.Now;

                    result = _ckdService.UpdateCkdSoftwareLoadInfo(softwareLoadTableTestComponent);

                    if (result.IsSuccess == true && softwareLoadTableTestComponent.Passed.ToUpper() == "N")
                    {
                        var Reresult = new Result();
                        var rework = new tblCkdRework();

                        foreach (tblCkdRework item in reworkList)
                        {
                            rework.LineId = lineId;
                            rework.ProjectId = userId; //projectId;
                            rework.BarCode = item.BarCode;
                            rework.Issues = item.Issues;
                            rework.FailedStation = item.FailedStation;
                            rework.Type = item.Type;
                            rework.Model = item.Model;
                            rework.LotNumber = item.LotNumber;
                            rework.Supplier = item.Supplier;
                            rework.Code = item.Code;
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _ckdService.InsertCkdRework(rework);

                        }
                    }
                }

                else
                {
                    softwareLoadTableTestComponent.LineId = lineId;
                    softwareLoadTableTestComponent.AddedBy = userId;
                    softwareLoadTableTestComponent.AddedDate = DateTime.Now;
                    softwareLoadTableTestComponent.UpdatedBy = userId;
                    softwareLoadTableTestComponent.UpdatedDate = DateTime.Now;
                    result = _ckdService.InsertCkdSoftwareLoadComponentInfo(softwareLoadTableTestComponent);

                    if (result.IsSuccess == true && softwareLoadTableTestComponent.Passed.ToUpper() == "N")
                    {
                        var Reresult = new Result();
                        tblCkdRework rework = new tblCkdRework();

                        foreach (tblCkdRework item in reworkList)
                        {
                            rework.LineId = lineId;
                            rework.ProjectId = userId; //projectId;
                            rework.BarCode = item.BarCode;
                            rework.Issues = item.Issues;
                            rework.FailedStation = item.FailedStation;
                            rework.Type = item.Type;
                            rework.Model = item.Model;
                            rework.LotNumber = item.LotNumber;
                            rework.Supplier = item.Supplier;
                            rework.Code = item.Code;
                            rework.Status = "P";
                            rework.AddedBy = userId;
                            rework.AddedDate = DateTime.Now;

                            Reresult = _ckdService.InsertCkdRework(rework);

                        }
                    }


                }



            }
            catch (Exception ex)
            {
                result.Message = ex.ToString();
                //throw ex;
            }
            return Json(result);
        }
        //count


        public JsonResult GetSoftwareLoadQrCount()
        {
            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                var userId = (long)_dictionary[2].Id;
                var projectId = (long)_dictionary[3].Id;
                var lineId = (long)_dictionary[4].Id;

                var totalQrCount = _ckdService.GetSoftwareLoadQrCount().Where(a => a.AddedBy == userId).ToList();

                var passedCount = totalQrCount.Where(x => x.Passed == "Y").ToList();

                var failedCount = totalQrCount.Where(x => x.Passed == "N").ToList();


                var objstate = totalQrCount.Select(x => new { totalQr = totalQrCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count() }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }




        public JsonResult GetSmtQrCount()
        {
            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                var userId = (long)_dictionary[2].Id;
                var projectId = (long)_dictionary[3].Id;
                var lineId = (long)_dictionary[4].Id;

                var totalSmtQrCount = _ckdService.GetSmtQrCount().Where(a => a.AddedBy == userId).ToList();

                var passedCount = totalSmtQrCount.Where(x => x.Passed == "Y").ToList();
                var failedCount = totalSmtQrCount.Where(x => x.Passed == "N").ToList();


              //  var failedCount = _ckdService.GetSmtQrCount(new tblCkdRework() { AddedBy = userId, FailedStation = "SMTQR" })
              //.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();

                var objstate = totalSmtQrCount.Select(x => new { totalQr = totalSmtQrCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count() }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }






        public JsonResult GetRfQrCount()
        {
            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                var userId = (long)_dictionary[2].Id;
                var projectId = (long)_dictionary[3].Id;
                var lineId = (long)_dictionary[4].Id;

                var totalRfQrCount = _ckdService.GetRfQrCount().Where(a => a.AddedBy == userId).ToList();


                var passedCount = totalRfQrCount.Where(x => x.Passed == "Y").ToList();
                var failedCount = totalRfQrCount.Where(x => x.Passed == "N").ToList();


                //  var failedCount = _ckdService.GetRfQrCount(new tblCkdRework() { AddedBy = userId, FailedStation = "SMTQR" })
                //.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();

                var objstate = totalRfQrCount.Select(x => new { totalQr = totalRfQrCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count() }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

        public JsonResult GetMmiQrCount()
        {
            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                var userId = (long)_dictionary[2].Id;
                var projectId = (long)_dictionary[3].Id;
                var lineId = (long)_dictionary[4].Id;

                var totalMmiQrCount = _ckdService.GetMmiQrCount().Where(a => a.AddedBy == userId).ToList();


                var passedCount = totalMmiQrCount.Where(x => x.Passed == "Y").ToList();
                var failedCount = totalMmiQrCount.Where(x => x.Passed == "N").ToList();


                //  var failedCount = _ckdService.GetMmiQrCount(new tblCkdRework() { AddedBy = userId, FailedStation = "SMTQR" })
                //.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();

                var objstate = totalMmiQrCount.Select(x => new { totalQr = totalMmiQrCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count() }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

        public JsonResult DisplayPassFailCount(string date)
        {
            var list = _ckdReportService.DisplayPassFailCount(date).OrderBy(a => a.LineId).ToList();
            var list1 = new List<CkdModel>();
            //var current = DateTime.Now;
            return Json(list, JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetAllIssueList()
        {
            var IssueList = new List<tblCkdIssues>();
            try
            {
                IssueList = _ckdService.GetAllIssueList().Where(a => a.Station == "MMI").ToList();
                //IssueList = _ckdService.GetAllIssueList().Where(a => a.Category == "F").OrderBy(s => s.Name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(IssueList, JsonRequestBehavior.AllowGet);
        }




    }

   
}