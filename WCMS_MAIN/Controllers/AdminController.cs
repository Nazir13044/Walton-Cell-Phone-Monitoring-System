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
using WCMS_MAIN.Models;
using TransactionScope = System.Activities.Statements.TransactionScope;

namespace WCMS_MAIN.Controllers
{
    public class AdminController : Controller
    {
        readonly AdminService _adminService = new AdminService();
        readonly CommonService _commonService = new CommonService();
        readonly ProductionService _productionService = new ProductionService();
        private readonly Dictionary<int, SessionData> _dictionary = SessionData.GetSessionValues();
        //
        // GET: /Admin/
        public ActionResult AdminPanel()
        {
            var userId = (long)_dictionary[2].Id;
            long projectId = (long)_dictionary[3].Id;

            if (userId != 0)
            {
                return View();
            }

            else
            {
                return RedirectToAction("LogOut", "Account");


            }
        }

        public ActionResult AssemblyLine()
        {

            var userId = (long)_dictionary[2].Id;


            if (userId != 0)
            {
                return View();
            }

            else
            {
                return RedirectToAction("LogOut", "Account");


            }
        }


        public ActionResult AssemblyLineStatus()
        {

            var userId = (long)_dictionary[2].Id;


            if (userId != 0)
            {
                return View();
            }

            else
            {
                return RedirectToAction("LogOut", "Account");


            }
        }




        public ActionResult LineAssign()
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
        public ActionResult Logistics()
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
        public ActionResult UploadModelImei()
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

        public ActionResult LoadImeiDetails(string fromdate, string todate, string model, string color)
        {

            ViewBag.fromdate = fromdate;
            ViewBag.todate = todate;
            ViewBag.model = model;
            ViewBag.color = color;
            return View();

        }



        public JsonResult InsertRoles(tblRoles roles)
        {
            Result result;
            result = _adminService.InsertRoles(roles);
            return Json(result);

        }

        public JsonResult InsertMainMenu(tblMainMenu tblMainMenu)
        {
            var result = new Result();
            result = _adminService.InsertMainMenu(tblMainMenu);
            return Json(result);

        }


        //Search Main Menus

