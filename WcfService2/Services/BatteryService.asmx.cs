using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WCMS_BLL.Manager;
using WCMS_COMMON;
using WCMS_ENTITY;
using BR_BLL;
using WCMS_COMMON;
using WCMS_ENTITY;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WCMS_MAIN.Models;

namespace WcfService2.Services
{
    /// <summary>
    /// Summary description for BatteryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BatteryService : System.Web.Services.WebService
    {
        private BatteryManager _batteryManager = new BatteryManager();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public Result InsertBatteryComponentInfo(tblBatteryComponentInfo batteryComponent)
        {
            try
            {
                //tblBatteryComponentInfo batteryComponents = null;
                return _batteryManager.InsertBatteryComponentInfo(batteryComponent);
            }
            catch (Exception ex)
            {
               
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }


        public List<tblBatteryComponentInfo> ProjectNameExist(tblBatteryComponentInfo tblLineSetup)
         {
             var list = new List<tblBatteryComponentInfo>();
             try
             {
                 list = _batteryManager.ProjectNameExist(tblLineSetup);
             }
             catch (Exception ex)
             {

             }
             return list;
         }

        public List<tblBatteryComponentInfo> GetListByPcbIssue()
        {
            var list = new List<tblBatteryComponentInfo>();
            try
            {
                list = _batteryManager.GetListByPcbIssue();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }


        public List<tblBatteryComponentInfo> GetLineListById(int id)
        {
            var list = new List<tblBatteryComponentInfo>();
            try
            {
                list = _batteryManager.GetLineListById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public Result UpdateBatteryLine(tblBatteryComponentInfo productionLine)
        {
            try
            {
                return _batteryManager.UpdateBatteryLine(productionLine);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }


        public Result DeleteProductionLine(int id)
        {
            try
            {
                return _batteryManager.DeleteProductionLine(id);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }


        //public Result InsertProductionLine(tblBatteryComponentInfo productionLine)
        //{
        //    try
        //    {
        //        return _batteryManager.InsertProductionLine(productionLine);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result { IsSuccess = false, Message = ex.Message };
        //    }
        //}


      

      
    }
}
