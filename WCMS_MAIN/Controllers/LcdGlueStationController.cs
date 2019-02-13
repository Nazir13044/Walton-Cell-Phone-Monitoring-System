using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    public class LcdGlueStationController : Controller
    {
        readonly CommonService _commonService = new CommonService();
        readonly Dictionary<int, SessionData> _dictionary = SessionData.GetSessionValues();
        readonly ProductionService _productionService = new ProductionService();
        readonly LcdGlueStationService _lcdGlueStationService = new LcdGlueStationService();



        [HttpGet]
        public ActionResult TpLcd()
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
        public ActionResult GlueStation()
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




        public JsonResult AddWorkingProject(tblLcdGlueWorkingModels workingModels)
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;

            var workingModel = new tblLcdGlueWorkingModels();
            workingModel.ProjectId = workingModels.ProjectId;
            workingModel.ProjectName = workingModels.ProjectName;
            workingModel.Station = workingModels.Station;
            workingModel.AddedBy = userId;
            workingModel.AddedDate = DateTime.Now;

            var result = _lcdGlueStationService.InsertLcdGlueWorkingModels(workingModel);
            if (result.IsSuccess)
            {
                var updateResult = _lcdGlueStationService.UpdateGlueWorkingModels(workingModel);

            }

            return Json(result);
        }

        public JsonResult LoadWorkingModelDataTplcd()
        {

            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            var list = new List<tblLcdGlueWorkingModels>();
            try
            {
                list = _lcdGlueStationService.LoadWorkingModelData().Where(a => a.AddedBy == userId &&a.Station=="TPLCD").ToList();
            }
            catch (Exception ex)
            {

            }

            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadWorkingModelDataGlue()
        {

            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            var list = new List<tblLcdGlueWorkingModels>();
            try
            {
                list = _lcdGlueStationService.LoadWorkingModelData().Where(a => a.AddedBy == userId && a.Station == "GLUE").ToList();
            }
            catch (Exception ex)
            {

            }

            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
        }




        public JsonResult UpdateProject(long projectId)
        {
              var userId = (long)_dictionary[2].Id;

            try
            {
                var workingModel = new tblLcdGlueWorkingModels();
                workingModel.Id = projectId;
                workingModel.AddedBy = userId;

                var updateResult = _lcdGlueStationService.UpdateGlueWorkingModels(workingModel);
                return Json(updateResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }




        public JsonResult InsertTpLcdStation(tblTpLcdMaster tpLcdData, List<tblLcdGlueRework> reworkList)
        {

            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            var result = new Result();


            try
            {
                var isExists =_lcdGlueStationService.GetTpLcdStationInfo(new tblTpLcdMaster { Code = tpLcdData.Code });
                var workingProject =
                      _lcdGlueStationService.LoadWorkingModelData()
                          .FirstOrDefault(a => a.AddedBy == userId && a.CurentlyRunning == "Y");


                if (isExists == null)
                {
                  

                    if (workingProject != null)
                    {
                        var tblTpLcdMaster = new tblTpLcdMaster();
                        tblTpLcdMaster.Code = tpLcdData.Code;
                        tblTpLcdMaster.ProjectId = workingProject.ProjectId;
                        tblTpLcdMaster.ProjectName = workingProject.ProjectName;
                        tblTpLcdMaster.Passed = tpLcdData.Passed.ToUpper();
                        tblTpLcdMaster.AddedBy = userId;
                        tblTpLcdMaster.AddedDate = DateTime.Now;

                        result = _lcdGlueStationService.InsertTpLcdStation(tblTpLcdMaster);
                        if (result.IsSuccess == true && tpLcdData.Passed.ToUpper() == "N")
                        {
                            var Reresult = new Result();
                            var rework = new tblLcdGlueRework();

                            foreach (tblLcdGlueRework item in reworkList)
                            {
                                //rework.LineId = lineId;
                                rework.ProjectId = workingProject.ProjectId;
                                rework.ProjectName = workingProject.ProjectName;
                                rework.Code = tpLcdData.Code;
                                rework.Issue = item.Issue;
                                rework.FailedFrom = "TPLCD";
                                rework.Status = "P";
                                rework.AddedBy = userId;
                                rework.AddedDate = DateTime.Now;

                                Reresult = _lcdGlueStationService.InsertTpLcdReworkStation(rework);

                            }
                        }
                    }

                    else
                    {
                        result.Message = "No Project Or Model Found";
                    }

                 
                }

                else
                {

                    if (workingProject != null)
                    {


                        var tblTpLcdMaster = new tblTpLcdMaster();
                        tblTpLcdMaster.Code = tpLcdData.Code;
                        //tblTpLcdMaster.ProjectId = workingProject.ProjectId;
                        //tblTpLcdMaster.ProjectName = workingProject.ProjectName;
                        tblTpLcdMaster.Passed = tpLcdData.Passed.ToUpper();
                        tblTpLcdMaster.UpdatedBy = userId;
                        tblTpLcdMaster.UpdatedDate = DateTime.Now;

                        result = _lcdGlueStationService.UpdateTpLcdStation(tblTpLcdMaster);
                        if (result.IsSuccess == true && tpLcdData.Passed.ToUpper() == "N")
                        {
                            var Reresult = new Result();
                            var rework = new tblLcdGlueRework();

                            foreach (tblLcdGlueRework item in reworkList)
                            {
                                //rework.LineId = lineId;
                                rework.ProjectId = isExists.ProjectId;
                                rework.ProjectName = workingProject.ProjectName;
                                rework.Code = tpLcdData.Code;
                                rework.Issue = item.Issue;
                                rework.FailedFrom = "TPLCD";
                                rework.Status = "P";
                                rework.AddedBy = userId;
                                rework.AddedDate = DateTime.Now;

                                Reresult = _lcdGlueStationService.InsertTpLcdReworkStation(rework);

                            }
                        }

                    }


                    else
                    {
                        result.Message = "No Project Or Model Found";
                    }

                }


            }
            catch (Exception)
            {
                
                throw;
            }
            return Json(result);
        }



        public JsonResult InsertGlueStation(tblGlueMaster glueMaster, List<tblLcdGlueRework> reworkList)
        {

            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            var result = new Result();


            try
            {
                var isExists = _lcdGlueStationService.GetGlueStationInfo(new tblGlueMaster { Code = glueMaster.Code });
                var workingProject =
                      _lcdGlueStationService.LoadWorkingModelData()
                          .FirstOrDefault(a => a.AddedBy == userId && a.CurentlyRunning == "Y");


                if (isExists == null)
                {


                    if (workingProject != null)
                    {
                        var tblGlueMaster = new tblGlueMaster();
                        tblGlueMaster.Code = glueMaster.Code;
                        tblGlueMaster.ProjectId = workingProject.ProjectId;
                        tblGlueMaster.ProjectName = workingProject.ProjectName;
                        tblGlueMaster.Passed = glueMaster.Passed.ToUpper();
                        tblGlueMaster.AddedBy = userId;
                        tblGlueMaster.AddedDate = DateTime.Now;

                        result = _lcdGlueStationService.InsertGlueStation(tblGlueMaster);
                        if (result.IsSuccess == true && glueMaster.Passed.ToUpper() == "N")
                        {
                            var Reresult = new Result();
                            var rework = new tblLcdGlueRework();

                            foreach (tblLcdGlueRework item in reworkList)
                            {
                                //rework.LineId = lineId;
                                rework.ProjectId = workingProject.ProjectId;
                                rework.ProjectName = workingProject.ProjectName;
                                rework.Code = glueMaster.Code;
                                rework.Issue = item.Issue;
                                rework.FailedFrom = "GLUE";
                                rework.Status = "P";
                                rework.AddedBy = userId;
                                rework.AddedDate = DateTime.Now;

                                Reresult = _lcdGlueStationService.InsertTpLcdReworkStation(rework);

                            }
                        }
                    }

                    else
                    {
                        result.Message = "No Project Or Model Found";
                    }


                }

                else
                {


                    if (workingProject != null)
                    {


                        var tblglueMaster = new tblGlueMaster();
                        tblglueMaster.Code = glueMaster.Code;
                        //tblTpLcdMaster.ProjectId = workingProject.ProjectId;
                        //tblTpLcdMaster.ProjectName = workingProject.ProjectName;
                        tblglueMaster.Passed = glueMaster.Passed.ToUpper();
                        tblglueMaster.UpdatedBy = userId;
                        tblglueMaster.UpdatedDate = DateTime.Now;

                        result = _lcdGlueStationService.UpdateGlueStation(tblglueMaster);
                        if (result.IsSuccess == true && glueMaster.Passed.ToUpper() == "N")
                        {
                            var Reresult = new Result();
                            var rework = new tblLcdGlueRework();

                            foreach (tblLcdGlueRework item in reworkList)
                            {
                                //rework.LineId = lineId;
                                rework.ProjectId = isExists.ProjectId;
                                rework.ProjectName = workingProject.ProjectName;
                                rework.Code = glueMaster.Code;
                                rework.Issue = item.Issue;
                                rework.FailedFrom = "GLUE";
                                rework.Status = "P";
                                rework.AddedBy = userId;
                                rework.AddedDate = DateTime.Now;

                                Reresult = _lcdGlueStationService.InsertTpLcdReworkStation(rework);

                            }
                        }

                    }

                    else
                    {
                        result.Message = "No Project Or Model Found";
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
            return Json(result);
        }














        [HttpGet]
        public JsonResult CountTpLcdStationinput()
        {
            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                var userId = (long)_dictionary[2].Id;
                var totalQcComponentsCount = _lcdGlueStationService.CountTpLcdStationinput().Where(a => a.AddedBy == userId).ToList();
                var passedCount = totalQcComponentsCount.Where(x => x.Passed == "Y").ToList();
                var failedCount = _lcdGlueStationService.GetTpLcdIssuesCount(new tblLcdGlueRework() { AddedBy = userId, FailedFrom = "TPLCD" })
               .Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();

                var objstate = totalQcComponentsCount.Select(x => new { totalChecked = totalQcComponentsCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count() }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult CountGlueStationinput()
        {
            try
            {
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);
                var userId = (long)_dictionary[2].Id;
                var totalQcComponentsCount = _lcdGlueStationService.CountGlueStationinput().Where(a => a.AddedBy == userId).ToList();
                var passedCount = totalQcComponentsCount.Where(x => x.Passed == "Y").ToList();
                var failedCount = _lcdGlueStationService.GetTpLcdIssuesCount(new tblLcdGlueRework() { AddedBy = userId, FailedFrom = "GLUE" })
               .Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();

                var objstate = totalQcComponentsCount.Select(x => new { totalChecked = totalQcComponentsCount.Count(), passedCount = passedCount.Count(), failedCount = failedCount.Count() }).ToList();
                return Json(objstate, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }












        [HttpGet]
        public JsonResult GetAllIssueList()
        {
            var eList = new List<tblLcdGlueIssuesList>();
            try
            {
                eList = _lcdGlueStationService.GetAllIssueList().ToList();
            }
            catch (Exception ex)
            {

            }
            // var objstate = e_List.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(eList, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult CallOracleTest(string model,string color)
        {
            var eList = new List<ProjectBomMode>();
            try
            {
                eList = _lcdGlueStationService.CallOracleTest(model.ToLower(), color).OrderBy(s => s.SPARE_DESCRIPTION).ToList();
            }
            catch (Exception ex)
            {

            }
            // var objstate = e_List.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(eList, JsonRequestBehavior.AllowGet);
        }

        


    }
}