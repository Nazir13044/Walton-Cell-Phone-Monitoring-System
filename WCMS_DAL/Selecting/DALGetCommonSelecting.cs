using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCMS_DAL.HelperClass;
using WCMS_DAL.Interfaces;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;

namespace WCMS_DAL.Selecting
{
    public class DALGetCommonSelecting : ISelectingCommon
    {
        readonly WCMSEntities _wcmsEntities = new WCMSEntities();
        readonly WCMSCellPhoneProjectEntities _wcmsCellPhoneProjectEntities=new WCMSCellPhoneProjectEntities();
        readonly WKPIEntities _employeeEntity = new WKPIEntities();
        readonly VsunDBEntities _vsunDbEntities = new VsunDBEntities();
        
        
        
        //[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        public List<BomList> GetComponentList()
        {
            List<BomList> list;
            try
            {
                list = _wcmsEntities.BomList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<ProjectMaster> GetProjectNameList()
        {
            var list = new List<ProjectMaster>();
            try
            {
                list = _wcmsCellPhoneProjectEntities.ProjectMasters.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }



        public List<Employee> GetEmployeeList(string term)
        {
            List<Employee> employeeList;
            try
            {
                employeeList = _employeeEntity.Employees.Where(x => (x.EmployeeId.Contains(term)||x.Name.Contains(term)) && x.Status=="Active").OrderBy(x => x.Name).ThenByDescending(x => x.EmployeeId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employeeList;
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public List<EmployeeInfo> GetEmployeeByID(EmployeeInfo _Entity)
        {
            var list = new List<EmployeeInfo>();

            try
            {

                list = _wcmsEntities.EmployeeInfo
                    .WhereIf(_Entity.EmployeeId !=null, x => x.EmployeeId == _Entity.EmployeeId)
                    .WhereIf(_Entity.Name !=null, x => x.Name == _Entity.Name)
                

                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
           
        }


        public List<tblLogin> GetLoginUser(tblLogin entity)
        {
            List<tblLogin> list;

            try
            {

                list = _wcmsEntities.tblLogin
                    .WhereIf(entity.Id != 0, x => x.Id == entity.Id)
                    .WhereIf(entity.Password != null, x => x.Password == entity.Password)
                    .WhereIf(entity.EmployeeId != null, x => x.EmployeeId == entity.EmployeeId)
                     .WhereIf(entity.UserName != null, x => x.UserName == entity.UserName)


                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public List<ProjectBomList> GetComponentsByProjectId(ProjectBomList projectBomList)
        {
            var list = new List<ProjectBomList>();

            try
            {

                list = _wcmsEntities.ProjectBomList
                    .WhereIf(projectBomList.ProjectMasterId != null, x => x.ProjectMasterId == projectBomList.ProjectMasterId)
                    


                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public List<tblRework> GetAllIssuesList()
        {
            List<tblRework> list;
            try
            {
                list = _wcmsEntities.tblRework.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblAssemblyLineSetup> GetAssemblineInfo(tblAssemblyLineSetup tblAssemblyLineSetup)
        {
            List<tblAssemblyLineSetup> list;

            try
            {

                list = _wcmsEntities.tblAssemblyLineSetup
                    .WhereIf(tblAssemblyLineSetup.ProjectId != null, x => x.ProjectId == tblAssemblyLineSetup.ProjectId)



                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<ProductionMaster> ProductionMasterInfo(ProductionMaster productionMaster)
        {
            List<ProductionMaster> list;

            try
            {

                list = _wcmsEntities.ProductionMaster
                    .WhereIf(productionMaster.ProjectId != null, x => x.ProjectId == productionMaster.ProjectId)
                    .WhereIf(productionMaster.MobileCode!=null, x => x.MobileCode == productionMaster.MobileCode)
                    .WhereIf(productionMaster.Imei1 != null, x => x.Imei1 == productionMaster.Imei1)
                    .WhereIf(productionMaster.Imei2 != null, x => x.Imei2 == productionMaster.Imei2)
                    .WhereIf(productionMaster.Passed != null, x => x.Passed == productionMaster.Passed)
                    .WhereIf(productionMaster.QcStation != null, x => x.QcStation == productionMaster.QcStation)
                    .WhereIf(productionMaster.AgingBatchNumber != null, x => x.AgingBatchNumber == productionMaster.AgingBatchNumber)
                    

                    .WhereIf(productionMaster.FunctionalBy != null, x => x.FunctionalBy == productionMaster.FunctionalBy)
                    .WhereIf(productionMaster.FunctionalAD != null, x => x.FunctionalAD == productionMaster.FunctionalAD)
                    .WhereIf(productionMaster.AestheticBy != null, x => x.AestheticBy == productionMaster.AestheticBy)
                    .WhereIf(productionMaster.AestheticAD != null, x => x.AestheticAD == productionMaster.AestheticAD)
                    .WhereIf(productionMaster.AgingBy != null, x => x.AgingBy == productionMaster.AgingBy)
                    .WhereIf(productionMaster.AgingAD != null, x => x.AgingAD == productionMaster.AgingAD)
                    .WhereIf(productionMaster.PackagingBy != null, x => x.AgingBy == productionMaster.PackagingBy)
                    .WhereIf(productionMaster.PackagingAD != null, x => x.PackagingAD == productionMaster.PackagingAD)
                    .WhereIf(productionMaster.PackagingAstheticBy != null, x => x.PackagingAstheticBy == productionMaster.PackagingAstheticBy)
                    .WhereIf(productionMaster.PackagingAstheticAD != null, x => x.PackagingAstheticAD == productionMaster.PackagingAstheticAD)
                     .WhereIf(productionMaster.PackagingOQCBy != null, x => x.PackagingOQCBy == productionMaster.PackagingOQCBy)
                    .WhereIf(productionMaster.PackagingOQCAD != null, x => x.PackagingOQCAD == productionMaster.PackagingOQCAD)



                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<ProductionMaster> ProductionMasterInfoByImei(string code)
        {
            List<ProductionMaster> list;

            try
            {

                list = _wcmsEntities.ProductionMaster.Where(a=>a.Imei1==code ||a.Imei2==code).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<AssemblyLineInfo> GetLineWiseProjectInfo()
        {
            List<AssemblyLineInfo> list;
            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(1).AddTicks(-1);
            try
            {

                list  = (from asemblyLine in _wcmsEntities.tblAssemblyLineSetup
                                         join line in _wcmsEntities.tblProductionLine on asemblyLine.AssemblyLineId equals line.LineId
                         where asemblyLine.AddedDate >= startDate && asemblyLine.AddedDate <= endDate
                         select new AssemblyLineInfo {

                             ProjectId = (long) asemblyLine.ProjectId,
                             ProjectName = asemblyLine.ProjectName ?? "",
                             LineId = line.LineId,
                             LineName = line.LineName??"",
                             IssuedQuantity = (int)asemblyLine.IssuedQuantity,
                             HourlyTarget = (int) asemblyLine.HourlyTargetQuantity,
                             ManPower = (int) asemblyLine.ManPower,
                             TotalTarget = (int)asemblyLine.TotalTargetQuantity

                            } ).AsNoTracking().ToList();
               

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }





        public List<ProductionMaster> GetDetailsByImei(string imei)
        {

            List<ProductionMaster> list;
            try
            {

                list = _wcmsEntities.ProductionMaster.Where(a => a.Imei1 == imei || a.Imei2 == imei).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<Issues> GetAllIssueList()
        {
            List<Issues> list;
            try
            {

                list = _wcmsEntities.Issues.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblLogin> GetRegEmployee(string term)
        {
            List<tblLogin> list;
            try
            {

                list = _wcmsEntities.tblLogin.Where(x => (x.EmployeeId.Contains(term) || x.EmployeeName.Contains(term) && x.RoleId != 1)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblComponentRequisition> GetComponentReqList(string reqNumber)
        {
            List<tblComponentRequisition> list;
            try
            {
                list = _wcmsEntities.tblComponentRequisition.Where(a => a.OracleReqNumber == reqNumber).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<BomList> GetMaterialInfo(BomList bomList)
        {
            List<BomList> list;

            try
            {

                list = _wcmsEntities.BomList
                      .WhereIf(bomList.Id != null, x => x.Id == bomList.Id)
                      .WhereIf(!string.IsNullOrEmpty( bomList.ComponentName), x => x.ComponentName == bomList.ComponentName)
                      .WhereIf(!string.IsNullOrEmpty( bomList.ComponentCode), x => x.ComponentCode == bomList.ComponentCode)



                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<ProjectBomList> GetProjectWiseBomList(ProjectBomList projectBomList)
        {
            List<ProjectBomList> list;

            try
            {

                list = _wcmsEntities.ProjectBomList
                      .WhereIf(projectBomList.ProjectMasterId != null, x => x.ProjectMasterId == projectBomList.ProjectMasterId)                    
                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblDailyIssuedComponents> CountIssuedComponents()
        {
            List<tblDailyIssuedComponents> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _wcmsEntities.tblDailyIssuedComponents.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<tblLogin> GetRegisterdeEmployee()
        {
            List<tblLogin> list;
            try
            {
                list = _wcmsEntities.tblLogin.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<ReworkList> GetFaultyMobileList()
        {
            List<ReworkList> list;
            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(1).AddTicks(-1);
            try
            {

                list = (from rework in _wcmsEntities.tblRework
                        join line in _wcmsEntities.tblProductionLine on rework.LineId equals line.LineId
                        join asemblyLine in _wcmsEntities.tblAssemblyLineSetup on rework.LineId equals asemblyLine.AssemblyLineId
                        where asemblyLine.AddedDate >= startDate && asemblyLine.AddedDate <= endDate
                        select new ReworkList
                        {

                            ProjectId = (long) rework.ProjectId,
                            ProjectName = asemblyLine.ProjectName ?? "",
                            LineId = line.LineId,
                            LineName = line.LineName ?? "",
                            MobileCode = rework.MobileCode,
                            Issues = rework.Issues,
                            Imei1 = rework.Imei1,
                            Imei2 = rework.Imei2
                           


                        }).AsNoTracking().ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblScrew> GetScrewDoneCount()
        {
            List<tblScrew> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _wcmsEntities.tblScrew.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<ProductionMaster> GetFunctionalQcCount()
        {
            List<ProductionMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _wcmsEntities.ProductionMaster.Where(a => a.FunctionalAD >= startDate && a.FunctionalAD <= endDate && (a.QcStation != null)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<ProductionMaster> GetAestheticQcCount()
        {
            List<ProductionMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _wcmsEntities.ProductionMaster.Where(a => a.AestheticAD >= startDate && a.AestheticAD <= endDate && (a.QcStation == "ASTQC" || a.QcStation == "AGQC" || a.QcStation == "PKGQC" || a.QcStation == "PACKGAESTHQC" || a.QcStation == "PACKGOQC")).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<ProductionMaster> GetAgingCount()
        {
            List<ProductionMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _wcmsEntities.ProductionMaster.Where(a => a.AgingAD >= startDate && a.AgingAD <= endDate && (a.QcStation == "AGQC" || a.QcStation == "PKGQC" || a.QcStation == "PACKGAESTHQC" || a.QcStation == "PACKGOQC")).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<ProductionMaster> GetPackagingCount()
        {
            List<ProductionMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                //list = _wcmsEntities.ProductionMaster.Where(a => a.PackagingAD >= startDate && a.PackagingAD <= endDate && (a.QcStation == "PKGQC" || a.QcStation == "PACKGAESTHQC" || a.QcStation == "PACKGOQC")).ToList();
                list = _wcmsEntities.ProductionMaster.Where(a => a.PackagingAD >= startDate && a.PackagingAD <= endDate).ToList();
            
            
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }


        public List<ProductionMaster> GetPackagingAestheticCount()
        {
            List<ProductionMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _wcmsEntities.ProductionMaster.Where(a => a.PackagingAstheticAD >= startDate && a.PackagingAstheticAD <= endDate).ToList();
                //list = _wcmsEntities.ProductionMaster.Where(a => a.PackagingAstheticAD >= startDate && a.PackagingAstheticAD <= endDate && (a.QcStation == "PACKGAESTHQC" || a.QcStation == "PACKGOQC")).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<ProductionMaster> GetPackagingOqcCount()
        {
            List<ProductionMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _wcmsEntities.ProductionMaster.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate && (a.QcStation == "PACKGOQC")).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<tblDailyIssuedComponents> GetPCBInfo(tblDailyIssuedComponents tblDailyIssuedComponents)
        {
            List<tblDailyIssuedComponents> list;
            try
            {
                list = _wcmsEntities.tblDailyIssuedComponents
                     .WhereIf(tblDailyIssuedComponents.ComponentCode != null, x => x.ComponentCode == tblDailyIssuedComponents.ComponentCode)
                     .WhereIf(tblDailyIssuedComponents.ProjectId != null, x => x.ProjectId == tblDailyIssuedComponents.ProjectId)
                     .AsNoTracking().ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
         
            return list;
        }

        public List<tblScrew> GetScrewStationInfo(tblScrew tblScrew)
        {
            List<tblScrew> list;
            try
            {
                list = _wcmsEntities.tblScrew
                     .WhereIf(tblScrew.MobileCode != null, x => x.MobileCode == tblScrew.MobileCode)
                     .WhereIf(tblScrew.ProjectId != null, x => x.ProjectId == tblScrew.ProjectId)
                     .AsNoTracking().ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }    

        public List<tblPackagingBatch> GetOQCBatchInfo(tblPackagingBatch oQcBatchInfo)
        {
            List<tblPackagingBatch> list;

            try
            {

                list = _wcmsEntities.tblPackagingBatch
                     .WhereIf(oQcBatchInfo.MasterBatch != null, x => x.MasterBatch == oQcBatchInfo.MasterBatch)
                    .WhereIf(oQcBatchInfo.Imei1 != null, x => x.Imei1 == oQcBatchInfo.Imei1)
                    //.WhereIf(oQcBatchInfo.Imei2 != null, x => x.Imei2 == oQcBatchInfo.Imei2)
                    .WhereIf(oQcBatchInfo.AddedBy != null, x => x.AddedBy == oQcBatchInfo.AddedBy)
                    //.WhereIf(oQcBatchInfo.ProjectId != null, x => x.ProjectId == oQcBatchInfo.ProjectId)
                    //.WhereIf(oQcBatchInfo.SystemBatch != null, x => x.SystemBatch == oQcBatchInfo.SystemBatch)



                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblPackagingBatch> GetOQCBatchInfoByImei(string imeiCode)
        {
            List<tblPackagingBatch> list;

            try
            {

                list = _wcmsEntities.tblPackagingBatch.Where(a => a.Imei1 == imeiCode || a.Imei2 == imeiCode).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<ProjectMaster> GetProjectNameListByParam(ProjectMaster projectMaster)
        {
            List<ProjectMaster> list;

            try
            {

                list = _wcmsCellPhoneProjectEntities.ProjectMasters

                    .WhereIf(true, x => x.ProjectMasterId == projectMaster.ProjectMasterId)
                    .WhereIf(projectMaster.ProjectName != null, x => x.ProjectName == projectMaster.ProjectName)                 
                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<AgingBatchInfo> GetAgingBatchData(AgingBatchInfo agingBatchInfo)
        {
            List<AgingBatchInfo> list;

            try
            {

                list = _wcmsEntities.AgingBatchInfo

                    .WhereIf(agingBatchInfo.BatchNo != null, x => x.BatchNo == agingBatchInfo.BatchNo)
                    .WhereIf(agingBatchInfo.Status != null, x => x.Status == agingBatchInfo.Status)

                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblIMEIRecord> GetImeiRecords(string imei)
        {
            List<tblIMEIRecord> list;

            try
            {

                list = _wcmsEntities.tblIMEIRecord.Where(a => a.IMEI1 == imei || a.IMEI2 == imei).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<F_Projects> GetProjecFormvsunDb()
        {
            List<F_Projects> list;
            try
            {
                list = _vsunDbEntities.F_Projects.ToList();
            }
             catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<MasterBoxModel> GetMasterBoxData(string boxCode, string project)
        {
            var list = new List<MasterBoxModel>();
            String connectionString = ConfigurationManager.ConnectionStrings["VsunAdoDBEntities"].ConnectionString;

           

                var sql =
                    string.Format(
                        @"SELECT T_IMEI1,T_IMEI2,T_BOXID FROM F_Project_" + project + " WHERE T_BOXID ='" + boxCode +
                        "'");





                //list = vsunDbEntities.Database.SqlQuery<MasterBoxModel>("SELECT T_IMEI1,T_IMEI2,T_BOXID FROM F_Project_" + project + " WHERE T_BOXID= '"+boxCode +"'").ToList();


                var queryString = "SELECT T_IMEI1,T_IMEI2,T_BOXID FROM [F_Project_" + project + "] WHERE T_BOXID= '"+boxCode + "'";




            using (var connection =
                new SqlConnection(connectionString))
            {

                var command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var box = new MasterBoxModel();

                        var boxId = reader["T_BOXID"];
                        var imei1 = reader["T_IMEI1"];
                        var imei2 = reader["T_IMEI2"];

                        box.T_BOXID = boxId == null ? "" : boxId.ToString();
                        box.T_IMEI1 = imei1 == null ? "" : imei1.ToString();
                        box.T_IMEI2 = imei2 == null ? "" : imei2.ToString();

                        list.Add(box);
                    }
                    reader.Close();
                }
                catch (Exception ex) { throw ex; };
            }



   

            return list;
        }

        public List<tblLogistics> GetLogisticData()
        {
            List<tblLogistics> list;
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);


            try
            {
                list = _wcmsEntities.tblLogistics.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return list;
        }

        public List<tblLogistics> GetLogisticsList(tblLogistics logistics)
        {
            List<tblLogistics> list;

            try
            {

                list = _wcmsEntities.tblLogistics

                    .WhereIf(logistics.BoxCode != null, x => x.BoxCode == logistics.BoxCode)
                    .WhereIf(logistics.Imei1 != null, x => x.Imei1 == logistics.Imei1)
                    .WhereIf(logistics.Imei2 != null, x => x.Imei2 == logistics.Imei2)

                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblLogisticsSentItems> GetLogisticsReleaselist(tblLogisticsSentItems tblLogisticsSentItems)
        {
            List<tblLogisticsSentItems> list;

            try
            {
                if (tblLogisticsSentItems.AddedDate != null)
                {
                    var startDate = DateTime.Today;
                    var endDate = startDate.AddDays(1).AddTicks(-1);
                    list = _wcmsEntities.tblLogisticsSentItems.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
                }

                else
                {
                    list = _wcmsEntities.tblLogisticsSentItems

                   .WhereIf(tblLogisticsSentItems.BoxCode != null, x => x.BoxCode == tblLogisticsSentItems.BoxCode)
                   .WhereIf(tblLogisticsSentItems.Imei1 != null, x => x.Imei1 == tblLogisticsSentItems.Imei1)
                   .WhereIf(tblLogisticsSentItems.Imei2 != null, x => x.Imei2 == tblLogisticsSentItems.Imei2)
                   
               .AsNoTracking().ToList();
                }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblWarehouse> GetWarehouseReceivedlist(tblWarehouse tblWarehouse)
        {
            List<tblWarehouse> list;

            try
            {

                if (tblWarehouse.AddedDate != null)
                {
                    var startDate = DateTime.Today;
                    var endDate = startDate.AddDays(1).AddTicks(-1);
                    list = _wcmsEntities.tblWarehouse.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate).ToList();
                }

                else
                {

                    list = _wcmsEntities.tblWarehouse

                        .WhereIf(tblWarehouse.BoxCode != null, x => x.BoxCode == tblWarehouse.BoxCode)
                        .WhereIf(tblWarehouse.Imei1 != null, x => x.Imei1 == tblWarehouse.Imei1)
                        .WhereIf(tblWarehouse.Imei2 != null, x => x.Imei2 == tblWarehouse.Imei2)

                    .AsNoTracking().ToList(); 
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<ReworkList> GetFaultyMobileHistory(string mobileCode)
        {
            List<ReworkList> list;
          
            try
            {


                //var projectname = _wcmsCellPhoneProjectEntities.ProjectMasters.AsEnumerable();

                var projectname = _wcmsCellPhoneProjectEntities.ProjectMasters.ToList();
                                        




                var list1 = (from rework in _wcmsEntities.tblRework
                        join line in _wcmsEntities.tblProductionLine on rework.LineId equals line.LineId
                       
                        join user in _wcmsEntities.tblLogin on rework.AddedBy equals user.Id
                        where rework.MobileCode==mobileCode
                        select new ReworkList
                        {

                            ProjectId = (long)rework.ProjectId,
                            //ProjectName = project.ProjectName ?? "",
                            LineId = line.LineId,
                            LineName = line.LineName ?? "",
                            MobileCode = rework.MobileCode??"",
                            FailedStation=rework.FailedStation??"",
                            Issues = rework.Issues??"",
                            Imei1 = rework.Imei1??"",
                            Imei2 = rework.Imei2??"",
                            Status = rework.Status??"",
                            AddedBy = user.EmployeeId,
                            AddedDate = rework.AddedDate == null ? "" : rework.AddedDate.ToString() 



                        }).AsNoTracking().ToList();


                list=(from fullList in list1 join proj in projectname on fullList.ProjectId equals proj.ProjectMasterId

                      select new ReworkList 
                {
                            ProjectId = (long)fullList.ProjectId,
                            ProjectName = proj.ProjectName ?? "",
                            LineId = fullList.LineId,
                            LineName = fullList.LineName ?? "",
                            MobileCode = fullList.MobileCode??"",
                            FailedStation=fullList.FailedStation??"",
                            Issues = fullList.Issues??"",
                            Imei1 = fullList.Imei1??"",
                            Imei2 = fullList.Imei2??"",
                            Status = fullList.Status??"",
                            AddedBy = fullList.AddedBy,
                            AddedDate = (fullList.AddedDate)
                }).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblColors> tblColors()
        {
            var list = new List<tblColors>();
            try
            {
                list = _wcmsEntities.tblColors.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblRework> GetCompletedRepairCount()
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            List<tblRework> list;
            try
            {
                list = _wcmsEntities.tblRework.Where(a => a.FinishedDate >= startDate && a.FinishedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public Issues GetIssueCriteria(Issues issues)
        {
            var issueCiteria = new Issues();

            try
            {

                issueCiteria = _wcmsEntities.Issues

                    .WhereIf(issues.Name != null, x => x.Name.Contains(issues.Name))
                    //.WhereIf(logistics.Imei1 != null, x => x.Imei1 == logistics.Imei1)
                    //.WhereIf(logistics.Imei2 != null, x => x.Imei2 == logistics.Imei2)

                .AsNoTracking().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return issueCiteria;
        }

        public List<tblAgingMaster> AgingMasterInfo(tblAgingMaster tblAgingMaster)
        {
            List<tblAgingMaster> list;

            try
            {

                list = _wcmsEntities.tblAgingMaster

                    .WhereIf(tblAgingMaster.MobileCode != null, x => x.MobileCode == tblAgingMaster.MobileCode)
                    //.WhereIf(tblAgingMaster.Passed != null, x => x.Passed == tblAgingMaster.Passed)
                    .WhereIf(tblAgingMaster.AgingBatch != null, x => x.AgingBatch == tblAgingMaster.AgingBatch)

                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblChargerMaster> ChargingMasterInfo(tblChargerMaster tblChargerMaster)
        {
            List<tblChargerMaster> list;

            try
            {

                list = _wcmsEntities.tblChargerMaster

                    .WhereIf(tblChargerMaster.MobileCode != null, x => x.MobileCode == tblChargerMaster.MobileCode)
                    //.WhereIf(tblAgingMaster.Passed != null, x => x.Passed == tblAgingMaster.Passed)
                    .WhereIf(tblChargerMaster.ChargingBatch != null, x => x.ChargingBatch == tblChargerMaster.ChargingBatch)

                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<AgingBatch> AgingBatcInfo(AgingBatch agingBatch)
        {
            List<AgingBatch> list;

            try
            {

                list = _wcmsEntities.AgingBatch

                    .WhereIf(agingBatch.Passed != null, x => x.Passed == agingBatch.Passed)
                    .WhereIf(agingBatch.BatchNumber != null, x => x.BatchNumber == agingBatch.BatchNumber)

                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }


        public List<LogisticModel> GetLogisticReceivedList()
        {
            List<LogisticModel> list;
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            try
            {

                list = (from tblImeiRecord in _wcmsEntities.tblIMEIRecord
                        join logistics in _wcmsEntities.tblLogistics on tblImeiRecord.IMEI1 equals logistics.Imei1

                        where logistics.AddedDate >= startDate && logistics.AddedDate <= endDate
                        select new LogisticModel
                        {


                            Model = tblImeiRecord.Model,
                            Imei1 = tblImeiRecord.IMEI1,
                            Imei2 = tblImeiRecord.IMEI1

                        }).AsNoTracking().ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }




    }
}
