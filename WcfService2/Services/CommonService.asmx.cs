using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WCMS_BLL.Manager;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_ENTITY;
using WCMS_MAIN.Models;


namespace WcfService2.Services
{
    /// <summary>
    /// Summary description for CommonService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CommonService : System.Web.Services.WebService
    {

        CommonManager _CommonManager = new CommonManager();




         [WebMethod]
        public Result InsertEmployeeInfo(EmployeeInfo _employee,tblLogin login)
        {
            try
            {
                return _CommonManager.InsertEmployeeInfo(_employee, login);
            }
            catch (Exception ex)
            {
               
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }


        [WebMethod]
        public List<BomList> GetComponentList()
        {
            List<BomList> _bomList = new List<BomList>();
            try
            {
                _bomList = _CommonManager.GetComponentList();
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return _bomList;
        }

        [WebMethod]
        public List<ProjectMaster> GetProjectNameList()
        {
            List<ProjectMaster> _projectLists = new List<ProjectMaster>();
            try
            {
                _projectLists = _CommonManager.GetProjectNameList();
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return _projectLists;
        }

        public Result InsertProjectBomList(ProjectBomList oProjectBomList)
        {
            try
            {
                return _CommonManager.InsertProjectBomList(oProjectBomList);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //log.Error("Select Bearer: " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

      
        [WebMethod]
        public List<Employee> GetEmployeeList(string term)
        {
            List<Employee> _employeeList= new List<Employee>();
            try
            {
                _employeeList = _CommonManager.GetEmployeeList(term);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return _employeeList;
        }


        [WebMethod]
        public List<EmployeeInfo> GetEmployeeByID(EmployeeInfo _Entity)
        {
            var employees = new List<EmployeeInfo>();
           
            try
            {
                employees = _CommonManager.GetEmployeeByID(_Entity);
            }
            catch (Exception ex)
            {

            }

            return employees;
        }





          [WebMethod]
        public List<tblLogin> GetLoginUser(tblLogin entity)
        {
            List<tblLogin> loginUsers = new List<tblLogin>();

            try
            {
                loginUsers = _CommonManager.GetLoginUser(entity);
            }
            catch (Exception ex)
            {

            }

            return loginUsers;
        }
        [WebMethod]
          public Result UpdateLoginUser(tblLogin login, string newPassword)
          {
              try
              {
                  return _CommonManager.UpdateLoginUser(login, newPassword);
              }
              catch (Exception ex)
              {

                  return new Result { IsSuccess = false, Message = ex.Message };
              }
          }

        public Result CreateDailyPackagingList(tblDailyPacking oDailyPacking)
        {
            try
            {
                return _CommonManager.CreateDailyPackagingList(oDailyPacking);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //log.Error("Select Bearer: " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }



        public List<ProjectBomList> GetComponentsByProjectId(ProjectBomList projectBomList)
        {
            List<ProjectBomList> projectBomLists = new List<ProjectBomList>();

            try
            {
                projectBomLists = _CommonManager.GetComponentsByProjectId(projectBomList);
            }
            catch (Exception ex)
            {

            }

            return projectBomLists;
        }

        

        [WebMethod]
        public List<tblRework> GetAllIssuesList()
        {
            List<tblRework> reworkList = new List<tblRework>();
            try
            {
                reworkList = _CommonManager.GetAllIssuesList();
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return reworkList;
        }




        public List<tblAssemblyLineSetup> GetAssemblineInfo(tblAssemblyLineSetup tblAssemblyLineSetup)
        {
            var assemblyLineList = new List<tblAssemblyLineSetup>();

            try
            {
                assemblyLineList = _CommonManager.GetAssemblineInfo(tblAssemblyLineSetup);
            }
            catch (Exception ex)
            {

            }

            return assemblyLineList;
        }





        public List<ProductionMaster> ProductionMasterInfo(ProductionMaster productionMaster)
        {

            var productionMasterList = new List<ProductionMaster>();

            try
            {
                productionMasterList = _CommonManager.ProductionMasterInfo(productionMaster);
            }
            catch (Exception ex)
            {

            }

            return productionMasterList;
        }

        public Result InsertComponentRequisition(tblComponentRequisition componentRequisition)
        {
            try
            {
                return _CommonManager.InsertComponentRequisition(componentRequisition);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //log.Error("Select Bearer: " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result UpdateComponentRequisitionList(tblAssemblyLineSetupDetails tblAssemblyLineSetupDetails)
        {
            try
            {
                return _CommonManager.UpdateComponentRequisitionList(tblAssemblyLineSetupDetails);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //log.Error("Select Bearer: " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<ProductionMaster> ProductionMasterInfoByImei(string code)
        {
            var productionMasterList = new List<ProductionMaster>();

            try
            {
                productionMasterList = _CommonManager.ProductionMasterInfoByImei(code);
            }
            catch (Exception ex)
            {

            }

            return productionMasterList;
        }




        [WebMethod]
        public List<AssemblyLineInfo> GetLineWiseProjectInfo()
        {
            var assemblyLineSetup = new List<AssemblyLineInfo>();
            try
            {
                assemblyLineSetup = _CommonManager.GetLineWiseProjectInfo();
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return assemblyLineSetup; //reworkList;
        }




        public List<ProductionMaster> GetDetailsByImei(string imei)
        {

            var productionMasterList = new List<ProductionMaster>();

            try
            {
                productionMasterList = _CommonManager.GetDetailsByImei(imei);
            }
            catch (Exception ex)
            {

            }

            return productionMasterList;
        }


        [WebMethod]
       
        public List<Issues> GetAllIssueList()
        {
            var _bomList = new List<Issues>();
            try
            {
                _bomList = _CommonManager.GetAllIssueList();
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return _bomList;
        }
        [WebMethod]
        public Result InsertBomList(List<BomList> bomList, long userId)
        {
            try
            {
                return _CommonManager.InsertBomList(bomList, userId);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
            
        }
        [WebMethod]
        public List<tblLogin> GetRegEmployee(string term)
        {
            var loginList = new List<tblLogin>();
            try
            {
                loginList = _CommonManager.GetRegEmployee(term);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return loginList;
        }
        [WebMethod]
        public List<tblComponentRequisition> GetComponentReqList(string reqNumber)
        {
            var list = new List<tblComponentRequisition>();
            try
            {
                list = _CommonManager.GetComponentReqList(reqNumber);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return list;
        }


         [WebMethod]
        public List<BomList> GetMaterialInfo(BomList bomList)
        {
            var list = new List<BomList>();

            try
            {
                list = _CommonManager.GetMaterialInfo(bomList);
            }
            catch (Exception ex)
            {

            }

            return list;




            
        }


         [WebMethod]
        public object GetProjectWiseBomList(ProjectBomList projectBomList)
        {
            var list = new List<ProjectBomList>();

            try
            {
                list = _CommonManager.GetProjectWiseBomList(projectBomList);
            }
            catch (Exception ex)
            {

            }

            return list;
        }
         [WebMethod]
        public Result InsertIssuedComponents(tblDailyIssuedComponents issuedComponents)
        {
            try
            {
                return _CommonManager.InsertIssuedComponents(issuedComponents);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }
         [WebMethod]
        public List<tblDailyIssuedComponents> CountIssuedComponents()
        {
            var list = new List<tblDailyIssuedComponents>();
            try
            {
                list = _CommonManager.CountIssuedComponents();
            }
            catch (Exception ex)
            {
                
            }

            return list;
        }
         [WebMethod]
        public List<tblLogin> GetRegisterdeEmployee()
        {
            var list = new List<tblLogin>();
            try
            {
                list = _CommonManager.GetRegisterdeEmployee();
            }
            catch (Exception ex)
            {

            }

            return list;
        }
         [WebMethod]
         public List<ReworkList> GetFaultyMobileList()
        {
            var list = new List<ReworkList>();
            try
            {
                list = _CommonManager.GetFaultyMobileList();
            }
            catch (Exception ex)
            {

            }

            return list;
        }
         [WebMethod]
         public Result InsertScrewStationInfo(tblScrew screw)
         {
             try
             {
                 return _CommonManager.InsertScrewStationInfo(screw);
             }
             catch (Exception ex)
             {
                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }
         [WebMethod]
         public List<tblScrew> GetScrewDoneCount()
         {
             var list = new List<tblScrew>();
             try
             {
                 list = _CommonManager.GetScrewDoneCount();
             }
             catch (Exception ex)
             {

             }
             return list;
         }
         [WebMethod]
         public List<ProductionMaster> GetFunctionalQcCount()
         {
             var list = new List<ProductionMaster>();
             try
             {
                 list = _CommonManager.GetFunctionalQcCount();
             }
             catch (Exception ex)
             {

             }
             return list;
         }
         [WebMethod]
         public List<ProductionMaster> GetAestheticQcCount()
         {
             var list = new List<ProductionMaster>();
             try
             {
                 list = _CommonManager.GetAestheticQcCount();
             }
             catch (Exception ex)
             {

             }
             return list;
         }
         [WebMethod]
         public List<ProductionMaster> GetPackagingCount()
         {
             var list = new List<ProductionMaster>();
             try
             {
                 list = _CommonManager.GetPackagingCount();
             }
             catch (Exception ex)
             {

             }
             return list;
         }
         [WebMethod]
         public List<ProductionMaster> GetPackagingAestheticCount()
         {
             var list = new List<ProductionMaster>();
             try
             {
                 list = _CommonManager.GetPackagingAestheticCount();
             }
             catch (Exception ex)
             {

             }
             return list;
         }
         [WebMethod]
         public List<ProductionMaster> GetPackagingOqcCount()
         {
             var list = new List<ProductionMaster>();
             try
             {
                 list = _CommonManager.GetPackagingOqcCount();
             }
             catch (Exception ex)
             {

             }
             return list;
         }
         [WebMethod]
         public List<tblDailyIssuedComponents> GetPCBInfo(tblDailyIssuedComponents tblDailyIssuedComponents)
         {
             var list = new List<tblDailyIssuedComponents>();
             try
             {
                 list = _CommonManager.GetPCBInfo(tblDailyIssuedComponents);
             }
             catch (Exception ex)
             {

             }
             return list;
         }
         [WebMethod]
         public List<tblScrew> GetScrewStationInfo(tblScrew tblScrew)
         {
             var list = new List<tblScrew>();
             try
             {
                 list = _CommonManager.GetScrewStationInfo(tblScrew);
             }
             catch (Exception ex)
             {

             }
             return list;
         }




         [WebMethod]
         public List<tblPackagingBatch> GetOQCBatchInfo(tblPackagingBatch oQcBatchInfo)
         {

             var list = new List<tblPackagingBatch>();

             try
             {
                 list = _CommonManager.GetOQCBatchInfo(oQcBatchInfo);
             }
             catch (Exception ex)
             {

             }

             return list;
         }

         public List<tblPackagingBatch> GetOQCBatchInfoByImei(string imeiCode)
         {
             List<tblPackagingBatch> list;

             try
             {

                 list = _CommonManager.GetOQCBatchInfoByImei(imeiCode);
             }
             catch (Exception ex)
             {
                 throw ex;
             }

             return list;
         }
        [WebMethod]
         public List<ProjectMaster> GetProjectNameListByParam(ProjectMaster projectMaster)
         {
             var list = new List<ProjectMaster>();
             try
             {
                 list = _CommonManager.GetProjectNameListByParam(projectMaster);
             }
             catch (Exception ex)
             {

             }
             return list;
         }





         [WebMethod]
        public List<AgingBatchInfo> GetAgingBatchData(AgingBatchInfo agingBatchInfo)
        {

            var list = new List<AgingBatchInfo>();
            try
            {
                list = _CommonManager.GetAgingBatchData(agingBatchInfo);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

         public List<tblIMEIRecord> GetImeiRecords(string imei)
         {
             List<tblIMEIRecord> list;

             try
             {

                 list = _CommonManager.GetImeiRecords(imei);
             }
             catch (Exception ex)
             {
                 throw ex;
             }

             return list;
         }


         [WebMethod]
         public List<F_Projects> GetProjecFormvsunDb()
         {
             var projectLists = new List<F_Projects>();
             try
             {
                 projectLists = _CommonManager.GetProjecFormvsunDb();
             }
             catch (Exception ex)
             {
                 //if (log.IsErrorEnabled)
                 //{
                 //    log.Error("Select Region : " + ex.Message);
                 //}
             }

             return projectLists;
         }


         [WebMethod]
         public List<MasterBoxModel> GetMasterBoxData(string boxCode, string project)
         {
             var hourlyTargetList = new List<MasterBoxModel>();

             try
             {
                 hourlyTargetList = _CommonManager.GetMasterBoxData(boxCode, project);

             }
             catch (Exception ex)
             {

             }

             return hourlyTargetList;
         }


         [WebMethod]
         public List<tblLogistics> GetLogisticData()
         {
             var list = new List<tblLogistics>();

             try
             {
                 list = _CommonManager.GetLogisticData();

             }
             catch (Exception ex)
             {

             }

             return list;
         }

         public List<tblLogistics> GetLogisticsList(tblLogistics logistics)
         {
             var list = new List<tblLogistics>();

             try
             {
                 list = _CommonManager.GetLogisticsList(logistics);

             }
             catch (Exception ex)
             {

             }

             return list;
         }



         public List<tblLogisticsSentItems> GetLogisticsReleaselist(WCMS_ENTITY.tblLogisticsSentItems tblLogisticsSentItems)
         {
             var list = new List<tblLogisticsSentItems>();

             try
             {
                 list = _CommonManager.GetLogisticsReleaselist(tblLogisticsSentItems);

             }
             catch (Exception ex)
             {

             }

             return list;
         }

         public Result InsertLogisticsSendData(List<tblLogisticsSentItems> logisticsSendList)
         {
             try
             {
                 return _CommonManager.InsertLogisticsSendData(logisticsSendList);
             }
             catch (Exception ex)
             {

                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }

         public List<tblWarehouse> GetWarehouseReceivedlist(tblWarehouse tblWarehouse)
         {
             var list = new List<tblWarehouse>();

             try
             {
                 list = _CommonManager.GetWarehouseReceivedlist(tblWarehouse);

             }
             catch (Exception ex)
             {

             }

             return list;
         }

         public Result InsertWareHouseData(List<tblWarehouse> wareHouseData)
         {
             try
             {
                 return _CommonManager.InsertWareHouseData(wareHouseData);
             }
             catch (Exception ex)
             {

                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }


         [WebMethod]
         public List<ReworkList> GetFaultyMobileHistory(string mobileCode)
         {
             var list = new List<ReworkList>();
             try
             {
                 list = _CommonManager.GetFaultyMobileHistory(mobileCode);
             }
             catch (Exception ex)
             {

             }

             return list;
         }



         public Result InsertModelsImeiData(List<ImeiModelUpload> imeiModelUpload)
         {
             try
             {
                 return _CommonManager.InsertModelsImeiData(imeiModelUpload);
             }
             catch (Exception ex)
             {

                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }

         public List<tblColors> GetColors()
         {
             var projectLists = new List<tblColors>();
             try
             {
                 projectLists = _CommonManager.GetColors();
             }
             catch (Exception ex)
             {
                 //if (log.IsErrorEnabled)
                 //{
                 //    log.Error("Select Region : " + ex.Message);
                 //}
             }

             return projectLists;
         }

         public List<tblRework> GetCompletedRepairCount()
         {
             var reworkList = new List<tblRework>();
             try
             {
                 reworkList = _CommonManager.GetCompletedRepairCount();
             }
             catch (Exception ex)
             {
                 //if (log.IsErrorEnabled)
                 //{
                 //    log.Error("Select Region : " + ex.Message);
                 //}
             }

             return reworkList;
         }

         public Issues GetIssueCriteria(Issues issues)
         {
            
             var issueCategory=new Issues();
             try
             {
                  issueCategory = _CommonManager.GetIssueCriteria(issues);
                
             }
             catch (Exception ex)
             {

             }
             return issueCategory;
            
         }

         public List<tblAgingMaster> AgingMasterInfo(tblAgingMaster tblAgingMaster)
         {


             var agingMasters = new List<tblAgingMaster>();

            try
            {
                agingMasters = _CommonManager.AgingMasterInfo(tblAgingMaster);
            }
            catch (Exception ex)
            {

            }

            return agingMasters;
      
         }

         //public object ChargingMasterInfo(WCMS_ENTITY.tblChargerMaster tblChargerMaster)
         //{
         //    throw new NotImplementedException();
         //}

         public List<tblChargerMaster> ChargingMasterInfo(tblChargerMaster tblChargerMaster)
         {


             var agingMasters = new List<tblChargerMaster>();

             try
             {
                 agingMasters = _CommonManager.ChargingMasterInfo(tblChargerMaster);
             }
             catch (Exception ex)
             {

             }

             return agingMasters;

         }

         public List<AgingBatch> AgingBatcInfo(AgingBatch agingBatch)
         {
             var agingBatchList = new List<AgingBatch>();

             try
             {
                 agingBatchList = _CommonManager.AgingBatcInfo(agingBatch);
             }
             catch (Exception ex)
             {

             }

             return agingBatchList;
         }
    }
}
