using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using WCMS_COMMON;
using WCMS_DAL.HelperClass;
using WCMS_DAL.Interfaces;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.HelperClass;
using WCMS_MAIN.Models;


namespace WCMS_DAL.Inserting
{
    public class WCMS_DAL_Production : IProduction
    {
        private readonly WCMSEntities _entity = new WCMSEntities();
        private readonly WCMSCellPhoneProjectEntities _wcmsCellPhoneProjectEntities = new WCMSCellPhoneProjectEntities();
        //public WCMS_DAL_Production()
        //{
        //    _entity = new WCMSEntities();

        //}


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertFunctionalQcStatus(ProductionMaster productionMaster)
        {
            try
            {
                _entity.ProductionMaster.Add(productionMaster);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertFunctionalRework(tblRework tblRework)
        {
            try
            {
                _entity.tblRework.Add(tblRework);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<tblRework> GetIssueResult(tblRework rework)
        {
            var list = new List<tblRework>();
            var fullList = new List<tblRework>();

            try
            {

                list = _entity.tblRework.WhereIf(rework.MobileCode != null, x => x.MobileCode == rework.MobileCode)
                    .WhereIf(rework.Imei1 != null, x => x.Imei1 == rework.Imei1)
                    .WhereIf(rework.Imei2 != null, x => x.Imei2 == rework.Imei2)
                    .WhereIf(rework.Status != null, x => x.Status == rework.Status)
                    .WhereIf(rework.ReworkId != 0, x => x.ReworkId == rework.ReworkId)
                    .WhereIf(rework.AddedBy != null, x => x.AddedBy == rework.AddedBy)
                    .WhereIf(rework.FailedStation != null, x => x.FailedStation == rework.FailedStation)
                    .WhereIf(rework.ProjectId != null, x => x.ProjectId == rework.ProjectId)
                    .ToList();


                var projectname = _wcmsCellPhoneProjectEntities.ProjectMasters.ToList();



                fullList = (from li in list
                            join proj in projectname on li.ProjectId equals proj.ProjectMasterId

                            select new tblRework
                            {
                                ProjectId = li.ProjectId,
                                ProjectName = proj.ProjectName + "-" + CommonConversion.AddOrdinal(proj.OrderNuber) + " Order",
                                LineId = li.LineId,
                                FailedStation = li.FailedStation,
                                Issues = li.Issues,
                                ReworkId = li.ReworkId,
                                MobileCode = li.MobileCode,
                                AddedDate = li.AddedDate

                            }).ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return fullList;
        }


        //get history from rework table
        public List<tblRework> GetQcStatusHistory(tblRework _Entity)
        {


            List<tblRework> list = new List<tblRework>();

            try
            {
                list = _entity.tblRework
                    .WhereIf(_Entity.MobileCode != "", x => x.MobileCode == _Entity.MobileCode)
                    .OrderByDescending(y => y.AddedDate)
                    .Take(1)
                    .ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return list;

        }

        //public bool UpdateDeliveryPlanInfo(List<ProductionMaster> productionList)
        //{

        //}



        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool UpdateQcStatusHistory(List<ProductionMaster> productionList)
        {

            foreach (var item in productionList)
            {
                _entity.Configuration.LazyLoadingEnabled = false;
                ProductionMaster productionMaster =
                    _entity.ProductionMaster.FirstOrDefault(x => x.MobileCode == item.MobileCode);


                if (productionMaster != null)
                {
                    if (item.Passed != null)
                        productionMaster.Passed = item.Passed;
                    if (item.QcStation != null)
                        productionMaster.QcStation = item.QcStation;
                    if (!string.IsNullOrEmpty(item.Imei1))
                        productionMaster.Imei1 = item.Imei1;
                    if (!string.IsNullOrEmpty(item.Imei2))
                        productionMaster.Imei2 = item.Imei2;
                    if (item.AddedBy != null)
                        productionMaster.AddedBy = item.AddedBy;
                    if (item.AddedDate != null)
                        productionMaster.AddedDate = item.AddedDate;
                    if (item.UpdatedBy != null)
                        productionMaster.UpdatedBy = item.UpdatedBy;
                    if (item.UpdatedDate != null)
                        productionMaster.UpdatedDate = item.UpdatedDate;
                    if (item.FinallyPassed != null)
                        productionMaster.FinallyPassed = item.FinallyPassed;
                    if (item.FinallyPassedBy != null)
                        productionMaster.FinallyPassedBy = item.FinallyPassedBy;
                    if (item.FinallyPassedTime != null)
                        productionMaster.FinallyPassedTime = item.FinallyPassedTime;

                    if (item.FunctionalBy != null)
                        productionMaster.FunctionalBy = item.FunctionalBy;
                    if (item.FunctionalAD != null)
                        productionMaster.FunctionalAD = item.FunctionalAD;
                    if (item.AestheticBy != null)
                        productionMaster.AestheticBy = item.AestheticBy;
                    if (item.AestheticAD != null)
                        productionMaster.AestheticAD = item.AestheticAD;

                    if (item.AgingBy != null)
                        productionMaster.AgingBy = item.AgingBy;
                    if (item.AgingAD != null)
                        productionMaster.AgingAD = item.AgingAD;

                    if (item.PackagingBy != null)
                        productionMaster.PackagingBy = item.PackagingBy;
                    if (item.PackagingAD != null)
                        productionMaster.PackagingAD = item.PackagingAD;

                    if (item.PackagingAstheticBy != null)
                        productionMaster.PackagingAstheticBy = item.PackagingAstheticBy;
                    if (item.PackagingAstheticAD != null)
                        productionMaster.PackagingAstheticAD = item.PackagingAstheticAD;
                    if (item.PackagingOQCBy != null)
                        productionMaster.PackagingOQCBy = item.PackagingOQCBy;
                    if (item.PackagingOQCAD != null)
                        productionMaster.PackagingOQCAD = item.PackagingOQCAD;
                    if (item.PackagingLineId != null)
                        productionMaster.PackagingLineId = item.PackagingLineId;

                    if (item.OQCBatchNumber != null)
                        productionMaster.OQCBatchNumber = item.OQCBatchNumber;

                    _entity.Entry(productionMaster).State = EntityState.Modified;
                    _entity.SaveChanges();
                }
                else
                {
                    return false;
                }


            }

            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool UpdateRework(List<tblRework> reworks)
        {

            foreach (var item in reworks)
            {
                _entity.Configuration.LazyLoadingEnabled = false;
                tblRework rework =
                    _entity.tblRework.Where(x => x.MobileCode == item.MobileCode)
                        .OrderByDescending(y => y.AddedDate)
                        .FirstOrDefault();


                if (rework != null)
                {
                    if (item.Status != "")
                        rework.Status = item.Status;
                    if (item.FailedStation != "")
                        rework.FailedStation = item.FailedStation;
                    if (item.AddedBy != 0)
                        rework.AddedBy = item.AddedBy;
                    if (item.AddedDate != null)
                        rework.AddedDate = item.AddedDate;

                    _entity.Entry(rework).State = EntityState.Modified;
                    _entity.SaveChanges();
                }
                else
                {
                    return false;
                }

                //DB.SalesDeliveryPlans.Add(item);
            }


            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool UpdateReworkTask(tblRework reworks)
        {

            _entity.Configuration.LazyLoadingEnabled = false;
            tblRework rework = _entity.tblRework.FirstOrDefault(x => x.ReworkId == reworks.ReworkId);


            if (rework != null)
            {
                if (reworks.Status != "")

                    rework.Status = reworks.Status;
                if (reworks.StartDate != null)
                    rework.StartDate = reworks.StartDate;
                if (reworks.StartedBy != null)
                    rework.StartedBy = reworks.StartedBy;
                if (reworks.FinishedDate != null)
                    rework.FinishedDate = reworks.FinishedDate;
                if (reworks.FinishedBy != null)
                    rework.FinishedBy = reworks.FinishedBy;
                if (reworks.UpdatedBy != null)
                    rework.UpdatedBy = reworks.UpdatedBy;
                if (reworks.UpdatedDate != null)
                    rework.UpdatedDate = reworks.UpdatedDate;

                _entity.Entry(rework).State = EntityState.Modified;
                _entity.SaveChanges();
            }
            else
            {
                return false;
            }


            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertBomList(BomList bomList)
        {
            try
            {
                _entity.BomList.Add(bomList);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertSolderingInfo(tblSolderingOthers oSolderList)
        {
            try
            {
                _entity.tblSolderingOthers.Add(oSolderList);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertDeletedOQcBatchInfo(tblDeletdPackagingBatchData oQcBatchInfo)
        {
            try
            {
                _entity.tblDeletdPackagingBatchData.Add(oQcBatchInfo);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<tblRework> IssueHistoryByImei(string imei)
        {
            List<tblRework> list;

            try
            {
                list = _entity.tblRework
                    .Where(x => (x.Imei1 == imei || x.Imei2 == imei))
                    .OrderByDescending(y => y.AddedDate)
                    .Take(1)
                    .ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblRework> GetReworkDetailsByImei(string imei)
        {
            List<tblRework> list;

            try
            {
                list = _entity.tblRework
                    .Where(x => (x.Imei1 == imei || x.Imei2 == imei) && x.Status == "P")
                    .OrderByDescending(y => y.AddedDate)
                    .Take(1)
                    .ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertAgingcBatchInfo(AgingBatchInfo agingBatchInfo)
        {
            try
            {
                _entity.AgingBatchInfo.Add(agingBatchInfo);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool UpdateProductionBatchStatus(List<ProductionMaster> producList)
        {
            foreach (var item in producList)
            {
                _entity.Configuration.LazyLoadingEnabled = false;
                ProductionMaster productionMaster =
                    _entity.ProductionMaster.FirstOrDefault(
                        x => x.ProductionId == item.ProductionId && x.MobileCode == item.MobileCode);


                if (productionMaster != null)
                {

                    if (!string.IsNullOrEmpty(item.AgingBatchNumber))
                        productionMaster.AgingBatchNumber = item.AgingBatchNumber;


                    _entity.Entry(productionMaster).State = EntityState.Modified;
                    _entity.SaveChanges();
                }
                else
                {
                    return false;
                }


            }

            return true;
        }

        public bool InsertAgingBatchQcInfo(List<ProductionMaster> productionList)
        {
            foreach (var item in productionList)
            {
                _entity.Configuration.LazyLoadingEnabled = false;
                var productionMaster =
                    _entity.ProductionMaster.FirstOrDefault(x => x.MobileCode == item.MobileCode);


                if (productionMaster != null)
                {
                    if (!string.IsNullOrEmpty(item.Passed))
                        productionMaster.Passed = item.Passed.ToUpper();
                    if (!string.IsNullOrEmpty(item.QcStation))
                        productionMaster.QcStation = item.QcStation;
                    if (item.UpdatedBy != null)
                        productionMaster.UpdatedBy = item.UpdatedBy;
                    if (item.UpdatedDate != null)
                        productionMaster.UpdatedDate = item.UpdatedDate;


                    if (string.IsNullOrEmpty(item.AgingBatchNumber))
                        productionMaster.AgingBatchNumber = null;

                    if (item.AgingBy != null)
                        productionMaster.AgingBy = item.AgingBy;
                    if (item.AgingAD != null)
                        productionMaster.AgingAD = item.AgingAD;


                    _entity.Entry(productionMaster).State = EntityState.Modified;
                    _entity.SaveChanges();
                }
                else
                {
                    return false;
                }


            }

            return true;
        }

        public bool UpdateBatchInfo(AgingBatchInfo batchInfo)
        {

            _entity.Configuration.LazyLoadingEnabled = false;
            var batchInfos =
                _entity.AgingBatchInfo.FirstOrDefault(x => x.BatchNo == batchInfo.BatchNo);


            if (batchInfos != null)
            {
                if (batchInfo.Status != "")
                    batchInfos.Status = batchInfo.Status.ToUpper();

                if (batchInfo.AgingFailed.HasValue)
                    batchInfos.AgingFailed = batchInfo.AgingFailed;

                if (batchInfo.ChargingFailed.HasValue)
                    batchInfos.ChargingFailed = batchInfo.ChargingFailed;

                _entity.Entry(batchInfos).State = EntityState.Modified;
                _entity.SaveChanges();
            }
            else
            {
                return false;
            }




            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool UpdateOQCBatchInfo(List<tblPackagingBatch> batchInfoList)
        {
            foreach (var item in batchInfoList)
            {
                _entity.Configuration.LazyLoadingEnabled = false;
                var oQcBatchInfo =
                    //_entity.tblPackagingBatch.FirstOrDefault(x => x.MobileCode == item.MobileCode && (x.Imei1 == item.Imei1 || x.Imei2 == item.Imei2));
                    _entity.tblPackagingBatch.FirstOrDefault(
                        x => (x.Imei1 == item.Imei1 || x.Imei2 == item.Imei2) && x.MasterBatch == item.MasterBatch);


                if (oQcBatchInfo != null)
                {

                    if (!string.IsNullOrEmpty(item.SystemBatch))
                        oQcBatchInfo.SystemBatch = item.SystemBatch;

                    if (!string.IsNullOrEmpty(item.Remarks))
                        oQcBatchInfo.Remarks = item.Remarks;

                    if (!string.IsNullOrEmpty(item.Delivered))
                        oQcBatchInfo.Delivered = item.Delivered;

                    if (item.ReceivedDate != null)
                        oQcBatchInfo.ReceivedDate = item.ReceivedDate;

                    if (item.ReceivedBy != null)
                        oQcBatchInfo.ReceivedBy = item.ReceivedBy;

                    if (!string.IsNullOrEmpty(item.Sample))
                        oQcBatchInfo.Sample = item.Sample;





                    if (!string.IsNullOrEmpty(item.Passed))
                    {
                        if (item.Passed.ToUpper() == "N")
                            oQcBatchInfo.SystemBatch = null;
                        if (item.Passed.ToUpper() == "N")
                            oQcBatchInfo.Passed = "N";

                        if (item.Passed.ToUpper() == "Y")
                            oQcBatchInfo.Passed = "Y";

                    }


                    _entity.Entry(oQcBatchInfo).State = EntityState.Modified;
                    _entity.SaveChanges();
                }
                else
                {
                    return false;
                }


            }

            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool GenerateImeiBatch(tblPackagingBatch packaginBatch)
        {
            try
            {
                _entity.tblPackagingBatch.Add(packaginBatch);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<tblPackagingBatch> CountPackagingBatch(long projectId, long userid)
        {

            List<tblPackagingBatch> list;
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            try
            {
                list = _entity.tblPackagingBatch
                    .Where(
                        x =>
                            x.ProjectId == projectId && (x.AddedDate >= startDate && x.AddedDate <= endDate) &&
                            x.AddedBy == userid && x.SystemBatch == null).ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return list;

        }


        public List<tblPackagingBatch> CountPackagingBatchAll(long projectId, long userid)
        {

            List<tblPackagingBatch> list;
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            try
            {
                list = _entity.tblPackagingBatch
                    .Where(
                        x =>
                            x.ProjectId == projectId && (x.AddedDate >= startDate && x.AddedDate <= endDate) &&
                            x.AddedBy == userid).ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return list;

        }




        public bool UpdatePackagingBatchStatus(List<tblPackagingBatch> packageBatchList)
        {
            foreach (var item in packageBatchList)
            {
                _entity.Configuration.LazyLoadingEnabled = false;
                var pckBatchInfo =
                    _entity.tblPackagingBatch.FirstOrDefault(
                        x => x.MobileCode == item.MobileCode && (x.Imei1 == item.Imei1 || x.Imei2 == item.Imei2));


                if (pckBatchInfo != null)
                {

                    if (!string.IsNullOrEmpty(item.SystemBatch))
                        pckBatchInfo.SystemBatch = item.SystemBatch;
                    if (item.BatchCreatedBy != null)
                        pckBatchInfo.BatchCreatedBy = item.BatchCreatedBy;


                    pckBatchInfo.BatchCreatedDate = item.BatchCreatedDate;


                    _entity.Entry(pckBatchInfo).State = EntityState.Modified;
                    _entity.SaveChanges();
                }
                else
                {
                    return false;
                }


            }

            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public List<tblPackagingBatch> GetPackagingBatchInfo(tblPackagingBatch tblPackagingBatch)
        {
            var list = new List<tblPackagingBatch>();

            try
            {

                list =
                    _entity.tblPackagingBatch.WhereIf(tblPackagingBatch.MobileCode != null,
                        x => x.MobileCode == tblPackagingBatch.MobileCode)
                        .WhereIf(tblPackagingBatch.Imei1 != null, x => x.Imei1 == tblPackagingBatch.Imei1)
                        .WhereIf(tblPackagingBatch.Imei2 != null, x => x.Imei2 == tblPackagingBatch.Imei2)

                        .ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]

        public bool DeleteOQCBatchInfoData(List<tblPackagingBatch> oQcBatchInfoList)
        {
            foreach (var item in oQcBatchInfoList)
            {
                _entity.Configuration.LazyLoadingEnabled = false;
                var pckBatchInfo =
                    _entity.tblPackagingBatch.FirstOrDefault(
                        x => x.MobileCode == item.MobileCode && (x.Imei1 == item.Imei1 || x.Imei2 == item.Imei2));


                if (pckBatchInfo != null)
                {

                    _entity.tblPackagingBatch.Remove(pckBatchInfo);
                    _entity.SaveChanges();
                }
                else
                {
                    return false;
                }


            }

            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertOqcBatch(List<tblPackagingBatch> oQcBatchInfo)
        {
            try
            {
                var consString = ConfigurationManager.ConnectionStrings["adoWcmsfactoryserver"].ConnectionString;
                var con = new SqlConnection(consString);

                var result = new Result();

                con.Open();
                var dto = new DataTable();

                dto.Columns.AddRange(new DataColumn[9]
                    {
                new DataColumn("MobileCode", typeof (string)),
                new DataColumn("Imei1", typeof (string)),
                new DataColumn("Imei2", typeof (string)),
                new DataColumn("MasterBatch", typeof (string)),
                new DataColumn("Passed", typeof (string)),
                new DataColumn("Sample", typeof (string)),
                new DataColumn("Remarks", typeof (string)),
                 new DataColumn("AddedBy", typeof (long)),
                new DataColumn("AddedDate", typeof (DateTime))
               
                
            });

                foreach (var itm in oQcBatchInfo)
                {


                    var row = dto.NewRow();
                    row["MobileCode"] = itm.MobileCode;
                    row["Imei1"] = itm.Imei1;
                    row["Imei2"] = itm.Imei2;
                    row["MasterBatch"] = itm.MasterBatch;
                    row["Passed"] = itm.Passed;
                    row["Sample"] = itm.Sample;
                    row["Remarks"] = itm.Remarks;
                    row["AddedBy"] = itm.AddedBy;
                    row["AddedDate"] = DateTime.Now;
                    dto.Rows.Add(row);

                }
                using (var sqlTransaction = con.BeginTransaction())
                {
                    using (
                        var sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default,
                            sqlTransaction))
                    {
                        //Set the database table name  tblShadowIMEIRecord
                        sqlBulkCopy.DestinationTableName = "dbo.tblPackagingBatch"; //"dbo.tblIMEIRecord";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("MobileCode", "MobileCode");
                        sqlBulkCopy.ColumnMappings.Add("Imei1", "Imei1");
                        sqlBulkCopy.ColumnMappings.Add("Imei2", "Imei2");
                        sqlBulkCopy.ColumnMappings.Add("MasterBatch", "MasterBatch");
                        sqlBulkCopy.ColumnMappings.Add("Passed", "Passed");
                        sqlBulkCopy.ColumnMappings.Add("Sample", "Sample");
                        sqlBulkCopy.ColumnMappings.Add("Remarks", "Remarks");
                        sqlBulkCopy.ColumnMappings.Add("AddedBy", "AddedBy");
                        sqlBulkCopy.ColumnMappings.Add("AddedDate", "AddedDate");
                        
                        try
                        {
                            sqlBulkCopy.WriteToServer(dto);
                            sqlTransaction.Commit();
                            return true;
                            //var message = rowCount + " Data has been Imported successfully." + "\n" + duplicateRow + " Duplicate Rows Found" + "\n";  //+ "Duplicates Values Are =" + duplicate + "

                        }
                        catch (Exception exception)
                        {
                            sqlTransaction.Rollback();
                           
                            return false;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
           // return true;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool tblLogistics(tblLogistics logisticsList)
        {
            try
            {
                _entity.tblLogistics.Add(logisticsList);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool UpdateLogisticsData(List<ImeiModelUpload> imeiModelUpload)
        {

            try
            {
                _entity.Database.CommandTimeout = 600;
                foreach (var item in imeiModelUpload)
                {

                    _entity.Configuration.LazyLoadingEnabled = false;
                    var logistics =
                        _entity.tblLogistics.FirstOrDefault(x => x.Imei1 == item.Barcode && x.Imei2 == item.Barcode2);


                    if (logistics != null)
                    {

                        logistics.Uploaded = "Y";
                        logistics.UploadedDate = DateTime.Now;
                        _entity.Entry(logistics).State = EntityState.Modified;
                        _entity.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }




            return true;

        }

        public bool InsertRepairStatus(List<tblRepairStatus> repairStatus)
        {
            try
            {

                foreach (var items in repairStatus)
                {
                    //var logisticsSendItems = new tblLogisticsSentItems();

                    var repair = new tblRepairStatus
                    {
                        ReworkId = items.ReworkId,
                        Issue = items.Issue,
                        MaterialFault = items.MaterialFault,
                        ProcessFault = items.ProcessFault,
                        IsFaulty = items.IsFaulty,
                        AddedBy = items.AddedBy,
                        AddedDate = DateTime.Now,
                        Remarks = items.Remarks
                    };
                    _entity.tblRepairStatus.Add(repair);
                    _entity.SaveChanges();
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertRepairComponents(List<tblRepairComponents> repairComponents)
        {
            try
            {

                foreach (var items in repairComponents)
                {
                    //var logisticsSendItems = new tblLogisticsSentItems();

                    var tblRepairComponents = new tblRepairComponents
                    {
                        ReworkId = items.ReworkId,
                        UsedComponents = items.UsedComponents,
                        Color = items.Color,
                        UsedQuantity = items.UsedQuantity,
                        Used = items.Used,
                        Waste = items.Waste,
                        BomId = items.BomId,
                        ProjectId = items.ProjectId,
                        WasteQuantiy = items.WasteQuantiy,
                        Remarks = items.Remarks,
                        AddedBy = items.AddedBy,
                        AddedDate = DateTime.Now,

                    };
                    _entity.tblRepairComponents.Add(tblRepairComponents);
                    _entity.SaveChanges();
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        public bool InsertAgingQcStationinfo(List<tblAgingMaster> agingBatchList)
        {
            try
            {
                _entity.Database.CommandTimeout = 300;
                foreach (var items in agingBatchList)
                {
                    //var logisticsSendItems = new tblLogisticsSentItems();

                    var tblAgingMaster = new tblAgingMaster
                    {

                        ProjectId = items.ProjectId,
                        ProjectName = items.ProjectName,
                        LineId = items.LineId,
                        MobileCode = items.MobileCode,
                        AgingBatch = items.AgingBatch,
                        AgingPassed = items.AgingPassed,
                        AgingIssue = items.AgingIssue,

                        Reworked = items.Reworked,
                        AddedBy = items.AddedBy,
                        AddedDate = DateTime.Now,

                    };
                    _entity.tblAgingMaster.Add(tblAgingMaster);
                    _entity.SaveChanges();
                }



            }
            catch (Exception ex)
            {

                //transaction.Dispose();
                throw ex;
            }
            return true;
        }

        public bool UpdateAgingQcStationinfo(List<tblAgingMaster> agingCheckedList)
        {
            try
            {
                foreach (var item in agingCheckedList)
                {
                    _entity.Configuration.LazyLoadingEnabled = false;
                    var data =
                        _entity.tblAgingMaster.FirstOrDefault(x => x.MobileCode == item.MobileCode);


                    if (data != null)
                    {
                        if (!string.IsNullOrEmpty(item.AgingPassed))
                            data.AgingPassed = item.AgingPassed;

                        //if (!string.IsNullOrEmpty(item.ChargerPassed))
                        //    data.ChargerPassed = item.ChargerPassed;

                        //if (item.AgingChecked.HasValue)
                        //data.AgingChecked = item.AgingChecked;

                        //if (item.ChargerChecked.HasValue)
                        //    data.ChargerChecked = item.ChargerChecked;

                        //if (!string.IsNullOrEmpty(item.AgingIssue))
                        //data.AgingIssue = item.AgingIssue;

                        //if (!string.IsNullOrEmpty(item.ChargerIssue))
                        //data.ChargerIssue = item.ChargerIssue;

                        if (item.Reworked.HasValue)
                            data.Reworked = item.Reworked;



                        _entity.Entry(data).State = EntityState.Modified;
                        _entity.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertOqcCheckedItems(tblOqcCheckedItems checkedItems)
        {
            try
            {
                _entity.tblOqcCheckedItems.Add(checkedItems);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertAgingBatchStatus(AgingBatch batchesult)
        {
            try
            {
                _entity.AgingBatch.Add(batchesult);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertChargingQcStationinfo(List<tblChargerMaster> chargingCheckedList)
        {
            try
            {


                foreach (var items in chargingCheckedList)
                {
                    //var logisticsSendItems = new tblLogisticsSentItems();

                    var tblChargerMaster = new tblChargerMaster
                    {

                        ProjectId = items.ProjectId,
                        ProjectName = items.ProjectName,
                        LineId = items.LineId,
                        MobileCode = items.MobileCode,
                        ChargingBatch = items.ChargingBatch,
                        ChargingPassed = items.ChargingPassed,
                        ChargingIssue = items.ChargingIssue,

                        Reworked = items.Reworked,
                        AddedBy = items.AddedBy,
                        AddedDate = DateTime.Now,

                    };
                    _entity.tblChargerMaster.Add(tblChargerMaster);
                    _entity.SaveChanges();
                }



            }
            catch (Exception ex)
            {

                //transaction.Dispose();
                throw ex;
            }
            return true;
        }

        public bool UpdateLogisticsDataForOracleUpload(List<ImeiModelUpload> list, string oracletranscationCode)
        {
            try
            {
                _entity.Database.CommandTimeout = 600;
                foreach (var item in list)
                {

                    _entity.Configuration.LazyLoadingEnabled = false;
                    var logistics =
                        _entity.tblLogistics.FirstOrDefault(x => x.Imei1 == item.Imei1 && x.Imei2 == item.Imei2 && x.OracleUploaded == null);


                    if (logistics != null)
                    {

                        logistics.OracleUploaded = "Y";


                        var versionString = item.WO;


                        var index = versionString.IndexOf("_", versionString.IndexOf("_", versionString.IndexOf("_") + 1) + 1);

                        var version = versionString.Substring(0, index);

                        logistics.OracleTransactionCode = version + "_" + oracletranscationCode;


                        logistics.OracleUploadedDate = DateTime.Now;

                        _entity.Entry(logistics).State = EntityState.Modified;
                        _entity.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }




            return true;
        }
    }
}



