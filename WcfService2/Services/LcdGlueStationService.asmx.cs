using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WCMS_BLL.Manager;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;

namespace WcfService2.Services
{
    /// <summary>
    /// Summary description for LcdGlueStationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LcdGlueStationService :WebService
    {
        readonly LcdGlueStationManager _lcdGlueStationManager = new LcdGlueStationManager();

        [WebMethod]
        public Result InsertLcdGlueWorkingModels(tblLcdGlueWorkingModels workingModel)
        {
            try
            {
                return _lcdGlueStationManager.InsertLcdGlueWorkingModels(workingModel);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }
        [WebMethod]
        public Result UpdateGlueWorkingModels(tblLcdGlueWorkingModels workingModel)
        {
            try
            {
                return _lcdGlueStationManager.UpdateGlueWorkingModels(workingModel);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<tblLcdGlueWorkingModels> LoadWorkingModelData()
        {
            var list = new List<tblLcdGlueWorkingModels>();
            try
            {
                list = _lcdGlueStationManager.LoadWorkingModelData();
            }
            catch (Exception ex)
            {
                
            }

            return list;
        }

        public tblTpLcdMaster GetTpLcdStationInfo(tblTpLcdMaster tblTpLcdMaster)
        {
            var tplcd = new tblTpLcdMaster();

            try
            {
                tplcd = _lcdGlueStationManager.GetTpLcdStationInfo(tblTpLcdMaster);
            }
            catch (Exception ex)
            {

            }

            return tplcd;
        }

        public Result InsertTpLcdStation(tblTpLcdMaster tblTpLcdMaster)
        {
            try
            {
                return _lcdGlueStationManager.InsertTpLcdStation(tblTpLcdMaster);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertTpLcdReworkStation(tblLcdGlueRework rework)
        {
            try
            {
                return _lcdGlueStationManager.InsertTpLcdReworkStation(rework);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result UpdateTpLcdStation(tblTpLcdMaster tblTpLcdMaster)
        {
            try
            {
                return _lcdGlueStationManager.UpdateTpLcdStation(tblTpLcdMaster);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

       


        [WebMethod]
        public List<tblTpLcdMaster> CountTpLcdStationinput()
        {
            var list = new List<tblTpLcdMaster>();
            try
            {
                list = _lcdGlueStationManager.CountTpLcdStationinput();
            }
            catch (Exception ex)
            {

            }
            return list;
        }





        [WebMethod]

        public List<tblLcdGlueRework> GetTpLcdIssuesCount(tblLcdGlueRework rework)
        {
            var reworks = new List<tblLcdGlueRework>();
            try
            {
                reworks = _lcdGlueStationManager.GetTpLcdIssuesCount(rework);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Communication : " + ex.Message);
                //}
            }

            return reworks;
        }







        public List<tblLcdGlueIssuesList> GetAllIssueList()
        {
            var list = new List<tblLcdGlueIssuesList>();
            try
            {
                list = _lcdGlueStationManager.GetAllIssueList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }


        public tblGlueMaster GetGlueStationInfo(tblGlueMaster tblGlueMaster)
        {
            var tplcd = new tblGlueMaster();

            try
            {
                tplcd = _lcdGlueStationManager.GetGlueStationInfo(tblGlueMaster);
            }
            catch (Exception ex)
            {

            }

            return tplcd;
        }





        public Result InsertGlueStation(tblGlueMaster tblGlueMaster)
        {
            try
            {
                return _lcdGlueStationManager.InsertGlueStation(tblGlueMaster);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result UpdateGlueStation(tblGlueMaster tblglueMaster)
        {
            try
            {
                return _lcdGlueStationManager.UpdateGlueStation(tblglueMaster);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

       

        [WebMethod]
        public List<tblGlueMaster> CountGlueStationinput()
        {
            var list = new List<tblGlueMaster>();
            try
            {
                list = _lcdGlueStationManager.CountGlueStationinput();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<ProjectBomMode> CallOracleTest(string model, string color)
        {
            var list = new List<ProjectBomMode>();
            try
            {
                list = _lcdGlueStationManager.CallOracleTest(model,color);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
