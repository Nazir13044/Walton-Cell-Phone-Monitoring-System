using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;

namespace WCMS_DAL.Interfaces
{
    public interface IProduction
    {

        bool InsertFunctionalQcStatus(ProductionMaster productionMaster);

        List<tblRework> GetQcStatusHistory(tblRework _Entity);

        bool UpdateQcStatusHistory(List<ProductionMaster> productionList);

        bool InsertFunctionalRework(tblRework rework);

        List<tblRework> GetIssueResult(tblRework rework);

        bool UpdateRework(List<tblRework> rework);

        bool UpdateReworkTask(tblRework reworks);

        bool InsertBomList(BomList bomList);



        bool InsertSolderingInfo(tblSolderingOthers oSolderList);

        bool InsertDeletedOQcBatchInfo(tblDeletdPackagingBatchData oQcBatchInfo);

        List<tblRework> IssueHistoryByImei(string imei);

        List<tblRework> GetReworkDetailsByImei(string imei);

        bool InsertAgingcBatchInfo(AgingBatchInfo agingBatchInfo);

        bool UpdateProductionBatchStatus(List<ProductionMaster> producList);

        bool InsertAgingBatchQcInfo(List<ProductionMaster> productionList);



        bool UpdateBatchInfo(AgingBatchInfo batchInfo);

        bool UpdateOQCBatchInfo(List<tblPackagingBatch> batchInfoList);

        bool GenerateImeiBatch(tblPackagingBatch packaginBatch);

        List<tblPackagingBatch> CountPackagingBatch(long projectId, long userid);
        List<tblPackagingBatch> CountPackagingBatchAll(long projectId, long userid);

        bool UpdatePackagingBatchStatus(List<tblPackagingBatch> packageBatchList);

        List<tblPackagingBatch> GetPackagingBatchInfo(tblPackagingBatch tblPackagingBatch);

      

        bool DeleteOQCBatchInfoData(List<tblPackagingBatch> oQcBatchInfoList);

        bool InsertOqcBatch(List<tblPackagingBatch> oQcBatchInfo);

        bool tblLogistics(tblLogistics logisticsList);

        bool UpdateLogisticsData(List<ImeiModelUpload> imeiModelUpload);

        bool InsertRepairStatus(List<tblRepairStatus> repairStatus);

        bool InsertRepairComponents(List<tblRepairComponents> repairComponents);

        bool InsertAgingQcStationinfo(List<tblAgingMaster> agingBatchList);

        bool UpdateAgingQcStationinfo(List<tblAgingMaster> agingCheckedList);

        bool InsertOqcCheckedItems(tblOqcCheckedItems checkedItems);

        bool InsertAgingBatchStatus(AgingBatch batchesult);

        bool InsertChargingQcStationinfo(List<tblChargerMaster> chargingCheckedList);

        bool UpdateLogisticsDataForOracleUpload(List<ImeiModelUpload> list, string oracletranscationCode);
    }
}