        public JsonResult GetMainMenusNames(string term)
        {
            var list = new List<tblMainMenu>();
            try
            {
                list = _adminService.GetMainMenusNames().Where(x => x.MainMenu.ToLower().Contains(term.ToLower())).ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.MainMenu, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }

        //Search role Name

        public JsonResult GetUserRoleNames(string term)
        {
            var list = new List<tblRoles>();
            try
            {
                list = _adminService.GetUserRoleNames().Where(x => x.Roles.ToLower().Contains(term.ToLower())).ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.Roles, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUserRoleNames()
        {
            var list = new List<tblRoles>();
            try
            {
                list = _adminService.GetUserRoleNames().ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.Roles, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }




        public JsonResult InsertSubMenu(tblSubMenu tblSubMenu)
        {
            var result = new Result();
            result = _adminService.InsertSubMenu(tblSubMenu);
            return Json(result);

        }



        #region Production Line Setup Actions

        public JsonResult InsertProductionLine(tblProductionLine productionLine)
        {
            var userId = (long)_dictionary[2].Id;
            var result = new Result();

            if (userId != 0)
            {
                try
                {
                    string lineName = productionLine.LineName.Substring(0, 1);
                    //if (lineName=="L")
                    productionLine.LineCriteria = productionLine.LineCriteria;
                    //if (lineName == "P")
                       // productionLine.LineCriteria = "PackagingLine";

                    productionLine.AddedBy = userId;
                    productionLine.AddedDate = DateTime.Now;
                    result = _adminService.InsertProductionLine(productionLine);
                    return Json(result);

                }
                catch (Exception ex)
                {

                    return Json(ex);
                }
            }

            else
            {
                return Json(new Result { Id = "0" });
            }



        }


        public JsonResult GetLineList()
        {


            var list = new List<tblProductionLine>();
            try
            {
                list = _adminService.GetLineList().ToList();
            }
            catch (Exception ex)
            {

            }

            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetRegEmployee(string term)
        {


            var list = new List<tblLogin>();
            try
            {
                list = _commonService.GetRegEmployee(term).ToList();


            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.EmployeeName, Id = x.Id, Line = x.LineName, Role = x.RoleName }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }




        public JsonResult GetLineListById(int id)
        {

            var list = new List<tblProductionLine>();
            try
            {
                list = _adminService.GetLineListById(id).ToList();
            }
            catch (Exception ex)
            {

            }

            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult UpdateProductionLine(tblProductionLine productionLine)
        {

            Result result;
            result = _adminService.UpdateProductionLine(productionLine);
            return Json(result);
        }

        public JsonResult UpdateUserLineInfo(tblLogin assemblyLine)
        {

            var userId = (long)_dictionary[2].Id;
            var result = new Result();

            if (userId != 0)
            {


                try
                {
                    assemblyLine.AddedBy = userId;
                    assemblyLine.AddedDate = DateTime.Now;
                    result = _adminService.UpdateUserLineInfo(assemblyLine);
                    return Json(result);
                }
                catch (Exception ex)
                {

                    return Json(ex);
                }
            }
            else
            {
                return Json(new Result { Id = "0" });
            }

        }



        public JsonResult DeleteProductionLine(int id)
        {

            var result = new Result();
            result = _adminService.DeleteProductionLine(id);
            return Json(result);
        }


        public JsonResult InsertProductionLineSetup(tblAssemblyLineSetup assemblyLine, List<tblAssemblyLineSetupDetails> assemblyLineSetupDetails)
        {
            Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            var userId = (long)IDictionary[2].Id;

            var result = new Result();

            var tblAssemblyLineSetup = new tblAssemblyLineSetup();
            try
            {


                tblAssemblyLineSetup.AssemblyLineId = assemblyLine.AssemblyLineId;
                tblAssemblyLineSetup.ProjectId = assemblyLine.ProjectId;
                tblAssemblyLineSetup.ProjectName = assemblyLine.ProjectName;
                tblAssemblyLineSetup.ManPower = assemblyLine.ManPower;
                tblAssemblyLineSetup.IssuedQuantity = assemblyLine.IssuedQuantity;
                tblAssemblyLineSetup.HourlyTargetQuantity = assemblyLine.HourlyTargetQuantity;
                tblAssemblyLineSetup.TotalTargetQuantity = assemblyLine.TotalTargetQuantity;
                tblAssemblyLineSetup.AddedBy = (int)userId;
                tblAssemblyLineSetup.AddedDate = DateTime.Now;
                result = _adminService.InsertProductionLineSetup(tblAssemblyLineSetup);


                if (result.IsSuccess)
                {
                    var tblAssemblyLineSetupDetails = new tblAssemblyLineSetupDetails();
                    foreach (var items in assemblyLineSetupDetails)
                    {
                        tblAssemblyLineSetupDetails.LineId = assemblyLine.AssemblyLineId;
                        tblAssemblyLineSetupDetails.ProjectId = items.ProjectId;
                        tblAssemblyLineSetupDetails.ComponentId = items.ComponentId;
                        tblAssemblyLineSetupDetails.ComponentName = items.ComponentName;
                        tblAssemblyLineSetupDetails.RequisitionQuantity = items.RequisitionQuantity;
                        tblAssemblyLineSetupDetails.SubmitQuantity = items.SubmitQuantity;
                        tblAssemblyLineSetupDetails.AddedBy = (int)userId;
                        tblAssemblyLineSetupDetails.AddedDate = DateTime.Now;
                        result = _adminService.InsertProductionLineSetupDetails(tblAssemblyLineSetupDetails);


                        if (result.IsSuccess)
                        {

                            result = _commonService.UpdateComponentRequisitionList(tblAssemblyLineSetupDetails);

                        }

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return Json(result);
        }




        #endregion

        public JsonResult GetComponentsByProject(int projectId)
        {

            var _entity = new WCMSEntities();

            var list = _entity.ProjectBomList.Where(a => a.ProjectMasterId == projectId).ToList();

            var component = new List<tblComponentRequisition>();

            foreach (var items in list)
            {

                var com = _entity.tblComponentRequisition.FirstOrDefault(x => x.ComponentId == items.ComponentId);

                var tblComponentRequisition = new tblComponentRequisition();

                if (com != null)
                {
                    tblComponentRequisition.ComponentId = com.ComponentId;
                    tblComponentRequisition.ComponentName = com.ComponentName;
                    tblComponentRequisition.ReqQuantity = com.ReqQuantity - com.UsedQuantity;
                }

                else
                {
                    tblComponentRequisition.ComponentId = items.ComponentId;
                    tblComponentRequisition.ComponentName = items.ComponentName;
                    tblComponentRequisition.ReqQuantity = 0;
                }
                component.Add(tblComponentRequisition);

            }


            return Json(component, JsonRequestBehavior.AllowGet);

        }




        //Save Line Status

        [HttpPost]
        public JsonResult InsertLineStatus(tblLineStatus lineStatus)
        {
            var userId = (long)_dictionary[2].Id;
            var projectId = (long)_dictionary[3].Id;
            var result = new Result();

            lineStatus.AddedBy = userId;
            lineStatus.AddedDate = DateTime.Now;
            result = _adminService.InsertLineStatus(lineStatus);
            return Json(result);

        }



        public JsonResult GetLinesStausList()
        {


            var list = new List<tblLineStatus>();
            try
            {
                list = _adminService.GetLinesStausList().ToList();
            }
            catch (Exception ex)
            {

            }

            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertManualProductionLineSetup(tblAssemblyLineSetup assemblyLine)
        {
            Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            var userId = (long)IDictionary[2].Id;

            var result = new Result();

            var tblAssemblyLineSetup = new tblAssemblyLineSetup();
            try
            {

                tblAssemblyLineSetup.AssemblyLineId = assemblyLine.AssemblyLineId;
                tblAssemblyLineSetup.ProjectId = assemblyLine.ProjectId;
                tblAssemblyLineSetup.ProjectName = assemblyLine.ProjectName;
                tblAssemblyLineSetup.ManPower = assemblyLine.ManPower;
                tblAssemblyLineSetup.IssuedQuantity = assemblyLine.IssuedQuantity;
                tblAssemblyLineSetup.HourlyTargetQuantity = assemblyLine.HourlyTargetQuantity;
                tblAssemblyLineSetup.TotalTargetQuantity = assemblyLine.TotalTargetQuantity;
                tblAssemblyLineSetup.PreviousQuantity = assemblyLine.PreviousQuantity;
                tblAssemblyLineSetup.AddedBy = (int)userId;
                tblAssemblyLineSetup.AddedDate = DateTime.Now;
                result = _adminService.InsertProductionLineSetup(tblAssemblyLineSetup);
            }
            catch (Exception)
            {
                
                throw;
            }



            return Json(result);
        }
      
       

        





    }
}