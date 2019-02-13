
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    public class ProjectComponentsController : Controller
    {
        private CommonService _CommonService = new CommonService();


        private Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
        private ProductionService productionService = new ProductionService();
        // GET: /ProjectComponents/


        [HttpGet]
        public ActionResult DailyPacking()
        {



            return View();


        }

        [HttpGet]
        public ActionResult ProjectWiseBomList()
        {
            long userId = (long) IDictionary[2].Id;
            long projectId = (long) IDictionary[3].Id;

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
        public ActionResult ComponentRequisition()
        {
            long userId = (long) IDictionary[2].Id;
            long projectId = (long) IDictionary[3].Id;

            if (userId != 0)
            {
                return View();
            }

            else
            {
                return RedirectToAction("LogOut", "Account");


            }


        }

        //for add project materials// project bom list
        [HttpGet]
        public ActionResult AddProjectmaterials()
        {
            long userId = (long) IDictionary[2].Id;
            long projectId = (long) IDictionary[3].Id;

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
        public ActionResult ComponentRequisitionList()
        {
            long userId = (long) IDictionary[2].Id;
            long projectId = (long) IDictionary[3].Id;

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
        public ActionResult ProjectWiseBomLists()
        {
            long userId = (long) IDictionary[2].Id;
            long projectId = (long) IDictionary[3].Id;

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
        public ActionResult DailyIssuedProjectComponents()
        {
            long userId = (long) IDictionary[2].Id;
            long projectId = (long) IDictionary[3].Id;

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
        public ActionResult ScrewStation()
        {
            long userId = (long)IDictionary[2].Id;
            long projectId = (long)IDictionary[3].Id;

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
        public JsonResult GetComponentReqList(string reqNumber)
        {

            long userId = (long) IDictionary[2].Id;

            var reqList = _CommonService.GetComponentReqList(reqNumber).ToList();
            return Json(new {data = reqList}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetMaterialById(int id)
        {

            long userId = (long) IDictionary[2].Id;

            var reqList = _CommonService.GetMaterialInfo(new BomList() {Id = Convert.ToInt32(id)}).FirstOrDefault();
            return Json(reqList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProjectWiseBomList(int projectId)
        {

            long userId = (long) IDictionary[2].Id;

            var list =
                _CommonService.GetProjectWiseBomList(new ProjectBomList() {ProjectMasterId = Convert.ToInt32(projectId)});
            return Json(new {data = list}, JsonRequestBehavior.AllowGet);
        }



        public JsonResult InsertBomList(List<BomList> bomList)
        {

            long userId = (long) IDictionary[2].Id;
            if (userId != 0)

            {

                Result result;
                try
                {

                    result = _CommonService.InsertBomList(bomList, userId);

                }
                catch (Exception)
                {

                    throw;
                }

                return Json(result);
            }
            else
            {
                return Json(new Result {Id = "0"});
            }

        }

        [HttpPost]
        public JsonResult InsertIssuedComponents(tblDailyIssuedComponents issuedComponents)
        {
            long userId = (long) IDictionary[2].Id;
            long projectId = (long) IDictionary[3].Id;
            long lineId = (long)IDictionary[4].Id;
            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(1).AddTicks(-1);
            var result = new Result();


            if (userId != 0 && lineId != 0 && projectId != 0)//&& lineId != 0 && projectId != 0
            {
              
                try
                {


                    var isComponentExists =
                        _CommonService.GetPCBInfo(new tblDailyIssuedComponents()
                        {
                            ComponentCode = (issuedComponents.ComponentCode).Trim()
                        }).FirstOrDefault();

                    if (isComponentExists == null)
                    {
                        issuedComponents.ProjectName = _CommonService.GetAssemblineInfo(new tblAssemblyLineSetup() { ProjectId = Convert.ToInt32(projectId) }).Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).Select(x => x.ProjectName).FirstOrDefault();
                        issuedComponents.ComponentName = issuedComponents.ComponentName;
                        issuedComponents.LineId = lineId;
                        issuedComponents.ComponentCode = issuedComponents.ComponentCode.Trim();
                        issuedComponents.ProjectId = projectId;
                        issuedComponents.AddedBy = userId;
                        result = _CommonService.InsertIssuedComponents(issuedComponents);
                        if (result.IsSuccess)
                        {


                            // var objstate = componentsCount.Select(x => new { pendingListCount = componentsCount.Count,message="Added Successfully" }).ToList();
                            return Json(result);
                        }
                    }


                    else
                    {
                        result.Message = "Duplicate PCB Code !";
                        return Json(result);
                    }



                }
                catch (Exception exception)
                {

                    throw;
                }

            }

            else
            {
                return Json(new Result { Id = "0" });
               // return Json(new Result {Message = "Error Occured Please Logout and Login Again !"});
            }

            return Json(result);

        }

        [HttpGet]
        public JsonResult GetIssuedComp()
        {
            long userId = (long)IDictionary[2].Id;
            long projectId = (long)IDictionary[3].Id;
            long lineId = (long)IDictionary[4].Id;
           // var componentsCount = _CommonService.CountIssuedComponents().Where(a=>a.ProjectId==projectId&&a.AddedBy==userId);
            var componentsCount = _CommonService.CountIssuedComponents().Where(a => a.AddedBy == userId);

            var objstate = componentsCount.Select(x => new {issuedComponent = componentsCount.Count()}).ToList();
            return Json(objstate, JsonRequestBehavior.AllowGet);

        }



        [HttpGet]
        public JsonResult GetScrewDoneCount()
        {
            long userId = (long)IDictionary[2].Id;
            long projectId = (long)IDictionary[3].Id;
            long lineId = (long)IDictionary[4].Id;
            //var screwDoneCount = _CommonService.GetScrewDoneCount().Where(a => a.ProjectId == projectId&&a.AddedBy==userId);
            var screwDoneCount = _CommonService.GetScrewDoneCount().Where(a =>a.AddedBy == userId);

            var objstate = screwDoneCount.Select(x => new { issuedComponent = screwDoneCount.Count() }).ToList();
            return Json(objstate, JsonRequestBehavior.AllowGet);

        }




        public JsonResult InsertComponentRequisition(List<tblComponentRequisition> componentListFinal)
        {
            long userId = (long) IDictionary[2].Id;
            long projectId = (long) IDictionary[3].Id;
            Result _Result = new Result();
            tblComponentRequisition componentRequisition = new tblComponentRequisition();


            if (userId != 0)
            {

                try
                {
                    foreach (tblComponentRequisition items in componentListFinal)
                    {

                        componentRequisition.ComponentId = items.ComponentId;
                        componentRequisition.ComponentName = items.ComponentName;
                        componentRequisition.ReqQuantity = items.ReqQuantity;
                        componentRequisition.OracleReqNumber = items.OracleReqNumber;
                        componentRequisition.OracleReqDate = items.OracleReqDate;
                        componentRequisition.UsedQuantity = 0;
                        componentRequisition.AddedBy = userId;
                        componentRequisition.AddedDate = DateTime.Now;

                        _Result = _CommonService.InsertComponentRequisition(componentRequisition);


                    }
                }
                catch (Exception)
                {

                    return Json("Error");
                }

                return Json(_Result);

            }
            else
            {
                return Json(new Result { Id = "0" });
            }

        }



        [HttpPost]
        public JsonResult InsertScrewStationInfo(tblScrew screw)
        
        {
            var result = new Result();
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            long userId = (long)IDictionary[2].Id;
            long projectId = (long)IDictionary[3].Id;
            long lineId = (long)IDictionary[4].Id;


            if (userId != 0 && lineId != 0)//&& lineId!=0
            {
                var pcbStation = _CommonService.GetPCBInfo(new tblDailyIssuedComponents() { ComponentCode = screw.MobileCode.Trim() }).FirstOrDefault();

                    var isExists = _CommonService.GetScrewStationInfo(new tblScrew() { MobileCode = screw.MobileCode.Trim() }).FirstOrDefault();
                    if (isExists == null )
                    {
                        if (pcbStation != null)
                        {
                            screw.LineId = lineId;
                            screw.ProjectName = pcbStation.ProjectName;// _CommonService.GetAssemblineInfo(new tblAssemblyLineSetup() { ProjectId = (int?)pcbStation.ProjectId }).Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).Select(x => x.ProjectName).FirstOrDefault();
                            screw.MobileCode = screw.MobileCode.Trim();
                            screw.ProjectId = pcbStation.ProjectId; //projectId;
                            screw.AddedBy = userId;
                            screw.AddedDate = DateTime.Now;
                            result = _CommonService.InsertScrewStationInfo(screw);
                            if (result.IsSuccess)
                            {
                                return Json(result);
                            }

                        }

                        else
                        {
                            result.Message = "Not Scanned At PCB Station!!";
                            return Json(result);
                        }
                       
                    }
                 
                     else
                    {
                        result.Message = "Duplicate  Bar Code Number!!";
                        return Json(result);
                    }
                       
            }

            else
            {
                return Json(new Result { Id = "0" });
            }

            return Json(result);



        }


    }
}