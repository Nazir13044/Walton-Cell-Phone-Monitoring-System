using System;
using System.Collections.Generic;
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

    public class ProductionManager
    {
        IProduction _iProductionInsert = new WCMS_DAL_Production();
        readonly ISelectingCommon _isSelectingCommon = new DALGetCommonSelecting();
        readonly IInsertingSetupCommon _insertingSetupCommon = new WCMS_Common_Inserting();
        public Result InsertFunctionalQcStatus(ProductionMaster productionMaster)
        {
            try
            {

                IProduction _IProductionInsert = new WCMS_DAL_Production();
                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IProductionInsert.InsertFunctionalQcStatus(productionMaster);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public List<tblRework> GetQcStatusHistory(tblRework _Entity)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            try
            {
                return iProductionSelect.GetQcStatusHistory(_Entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result UpdateQcStatusHistory(List<ProductionMaster> productionList)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();



            var result = new Result();
            try
            {

                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {

                    result.IsSuccess = iProductionSelect.UpdateQcStatusHistory(productionList);
                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Result InsertFunctionalRework(tblRework rework)
        {
            try
            {

                IProduction iProductionInsert = new WCMS_DAL_Production();
                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result {IsSuccess = iProductionInsert.InsertFunctionalRework(rework)};

                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tblRework> GetIssueResult(tblRework rework)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            try
            {
                return iProductionSelect.GetIssueResult(rework);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result UpdateRework(List<tblRework> rework)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            Result _Result = new Result();
            try
            {
                _Result.IsSuccess = iProductionSelect.UpdateRework(rework);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _Result;
        }

        public Result UpdateReworkTask(tblRework reworks)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();

            Result _Result = new Result();
            try
            {

                if (reworks.Status == "S")
                {
                    reworks.StartDate = DateTime.Now;
                }


                _Result.IsSuccess = iProductionSelect.UpdateReworkTask(reworks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _Result;
        }

        public Result InsertBomList(BomList bomList)
        {
            try
            {

                IProduction _IProductionInsert = new WCMS_DAL_Production();
                using (
                    TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IProductionInsert.InsertBomList(bomList);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Result InsertSolderingInfo(tblSolderingOthers oSolderList)
        {
            try
            {

                IProduction iProductionInsert = new WCMS_DAL_Production();
                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result {IsSuccess = iProductionInsert.InsertSolderingInfo(oSolderList)};

                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result InsertDeletedOQcBatchInfo(tblDeletdPackagingBatchData oQcBatchInfo)
        {
            try
            {

                IProduction _IProductionInsert = new WCMS_DAL_Production();
                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IProductionInsert.InsertDeletedOQcBatchInfo(oQcBatchInfo);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tblRework> IssueHistoryByImei(string imei)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            try
            {
                return iProductionSelect.IssueHistoryByImei(imei);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tblRework> GetReworkDetailsByImei(string imei)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            try
            {
                return iProductionSelect.GetReworkDetailsByImei(imei);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result InsertAgingcBatchInfo(AgingBatchInfo agingBatchInfo)
        {

            try
            {

                IProduction _IProductionInsert = new WCMS_DAL_Production();
                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IProductionInsert.InsertAgingcBatchInfo(agingBatchInfo);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result UpdateProductionBatchStatus(List<ProductionMaster> producList)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            Result _Result = new Result();
            try
            {
                _Result.IsSuccess = iProductionSelect.UpdateProductionBatchStatus(producList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _Result;
        }

        public Result InsertAgingBatchQcInfo(List<ProductionMaster> productionAgingQc, string batchStatus, long userId, long lineId, long projectId)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            IProduction iProductionInsert = new WCMS_DAL_Production();
            var result = new Result();

            var batchnumber="";
            try
            {
                //logic 

                var productionList = new List<ProductionMaster>();
                foreach (var items in productionAgingQc)
                {
                    var production = new ProductionMaster();
                  

                    var isExists = _isSelectingCommon.ProductionMasterInfo(new ProductionMaster { MobileCode = items.MobileCode }).Any();

                    //check if previously passed
                    var previousStatus = _isSelectingCommon.ProductionMasterInfo(new ProductionMaster { MobileCode = items.MobileCode }).FirstOrDefault();

                    //var previousStation = entities.ProductionMaster.FirstOrDefault(a => a.MobileCode == items.MobileCode);
                    //if (previousStatus != null && (isExists && previousStatus.Passed.ToUpper() == "N"))


                        if (previousStatus != null && (isExists && previousStatus.Passed.ToUpper() == "N") && previousStatus.QcStation != "AGQC")
                    {
                        result.Message = " Item Not Passed From Aesthetic QC Station. Item No:" + items.MobileCode + "";
                        return result;

                    }
                    //if (previousStatus != null && (isExists && previousStatus.QcStation.Trim() != "ASTQC"))

                        if (previousStatus != null && (isExists) && (previousStatus.QcStation.Trim() != "ASTQC" && previousStatus.QcStation.Trim() != "AGQC") && items.QcStation.Trim() == "AGQC")


                    {
                        result.Message = "Item Not Checked In Aesthetic QC Station. Item No:" + items.MobileCode + "";
                        return result;

                    }
                    if (previousStatus == null || !isExists)
                    {
                        result.Message = "Item Not Checked In Aesthetic QC Station. Item No:" + items.MobileCode + "";
                         return result;

                    }
                   
                        if (items.QcStation == "AGQC")

                    {
                        production.MobileCode = items.MobileCode;
                        production.QcStation = items.QcStation;
                        production.Passed = items.Passed.ToUpper();

                        if (items.Passed.ToUpper() == "Y")
                        {
                            production.AgingBatchNumber = items.AgingBatchNumber;
                        }
                        production.AgingBy = userId;
                        production.AgingAD = DateTime.Now;
                        production.Remarks = items.Remarks;
                        batchnumber = items.AgingBatchNumber;
                        productionList.Add(production);

                    }


                    if (productionList.Count == productionAgingQc.Count)
                    {
                        result.IsSuccess = iProductionSelect.InsertAgingBatchQcInfo(productionList);


                        if (result.IsSuccess)

                        {
                            //insert into rework


                            foreach (var failItems in productionList)
                            {
                                if (failItems.Passed.ToUpper() == "N")
                                {
                                    production.AgingBatchNumber = "";
                                    var reresult = new Result();
                                    var rework = new tblRework();
                                    rework.ProjectId = projectId;
                                    rework.MobileCode = failItems.MobileCode;
                                    rework.Issues = failItems.Remarks;
                                    rework.FailedStation = failItems.QcStation;
                                    rework.Status = "P";
                                    rework.AddedBy = userId;
                                    rework.AddedDate = DateTime.Now;

                                    reresult.IsSuccess = iProductionInsert.InsertFunctionalRework(rework);

                                }
                            }
                         

                            var batchResults = new Result();
                            if (result.IsSuccess)
                            {
                                var batchInfo = new AgingBatchInfo();
                                batchInfo.BatchNo = batchnumber;

                                if (batchStatus.ToUpper() == "N")
                                    batchInfo.Status = "F";

                                if (batchStatus.ToUpper() == "Y")
                                    batchInfo.Status = "P";

                                batchResults.IsSuccess = iProductionInsert.UpdateBatchInfo(batchInfo);
                            }

                        }

                    }

                }
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Result UpdateOQCBatchInfo(List<tblPackagingBatch> batchInfoList)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            try
            {
                result.IsSuccess = iProductionSelect.UpdateOQCBatchInfo(batchInfoList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Result GenerateImeiBatch(long userId, long projectId, string imeiCode)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            try
            {
                var productionMasterInfo = _isSelectingCommon.ProductionMasterInfoByImei(imeiCode).FirstOrDefault();
                if (productionMasterInfo != null&& productionMasterInfo.Passed=="Y")
                {


                    var isExists =
                        iProductionSelect.GetPackagingBatchInfo(new tblPackagingBatch()
                        {
                            MobileCode = productionMasterInfo.MobileCode
                        }).Any();


                    if (!isExists)
                    {

                        var packaginBatch = new tblPackagingBatch();

                        packaginBatch.ProjectId = productionMasterInfo.ProjectId;
                        packaginBatch.LineId = productionMasterInfo.LineId;
                        packaginBatch.MobileCode = productionMasterInfo.MobileCode;
                        packaginBatch.Imei1 = productionMasterInfo.Imei1;
                        packaginBatch.Imei2 = productionMasterInfo.Imei2;
                        packaginBatch.AddedBy = userId;
                        packaginBatch.AddedDate = DateTime.Now;
                        result.IsSuccess = iProductionSelect.GenerateImeiBatch(packaginBatch);
                        if (result.IsSuccess)
                        {
                            var packagingBatchList = iProductionSelect.CountPackagingBatch(projectId, userId).ToList();

                            if (packagingBatchList.Count ==100)
                            {
                                var pckResult = new Result();
                                var packageBatchList = new List<tblPackagingBatch>();
                                var productionList = new List<ProductionMaster>();
                                var packagingBatchNumber = PackagingRandomString();

                                foreach (var items in packagingBatchList)
                                {
                                    var packagingBatch = new tblPackagingBatch();
                                    var productionMaster = new ProductionMaster();

                                    packagingBatch.MobileCode = items.MobileCode;
                                    packagingBatch.Imei1 = items.Imei1;
                                    packagingBatch.Imei2 = items.Imei2;
                                    packagingBatch.SystemBatch = "PKG-" + packagingBatchNumber.Trim();

                                    packagingBatch.BatchCreatedBy = userId;
                                    packagingBatch.BatchCreatedDate = DateTime.Now;

                                    packageBatchList.Add(packagingBatch);   //packBatchList

                                    //adding productonMaster
                                    productionMaster.MobileCode = items.MobileCode;
                                    productionMaster.Imei1 = items.Imei1;
                                    productionMaster.Imei2 = items.Imei2;
                                    productionMaster.OQCBatchNumber = "PKG-" + packagingBatchNumber.Trim();
                                    productionList.Add(productionMaster);
                                    
                                }


                                pckResult.IsSuccess = iProductionSelect.UpdatePackagingBatchStatus(packageBatchList);


                                if (pckResult.IsSuccess)

                                {
                                    var rslt = new Result
                                    {
                                        IsSuccess = _iProductionInsert.UpdateQcStatusHistory(productionList)
                                    };
                                }


                            }



                        }
                    }
                    else
                    {

                        result.Message = "Already Exists ! duplicate IMEI ";
                        return result;
                        
                    }






                }


                else
                {
                    result.Message = "No data found with this IMEI / Not Passed ";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private static readonly Random Random = new Random();
        public static string PackagingRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }


        


        public List<tblPackagingBatch> CountPackagingBatch(long projectId, long userId)
        {

            IProduction iProductionSelect = new WCMS_DAL_Production();
            try
            {
                return iProductionSelect.CountPackagingBatchAll(projectId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public Result DeleteOQCBatchInfoData(List<tblPackagingBatch> oQcBatchInfoList)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            try
            {
                result.IsSuccess = iProductionSelect.DeleteOQCBatchInfoData(oQcBatchInfoList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public Result InsertOqcBatch(List<tblPackagingBatch> oQcBatchInfo)
        {


            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            try
            {
                result.IsSuccess = iProductionSelect.InsertOqcBatch(oQcBatchInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;


        }

        public Result InsertLogisticsData(tblLogistics logisticsList)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
            try
            {
                
                result.IsSuccess = iProductionSelect.tblLogistics(logisticsList);

                if (result.IsSuccess)
                    transaction.Complete();
                else
                {
                    transaction.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Result UpdateLogisticsData(List<ImeiModelUpload> imeiModelUpload)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            //using (
            //    var transaction = new TransactionScope(TransactionScopeOption.Required,
            //        ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iProductionSelect.UpdateLogisticsData(imeiModelUpload);

                    //if (result.IsSuccess)
                       // transaction.Complete();
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }

        public Result InsertRepairStatus(List<tblRepairStatus> repairStatus)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iProductionSelect.InsertRepairStatus(repairStatus);

                    if (result.IsSuccess)
                        transaction.Complete();
                    else
                    {
                        transaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }

        public Result InsertRepairComponents(List<tblRepairComponents> repairComponents)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iProductionSelect.InsertRepairComponents(repairComponents);

                    if (result.IsSuccess)
                        transaction.Complete();
                    else
                    {
                        transaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }

        public Result InsertAgingQcStationinfo(List<tblAgingMaster> agingBatchList)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iProductionSelect.InsertAgingQcStationinfo(agingBatchList);

                    if (result.IsSuccess)
                        transaction.Complete();
                    else
                    {
                        transaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }

        public Result UpdateAgingQcStationinfo(List<tblAgingMaster> agingCheckedList)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iProductionSelect.UpdateAgingQcStationinfo(agingCheckedList);

                    if (result.IsSuccess)
                        transaction.Complete();
                    else
                    {
                        transaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }

        public Result UpdateBatchInfo(AgingBatchInfo batchInfo)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iProductionSelect.UpdateBatchInfo(batchInfo);

                    if (result.IsSuccess)
                        transaction.Complete();
                    else
                    {
                        transaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }

        public Result InsertOqcCheckedItems(tblOqcCheckedItems checkedItems)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            try
            {
                result.IsSuccess = iProductionSelect.InsertOqcCheckedItems(checkedItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result; 
        }

        public Result InsertAgingBatchStatus(AgingBatch batchesult)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            try
            {
                result.IsSuccess = iProductionSelect.InsertAgingBatchStatus(batchesult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result; 
        }

        public Result InsertChargingQcStationinfo(List<tblChargerMaster> chargingCheckedList)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iProductionSelect.InsertChargingQcStationinfo(chargingCheckedList);

                    if (result.IsSuccess)
                        transaction.Complete();
                    else
                    {
                        transaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }

        public Result UpdateLogisticsDataForOracleUpload(List<ImeiModelUpload> list, string oracletranscationCode)
        {
            IProduction iProductionSelect = new WCMS_DAL_Production();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iProductionSelect.UpdateLogisticsDataForOracleUpload(list, oracletranscationCode);

                    if (result.IsSuccess)
                        transaction.Complete();
                    else
                    {
                        transaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }
    }
}
