using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;

namespace WCMS_DAL.Interfaces
{
   public interface ISelectingCommon
    {
       List<BomList> GetComponentList();


       List<ProjectMaster> GetProjectNameList();

       List<Employee> GetEmployeeList(string term);



       List<EmployeeInfo> GetEmployeeByID(EmployeeInfo _Entity);

       List<tblLogin> GetLoginUser(tblLogin entity);

       List<ProjectBomList> GetComponentsByProjectId(ProjectBomList projectBomList);

       List<tblRework> GetAllIssuesList();

       List<tblAssemblyLineSetup> GetAssemblineInfo(tblAssemblyLineSetup tblAssemblyLineSetup);

       List<ProductionMaster> ProductionMasterInfo(ProductionMaster productionMaster);

       List<ProductionMaster> ProductionMasterInfoByImei(string code);

       List<AssemblyLineInfo> GetLineWiseProjectInfo();

       List<ProductionMaster> GetDetailsByImei(string imei);

       List<Issues> GetAllIssueList();

       List<tblLogin> GetRegEmployee(string term);

       List<tblComponentRequisition> GetComponentReqList(string userId);

       List<BomList> GetMaterialInfo(BomList bomList);

       List<ProjectBomList> GetProjectWiseBomList(ProjectBomList projectBomList);



       List<tblDailyIssuedComponents> CountIssuedComponents();

       List<tblLogin> GetRegisterdeEmployee();

       List<ReworkList> GetFaultyMobileList();

       List<tblScrew> GetScrewDoneCount();

       List<ProductionMaster> GetFunctionalQcCount();

       List<ProductionMaster> GetAestheticQcCount();

       List<ProductionMaster> GetPackagingCount();

       List<ProductionMaster> GetPackagingAestheticCount();

       List<ProductionMaster> GetPackagingOqcCount();

       List<tblDailyIssuedComponents> GetPCBInfo(tblDailyIssuedComponents tblDailyIssuedComponents);

       List<tblScrew> GetScrewStationInfo(tblScrew tblScrew);

       List<tblPackagingBatch> GetOQCBatchInfo(tblPackagingBatch oQcBatchInfo);

       List<tblPackagingBatch> GetOQCBatchInfoByImei(string mobileCode);

       List<ProjectMaster> GetProjectNameListByParam(ProjectMaster projectMaster);

       List<AgingBatchInfo> GetAgingBatchData(AgingBatchInfo agingBatchInfo);

       List<tblIMEIRecord> GetImeiRecords(string imei);

       List<F_Projects> GetProjecFormvsunDb();

       List<WCMS_MAIN.Models.MasterBoxModel> GetMasterBoxData(string boxCode, string project);

       List<tblLogistics> GetLogisticData();

       List<tblLogistics> GetLogisticsList(tblLogistics logistics);

       List<tblLogisticsSentItems> GetLogisticsReleaselist(tblLogisticsSentItems tblLogisticsSentItems);

       List<tblWarehouse> GetWarehouseReceivedlist(tblWarehouse tblWarehouse);

       List<ReworkList> GetFaultyMobileHistory(string mobileCode);

       List<tblColors> tblColors();

       List<tblRework> GetCompletedRepairCount();

       Issues GetIssueCriteria(Issues issues);

       List<tblAgingMaster> AgingMasterInfo(tblAgingMaster tblAgingMaster);

       List<tblChargerMaster> ChargingMasterInfo(tblChargerMaster tblChargerMaster);

       List<AgingBatch> AgingBatcInfo(AgingBatch agingBatch);
    }
}
