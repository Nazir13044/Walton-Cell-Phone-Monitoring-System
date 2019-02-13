using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;

namespace WCMS_DAL.Interfaces
{
    public interface IReporting
    {

        List<DailyProductionModel> GetProductCount(int projectId, string date);

        List<HourlyTargetModel> GetHourlyTaregtEfficiencyReport(int projectId,int lineId, string date );

        List<WCMS_ENTITY.CustomModelEntity.OQcReportModel> GetOQcReport(int projectId, string date);

        List<HourlyTargetModel> HourlyStationineWiseFault(int projectId, string date);

        List<HourlyTargetModel> HourlyStationineWisestatus(string date);

        List<HourlyTargetModel> DisplayProductionCount(string date);

        List<HourlyTargetModel> DisplayPackagingCount(string date);

        List<HourlyTargetModel> GetLogisticsReport(string date, string project);

        List<HourlyTargetModel> GetLogisticsReportByDate(DateTime fromdate, DateTime todate);

        List<tblLogistics> GetLogisticsReportWithDateModel(DateTime fromdate, DateTime todate, string model,string color);

        List<ImeiModelUpload> GetDetailsImeiData(DateTime fromdate, DateTime todate, string model, string color);

        List<TpLcdReport> GetTpLcdReport(int project,DateTime fromdate, DateTime todate);

        List<TpLcdReport> GetTpLcdIssuesReport(int project, DateTime fromdate, DateTime todate);

        List<TpLcdReport> GetTpLcdAllReport(string project, object dateFrom, object todate);

        List<GlueStationReport> GetTGlueStationReport(int project, DateTime fromdate, DateTime todate);

        List<GlueStationReport> GetGlueIssuesReport(int project, DateTime fromdate, DateTime todate);

        List<GlueStationReport> GetGlueAllReport(string project, string dateFrom, object todate);

        List<PackingBoxModel> GetBoxPackingData(string fromdate, string todate, string project);

        List<PackingBoxModel> GetVsunWoDetails(string woid, string project, string fromdate, string todate);

        List<ReworkList> GetFaultListByDate(DateTime fromdate, DateTime todate);

        List<AssemblyLineInfo> GetAssemblyLineReport(string date, long line);

        List<TpLcdReport> GetTpLcdOverAllReport(int project, string fromdate, string todate);

        List<ProductionQcFaultScenerioModel> GetProductionQcStatus(string fromdate, int projectId);

        DataTable GetAssemblyLineissuesByDate(string date, int projectId);

        List<RepairStationInfoModel> GetFullRepairStationReport(int project, DateTime fromdate, DateTime todate);

        List<HourlyTargetModel> GetLogisticsReportForUpload(DateTime fromdate, DateTime todate);

        List<AssemblyLineproductionStatusModel> GetAssemblylineProductionStatusReport(int project, string fromdate, string todate);

        DataTable GetFuAssemblyLineissuesByDate(string date, int projectId);

        List<ReworkList> GetFaultListByProject(long project);

        List<AssemblyLineproductionStatusModel> GetPackagingProductionStatusReport(int project, string fromdate, string todate);

        DataTable GetRepairAndSolderingReport(string fromdate, string todate, int projectId);

        List<AgingQcStationModel> GetAgingReport(DateTime fromdate, DateTime todate, long? project);



        List<AgingChargingModel> GetChargerAgingReport(DateTime fromdate, DateTime todate, long? project);

        List<PackagingOQCModel> GetOQCDetailsReport(DateTime fromdate, DateTime todate, long? project);



        bool CheckAndUploadImeiToOracle(DateTime fromdate, DateTime todate, string model, string color, int quantity, List<ImeiModelUpload> list, string oracletranscationCode);

        List<ImeiModelUpload> GetLogisticsDataToUploadOracle(DateTime fromdate, DateTime todate, string model, string color);
    }
}
