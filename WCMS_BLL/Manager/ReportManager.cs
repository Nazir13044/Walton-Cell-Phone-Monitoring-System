using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BR_BLL;
using WCMS_COMMON;
using WCMS_DAL.Inserting;
using WCMS_DAL.Interfaces;
using WCMS_DAL.Selecting;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;

namespace WCMS_BLL.Manager
{
    public class ReportManager
    {
        readonly IReporting iProductionReport = new WCMS_DAL_Reporting();
        public List<DailyProductionModel> GetProductCount(int projectId, string date)
        {
          
            try
            {
                return iProductionReport.GetProductCount(projectId,date);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<HourlyTargetModel> GetHourlyTaregtEfficiencyReport(int projectId,int lineId, string date )
        {
            try
            {
                return iProductionReport.GetHourlyTaregtEfficiencyReport(projectId,lineId, date );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OQcReportModel> GetOQcReport(int projectId, string date)
        {
            try
            {
                return iProductionReport.GetOQcReport(projectId, date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HourlyTargetModel> HourlyStationineWiseFault(int projectId, string date)
        {
            try
            {
                return iProductionReport.HourlyStationineWiseFault(projectId, date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HourlyTargetModel> HourlyStationineWisestatus(string date)
        {
            try
            {
                return iProductionReport.HourlyStationineWisestatus(date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HourlyTargetModel> DisplayProductionCount(string date)
        {
            try
            {
                return iProductionReport.DisplayProductionCount(date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HourlyTargetModel> DisplayPackagingCount(string date)
        {
            try
            {
                return iProductionReport.DisplayPackagingCount(date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HourlyTargetModel> GetLogisticsReport(string date, string project)
        {
            try
            {
                return iProductionReport.GetLogisticsReport(date, project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HourlyTargetModel> GetLogisticsReportByDate(DateTime fromdate, DateTime todate)
        {
            try
            {
                return iProductionReport.GetLogisticsReportByDate(fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tblLogistics> GetLogisticsReportWithDateModel(DateTime fromdate, DateTime todate, string model,string color)
        {
            try
            {
                return iProductionReport.GetLogisticsReportWithDateModel(fromdate, todate, model, color);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ImeiModelUpload> GetDetailsImeiData(DateTime fromdate, DateTime todate, string model, string color)
        {
            try
            {
                return iProductionReport.GetDetailsImeiData(fromdate, todate, model, color);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TpLcdReport> GetTpLcdReport(int project,DateTime fromdate, DateTime todate)
        {
            try
            {
                return iProductionReport.GetTpLcdReport(project,fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TpLcdReport> GetTpLcdIssuesReport(int project, DateTime fromdate, DateTime todate)
        {
            try
            {
                return iProductionReport.GetTpLcdIssuesReport(project, fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TpLcdReport> GetTpLcdAllReport(string project, object dateFrom, object todate)
        {
            try
            {
                return iProductionReport.GetTpLcdAllReport(project, dateFrom, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GlueStationReport> GetTGlueStationReport(int project, DateTime fromdate, DateTime todate)
        {
            try
            {
                return iProductionReport.GetTGlueStationReport(project, fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GlueStationReport> GetGlueIssuesReport(int project, DateTime fromdate, DateTime todate)
        {
            try
            {
                return iProductionReport.GetGlueIssuesReport(project, fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GlueStationReport> GetGlueAllReport(string project, string dateFrom, string todate)
        {
            try
            {
                return iProductionReport.GetGlueAllReport(project, dateFrom, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PackingBoxModel> GetBoxPackingData(string fromdate, string todate, string project)
        {
            try
            {
                return iProductionReport.GetBoxPackingData( fromdate, todate,project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PackingBoxModel> GetVsunWoDetails(string woid, string project, string fromdate, string todate)
        {
            try
            {
                return iProductionReport.GetVsunWoDetails(woid, project, fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReworkList> GetFaultListByDate(DateTime fromdate, DateTime todate)
        {
            try
            {
                return iProductionReport.GetFaultListByDate(fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AssemblyLineInfo> GetAssemblyLineReport(string date, long line)
        {
            try
            {
                return iProductionReport.GetAssemblyLineReport(date,line);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TpLcdReport> GetTpLcdOverAllReport(int project, string fromdate, string todate)
        {
            try
            {
                return iProductionReport.GetTpLcdOverAllReport(project, fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductionQcFaultScenerioModel> GetProductionQcStatus(string fromdate, int projectId)
        {
            try
            {
                return iProductionReport.GetProductionQcStatus(fromdate, projectId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAssemblyLineissuesByDate(string date, int projectId)
        {
            try
            {
                return iProductionReport.GetAssemblyLineissuesByDate( date,projectId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RepairStationInfoModel> GetFullRepairStationReport(int project, DateTime fromdate, DateTime todate)
        {
            try
            {
                return iProductionReport.GetFullRepairStationReport(project, fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HourlyTargetModel> GetLogisticsReportForUpload(DateTime fromdate, DateTime todate)
        {
            try
            {
                return iProductionReport.GetLogisticsReportForUpload(fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AssemblyLineproductionStatusModel> GetAssemblylineProductionStatusReport(int project, string fromdate, string todate)
        {
            try
            {
                return iProductionReport.GetAssemblylineProductionStatusReport(project, fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFuAssemblyLineissuesByDate(string date, int projectId)
        {
            try
            {
                return iProductionReport.GetFuAssemblyLineissuesByDate(date,projectId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReworkList> GetFaultListByProject(long project)
        {
            try
            {
                return iProductionReport.GetFaultListByProject(project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AssemblyLineproductionStatusModel> GetPackagingProductionStatusReport(int project, string fromdate, string todate)
        {
            try
            {
                return iProductionReport.GetPackagingProductionStatusReport(project, fromdate, todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetRepairAndSolderingReport(string fromdate, string todate, int projectId)
        {
            try
            {
                return iProductionReport.GetRepairAndSolderingReport(fromdate,todate, projectId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AgingQcStationModel> GetAgingReport(DateTime fromdate, DateTime todate, long? project)
        {
            try
            {
                return iProductionReport.GetAgingReport(fromdate, todate, project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<AgingChargingModel> GetChargerAgingReport(DateTime fromdate, DateTime todate, long? project)
        {
            try
            {
                return iProductionReport.GetChargerAgingReport(fromdate, todate, project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PackagingOQCModel> GetOQCDetailsReport(DateTime fromdate, DateTime todate, long? project)
        {
            try
            {
                return iProductionReport.GetOQCDetailsReport(fromdate, todate, project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result CheckAndUploadImeiToOracle(DateTime fromdate, DateTime todate, string model, string color, int quantity, List<ImeiModelUpload> list,string oracletranscationCode)
        {
            try
            {
                //IReporting report = new WCMS_DAL_Reporting();
                var result = new Result();
                //using (
                //    var transaction = new TransactionScope(TransactionScopeOption.Required,
                //        ApplicationState.TransactionOptions))
                    try
                    {

                        result.IsSuccess = iProductionReport.CheckAndUploadImeiToOracle(fromdate, todate, model, color, quantity, list, oracletranscationCode);

                        //if (result.IsSuccess)
                         //  / transaction.Complete();
                        //else
                        //{
                        //    transaction.Dispose();
                        //}
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ImeiModelUpload> GetLogisticsDataToUploadOracle(DateTime fromdate, DateTime todate, string model, string color)
        {
            try
            {
                return iProductionReport.GetLogisticsDataToUploadOracle(fromdate, todate, model, color);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
