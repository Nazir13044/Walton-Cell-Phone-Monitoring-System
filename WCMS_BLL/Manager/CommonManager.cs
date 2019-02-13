using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BR_BLL;
using WCMS_COMMON;
using WCMS_DAL.Inserting;
using WCMS_DAL.Interfaces;
using WCMS_DAL.Selecting;
using WCMS_ENTITY;
using System.Transactions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;


namespace WCMS_BLL.Manager
{
    public class CommonManager
    {



        public Result InsertEmployeeInfo(EmployeeInfo _employee, tblLogin login)
        {
            try
            {

                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IDataAccessInsert.InsertEmployeeInfo(_employee);
                    if (_Result.IsSuccess)
                    {
                        _Result.IsSuccess = _IDataAccessInsert.InsertLoginInfo(login);
                        if (_Result.IsSuccess)

                            transaction.Complete();


                    }
                    return _Result;
                }

            }
            catch (Exception ex) { throw ex; }

        }




        public List<BomList> GetComponentList()
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetComponentList();
            }
            catch (Exception ex) { throw ex; }
        }




        public List<ProjectMaster> GetProjectNameList()
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetProjectNameList();
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertProjectBomList(ProjectBomList oProjectBomList)
        {
            try
            {

                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IDataAccessInsert.InsertProjectBomList(oProjectBomList);
                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Employee> GetEmployeeList(string term)
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetEmployeeList(term);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<EmployeeInfo> GetEmployeeByID(EmployeeInfo _Entity)
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetEmployeeByID(_Entity);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblLogin> GetLoginUser(tblLogin entity)
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetLoginUser(entity);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result UpdateLoginUser(tblLogin login,string newPassword)
        {
            Result _Result = new Result();
            try
            {
               
                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();

              
                _Result.IsSuccess= _IDataAccessInsert.UpdateLoginUser(login, newPassword);
            }
            catch (Exception ex) { throw ex; }

            return _Result;
        }

        public Result CreateDailyPackagingList(tblDailyPacking oDailyPacking)
        {
            try
            {

                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IDataAccessInsert.CreateDailyPackagingList(oDailyPacking);
                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }



        public List<ProjectBomList> GetComponentsByProjectId(ProjectBomList projectBomList)
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetComponentsByProjectId(projectBomList);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblRework> GetAllIssuesList()
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetAllIssuesList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblAssemblyLineSetup> GetAssemblineInfo(tblAssemblyLineSetup tblAssemblyLineSetup)
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetAssemblineInfo(tblAssemblyLineSetup);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ProductionMaster> ProductionMasterInfo(ProductionMaster productionMaster)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.ProductionMasterInfo(productionMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertComponentRequisition(tblComponentRequisition componentRequisition)
        {
            try
            {

                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IDataAccessInsert.InsertComponentRequisition(componentRequisition);
                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Result UpdateComponentRequisitionList(tblAssemblyLineSetupDetails tblAssemblyLineSetupDetails)
        {
            try
            {

                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = _IDataAccessInsert.UpdateComponentRequisitionList(tblAssemblyLineSetupDetails);
                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ProductionMaster> ProductionMasterInfoByImei(string code)
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.ProductionMasterInfoByImei(code);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<AssemblyLineInfo> GetLineWiseProjectInfo()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetLineWiseProjectInfo();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ProductionMaster> GetDetailsByImei(string imei)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetDetailsByImei(imei);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Issues> GetAllIssueList()
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetAllIssueList();
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertBomList(List<BomList> bomList, long userId)
        {
            try
            {

                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    var result = new Result();


                    foreach (var list in bomList)
                    {
                        var bomLists = new BomList();

                        bomLists.ComponentName = list.ComponentName;
                        bomLists.ComponentCode = list.ComponentCode;
                        bomLists.AddedBy = userId;
                        bomLists.AddedDate = DateTime.Now;
                        result.IsSuccess = _IDataAccessInsert.InsertBomList(bomLists);
                    }






                  
                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblLogin> GetRegEmployee(string term)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetRegEmployee(term);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblComponentRequisition> GetComponentReqList(string reqNumber)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetComponentReqList(reqNumber);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BomList> GetMaterialInfo(BomList bomList)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetMaterialInfo(bomList);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ProjectBomList> GetProjectWiseBomList(ProjectBomList projectBomList)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetProjectWiseBomList(projectBomList);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertIssuedComponents(tblDailyIssuedComponents issuedComponents)
        {
            try
            {

                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    var result = new Result();

                    issuedComponents.AddedDate = DateTime.Now;
                    result.IsSuccess = _IDataAccessInsert.InsertIssuedComponents(issuedComponents);

                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblDailyIssuedComponents> CountIssuedComponents()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.CountIssuedComponents();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblLogin> GetRegisterdeEmployee()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetRegisterdeEmployee();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ReworkList> GetFaultyMobileList()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetFaultyMobileList();
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertScrewStationInfo(tblScrew screw)
        {
            try
            {

                IInsertingSetupCommon _IDataAccessInsert = new WCMS_Common_Inserting();
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    var result = new Result();


                    result.IsSuccess = _IDataAccessInsert.InsertScrewStationInfo(screw);

                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex) { throw ex; }
            
        }

        public List<tblScrew> GetScrewDoneCount()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetScrewDoneCount();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ProductionMaster> GetFunctionalQcCount()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetFunctionalQcCount();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ProductionMaster> GetAestheticQcCount()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetAestheticQcCount();
            }
            catch (Exception ex) { throw ex; }
        }

        public System.Collections.Generic.List<ProductionMaster> GetPackagingCount()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetPackagingCount();
            }
            catch (Exception ex) { throw ex; }
        }

        public System.Collections.Generic.List<ProductionMaster> GetPackagingAestheticCount()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetPackagingAestheticCount();
            }
            catch (Exception ex) { throw ex; }
        }

        public System.Collections.Generic.List<ProductionMaster> GetPackagingOqcCount()
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetPackagingOqcCount();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblDailyIssuedComponents> GetPCBInfo(tblDailyIssuedComponents tblDailyIssuedComponents)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetPCBInfo(tblDailyIssuedComponents);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblScrew> GetScrewStationInfo(tblScrew tblScrew)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetScrewStationInfo(tblScrew);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblPackagingBatch> GetOQCBatchInfo(tblPackagingBatch oQcBatchInfo)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetOQCBatchInfo(oQcBatchInfo);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblPackagingBatch> GetOQCBatchInfoByImei(string imeiCode)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetOQCBatchInfoByImei(imeiCode);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ProjectMaster> GetProjectNameListByParam(ProjectMaster projectMaster)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetProjectNameListByParam(projectMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<AgingBatchInfo> GetAgingBatchData(AgingBatchInfo agingBatchInfo)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetAgingBatchData(agingBatchInfo);
            }
            catch (Exception ex) { throw ex; }
        }

        public System.Collections.Generic.List<tblIMEIRecord> GetImeiRecords(string imei)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetImeiRecords(imei);
            }
            catch (Exception ex) { throw ex; } 
        }

        public System.Collections.Generic.List<F_Projects> GetProjecFormvsunDb()
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetProjecFormvsunDb();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<MasterBoxModel> GetMasterBoxData(string boxCode, string project)
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetMasterBoxData(boxCode, project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tblLogistics> GetLogisticData()
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetLogisticData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tblLogistics> GetLogisticsList(tblLogistics logistics)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetLogisticsList(logistics);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<tblLogisticsSentItems> GetLogisticsReleaselist(tblLogisticsSentItems tblLogisticsSentItems)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetLogisticsReleaselist(tblLogisticsSentItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result InsertLogisticsSendData(List<tblLogisticsSentItems> logisticsSendList)
        {
            IInsertingSetupCommon iDataAccessInsert = new WCMS_Common_Inserting();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iDataAccessInsert.InsertLogisticsSendData(logisticsSendList);

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

        public List<tblWarehouse> GetWarehouseReceivedlist(tblWarehouse tblWarehouse)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetWarehouseReceivedlist(tblWarehouse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result InsertWareHouseData(List<tblWarehouse> wareHouseData)
        {
            IInsertingSetupCommon iDataAccessInsert = new WCMS_Common_Inserting();
            var result = new Result();
            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    ApplicationState.TransactionOptions))
                try
                {

                    result.IsSuccess = iDataAccessInsert.InsertWareHouseData(wareHouseData);

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

        public List<ReworkList> GetFaultyMobileHistory(string mobileCode)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetFaultyMobileHistory(mobileCode);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertModelsImeiData(System.Collections.Generic.List<ImeiModelUpload> imeiModelUpload)
        {
            IInsertingSetupCommon iDataAccessInsert = new WCMS_Common_Inserting();
            var result = new Result();
           
                try
                {
                    result = iDataAccessInsert.InsertModelsImeiData(imeiModelUpload);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return result;
        }

        public List<tblColors> GetColors()
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.tblColors();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblRework> GetCompletedRepairCount()
        {
            try
            {
                ISelectingCommon _IDataAccessSelect = new DALGetCommonSelecting();
                return _IDataAccessSelect.GetCompletedRepairCount();
            }
            catch (Exception ex) { throw ex; }
        }

        public Issues GetIssueCriteria(Issues issues)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.GetIssueCriteria(issues);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblAgingMaster> AgingMasterInfo(tblAgingMaster tblAgingMaster)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.AgingMasterInfo(tblAgingMaster);
            }
            catch (Exception ex) { throw ex; }

        }

        public List<tblChargerMaster> ChargingMasterInfo(tblChargerMaster tblChargerMaster)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.ChargingMasterInfo(tblChargerMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<AgingBatch> AgingBatcInfo(AgingBatch agingBatch)
        {
            try
            {
                ISelectingCommon iDataAccessSelect = new DALGetCommonSelecting();
                return iDataAccessSelect.AgingBatcInfo(agingBatch);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
