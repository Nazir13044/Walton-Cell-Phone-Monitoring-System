using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WCMS_BLL.Manager;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;

namespace WcfService2.Services
{
    /// <summary>
    /// Summary description for ReportService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ReportService : System.Web.Services.WebService
    {
        private ReportManager reportManager=new ReportManager();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public List<DailyProductionModel> GetProductCount(int projectId, string date)
        {
            var model = new List<DailyProductionModel>();
            try
            {
                model = reportManager.GetProductCount(projectId, date);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Communication : " + ex.Message);
                //}
            }
            return model;
        }



        [WebMethod]
        public List<HourlyTargetModel> GetHourlyTaregtEfficiencyReport(int projectId, int lineId,string date)
        {

            var hourlyTargetList = new List<HourlyTargetModel>();

            try
            {
                hourlyTargetList = reportManager.GetHourlyTaregtEfficiencyReport(projectId,lineId, date );
               
            }
            catch (Exception ex)
            {
                
            }

            return hourlyTargetList;
        }


        [WebMethod]
        public List<OQcReportModel> GetOQcReport(int projectId, string date)
        {

            var oQcReport = new List<OQcReportModel>();

            try
            {
                oQcReport = reportManager.GetOQcReport(projectId, date);

            }
            catch (Exception ex)
            {

            }

            return oQcReport;
        }

        [WebMethod]
        public List<HourlyTargetModel> HourlyStationineWiseFault(int projectId, string date)
        {

            var hourlyTargetList = new List<HourlyTargetModel>();

            try
            {
                hourlyTargetList = reportManager.HourlyStationineWiseFault(projectId, date);

            }
            catch (Exception ex)
            {

            }

            return hourlyTargetList;
        }

        [WebMethod]
        public List<HourlyTargetModel> HourlyStationineWisestatus(string date)
        {
            var hourlyTargetList = new List<HourlyTargetModel>();

            try
            {
                hourlyTargetList = reportManager.HourlyStationineWisestatus(date);

            }
            catch (Exception ex)
            {

            }

            return hourlyTargetList;
        }

        public List<HourlyTargetModel> DisplayProductionCount(string date)
        {
            var List = new List<HourlyTargetModel>();

            try
            {
                List = reportManager.DisplayProductionCount(date);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

      


        public List<HourlyTargetModel> DisplayPackagingCount(string date)
        {
            var List = new List<HourlyTargetModel>();

            try
            {
                List = reportManager.DisplayPackagingCount(date);

            }
            catch (Exception ex)
            {

            }

            return List;
        }




        public List<HourlyTargetModel> GetLogisticsReport(string date, string project)
        {
            var List = new List<HourlyTargetModel>();

            try
            {
                List = reportManager.GetLogisticsReport(date, project);

            }
            catch (Exception ex)
            {

            }

            return List;
        }




        public List<HourlyTargetModel> GetLogisticsReportByDate(DateTime fromdate, DateTime todate)
        {
            var List = new List<HourlyTargetModel>();

            try
            {
                List = reportManager.GetLogisticsReportByDate(fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<tblLogistics> GetLogisticsReportWithDateModel(DateTime fromdate, DateTime todate, string model,string color)
        {
            var List = new List<tblLogistics>();

            try
            {
                List = reportManager.GetLogisticsReportWithDateModel(fromdate, todate, model, color);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<ImeiModelUpload> GetDetailsImeiData(DateTime fromdate, DateTime todate, string model, string color)
        {
            var list = new List<ImeiModelUpload>();

            try
            {
                list = reportManager.GetDetailsImeiData(fromdate, todate, model, color);

            }
            catch (Exception ex)
            {

            }

            return list;
        }




        public List<TpLcdReport> GetTpLcdReport(int project ,DateTime fromdate, DateTime todate)
        {
            var List = new List<TpLcdReport>();

            try
            {
                List = reportManager.GetTpLcdReport(project,fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }


        public List<TpLcdReport> GetTpLcdIssuesReport(int project, DateTime fromdate, DateTime todate)
        {
            var List = new List<TpLcdReport>();

            try
            {
                List = reportManager.GetTpLcdIssuesReport(project, fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<TpLcdReport> GetTpLcdAllReport(string project, object dateFrom, object todate)
        {
            var List = new List<TpLcdReport>();

            try
            {
                List = reportManager.GetTpLcdAllReport(project, dateFrom, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<GlueStationReport> GetTGlueStationReport(int project, DateTime fromdate, DateTime todate)
        {
            var List = new List<GlueStationReport>();

            try
            {
                List = reportManager.GetTGlueStationReport(project, fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<GlueStationReport> GetGlueIssuesReport(int project, DateTime fromdate, DateTime todate)
        {
            var List = new List<GlueStationReport>();

            try
            {
                List = reportManager.GetGlueIssuesReport(project, fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<GlueStationReport> GetGlueAllReport(string project, string dateFrom, string dateTo)
        {
            var List = new List<GlueStationReport>();

            try
            {
                List = reportManager.GetGlueAllReport(project, dateFrom, dateTo);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<PackingBoxModel> GetBoxPackingData(string fromdate, string todate, string project)
       {

           var List = new List<PackingBoxModel>();

           try
           {
               List = reportManager.GetBoxPackingData( fromdate, todate,project);

           }
           catch (Exception ex)
           {

           }

           return List;

      }





        public List<PackingBoxModel> GetVsunWoDetails(string woid, string project, string fromdate, string todate)
        {
            var List = new List<PackingBoxModel>();

            try
            {
                List = reportManager.GetVsunWoDetails(woid, project, fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<ReworkList> GetFaultListByDate(DateTime fromdate, DateTime todate)
        {
            var List = new List<ReworkList>();

            try
            {
                List = reportManager.GetFaultListByDate( fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<AssemblyLineInfo> GetAssemblyLineReport(string date, long line)
        {
            var list = new List<AssemblyLineInfo>();

            try
            {
                list = reportManager.GetAssemblyLineReport(date,line);

            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public List<TpLcdReport> GetTpLcdOverAllReport(int project, string fromdate, string todate)
        {
            var List = new List<TpLcdReport>();

            try
            {
                List = reportManager.GetTpLcdOverAllReport(project, fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<ProductionQcFaultScenerioModel> GetProductionQcStatus(string fromdate, int projectId)
        {
            var List = new List<ProductionQcFaultScenerioModel>();

            try
            {
                List = reportManager.GetProductionQcStatus(fromdate, projectId);

            }
            catch (Exception ex)
            {

            }

            return List;
        }



        public DataTable GetAssemblyLineissuesByDate(string date, int projectId)
        {
            var dt = new DataTable();

            try
            {
                dt = reportManager.GetAssemblyLineissuesByDate(date,projectId);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        public List<RepairStationInfoModel> GetFullRepairStationReport(int project, DateTime fromdate, DateTime todate)
        {
            var List = new List<RepairStationInfoModel>();

            try
            {
                List = reportManager.GetFullRepairStationReport(project, fromdate, todate);

            }
            catch (Exception ex)
            {

            }
            return List;
        }

        public List<AssemblyLineproductionStatusModel> GetAssemblylineProductionStatusReport(int project, string fromdate, string todate)
        {
            var List = new List<AssemblyLineproductionStatusModel>();

            try
            {
                List = reportManager.GetAssemblylineProductionStatusReport(project, fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }



        public DataTable GetFuAssemblyLineissuesByDate(string date, int projectId)
        {
            var dt = new DataTable();

            try
            {
                dt = reportManager.GetFuAssemblyLineissuesByDate(date,projectId);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        public List<ReworkList> GetFaultListByProject(long project)
        {
            var List = new List<ReworkList>();

            try
            {
                List = reportManager.GetFaultListByProject(project);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<AssemblyLineproductionStatusModel> GetPackagingProductionStatusReport(int project, string fromdate, string todate)
        {
            var List = new List<AssemblyLineproductionStatusModel>();

            try
            {
                List = reportManager.GetPackagingProductionStatusReport(project, fromdate, todate);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public DataTable GetRepairAndSolderingReport(string fromdate, string todate, int projectId)
        {
            var dt = new DataTable();

            try
            {
                dt = reportManager.GetRepairAndSolderingReport(fromdate, todate, projectId);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        public List<AgingQcStationModel> GetAgingReport(DateTime fromdate, DateTime todate, long? project)
        {
            var List = new List<AgingQcStationModel>();

            try
            {
                List = reportManager.GetAgingReport(fromdate, todate, project).ToList();

            }
            catch (Exception ex)
            {

            }

            return List;
        }

         [WebMethod]

        public List<AgingChargingModel> GetChargerAgingReport(DateTime fromdate, DateTime todate, long? project)
        {
            var List = new List<AgingChargingModel>();

            try
            {
                List = reportManager.GetChargerAgingReport(fromdate, todate, project).ToList();

            }
            catch (Exception ex)
            {

            }

            return List;
        }
            [WebMethod]
         public List<PackagingOQCModel> GetOQCDetailsReport(DateTime fromdate, DateTime todate, long? project)
         {
             var List = new List<PackagingOQCModel>();

             try
             {
                 List = reportManager.GetOQCDetailsReport(fromdate, todate, project).ToList();

             }
             catch (Exception ex)
             {

             }

             return List;
         }

            public Result CheckAndUploadImeiToOracle(DateTime fromdate, DateTime todate, string model, string color, int quantity, List<ImeiModelUpload> list, string oracletranscationCode)
            {
                try
                {
                    return reportManager.CheckAndUploadImeiToOracle(fromdate, todate, model, color, quantity, list, oracletranscationCode);
                }
                catch (Exception ex)
                {

                    return new Result { IsSuccess = false, Message = ex.Message };
                }
            }

            public List<ImeiModelUpload> GetLogisticsDataToUploadOracle(DateTime fromdate, DateTime todate, string model, string color)
            {
                var List = new List<ImeiModelUpload>();

                try
                {
                    List = reportManager.GetLogisticsDataToUploadOracle(fromdate, todate, model, color);

                }
                catch (Exception ex)
                {

                }

                return List;
            }
    }
}
