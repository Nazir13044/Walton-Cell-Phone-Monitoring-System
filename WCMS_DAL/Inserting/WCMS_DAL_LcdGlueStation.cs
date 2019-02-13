using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using UpdateEmployeesInKPIProject;
using WCMS_DAL.HelperClass;
using WCMS_DAL.Interfaces;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;

namespace WCMS_DAL.Inserting
{
    public class WCMS_DAL_LcdGlueStation : ILcdGlueStation
    {
        private readonly WCMSEntities _entity = new WCMSEntities();

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertLcdGlueWorkingModels(tblLcdGlueWorkingModels workingModel)
        {
            try
            {
                _entity.tblLcdGlueWorkingModels.Add(workingModel);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool UpdateGlueWorkingModels(tblLcdGlueWorkingModels workingModel)
        {
            try
            {
                _entity.Configuration.LazyLoadingEnabled = false;
                var startDate = DateTime.Today;
                var endDate = startDate.AddDays(1).AddTicks(-1);



                //if( workingModel.Id!=null)





                var wModel = _entity.tblLcdGlueWorkingModels.Where(x => x.AddedBy == workingModel.AddedBy && (x.AddedDate >= startDate && x.AddedDate <= endDate)).ToList();

                if (wModel.Count > 0)
                {
                    foreach (var items in wModel)
                    {


                        var workModels = _entity.tblLcdGlueWorkingModels.FirstOrDefault(x => x.AddedBy == items.AddedBy && (x.AddedDate >= startDate && x.AddedDate <= endDate) && x.ProjectName == items.ProjectName && x.ProjectId == items.ProjectId);


                        if (workModels == null) continue;
                        workModels.CurentlyRunning = workModels.Id == workingModel.Id ? "Y" : "N";

                        _entity.Entry(workModels).State = EntityState.Modified;
                        _entity.SaveChanges();
                    }
                    return true;
                }







                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<tblLcdGlueWorkingModels> LoadWorkingModelData()
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            List<tblLcdGlueWorkingModels> list;
            try
            {
                list = _entity.tblLcdGlueWorkingModels.Where(x => x.AddedDate >= startDate && x.AddedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public tblTpLcdMaster GetTpLcdStationInfo(tblTpLcdMaster tblTpLcdMaster)
        {
            tblTpLcdMaster master;

            try
            {

                master =
                    _entity.tblTpLcdMaster.WhereIf(tblTpLcdMaster.Code != null,
                        x => x.Code == tblTpLcdMaster.Code)
                        .WhereIf(tblTpLcdMaster.Passed != null, x => x.Passed == tblTpLcdMaster.Passed)
                        .WhereIf(tblTpLcdMaster.AddedBy != null, x => x.AddedBy == tblTpLcdMaster.AddedBy)
                        .FirstOrDefault();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return master;
        }

        public bool InsertTpLcdStation(tblTpLcdMaster tblTpLcdMaster)
        {
            try
            {
                _entity.tblTpLcdMaster.Add(tblTpLcdMaster);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertTpLcdReworkStation(tblLcdGlueRework rework)
        {
            try
            {
                _entity.tblLcdGlueRework.Add(rework);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool UpdateTpLcdStation(tblTpLcdMaster tblTpLcdMaster)
        {
            try
            {
                var masterData = _entity.tblTpLcdMaster.FirstOrDefault(x => x.Code == tblTpLcdMaster.Code);


                if (masterData != null)
                {

                    if (!string.IsNullOrEmpty(tblTpLcdMaster.Code))
                        masterData.Passed = tblTpLcdMaster.Passed;
                    if (tblTpLcdMaster.UpdatedBy != null)
                        masterData.UpdatedBy = tblTpLcdMaster.UpdatedBy;
                    if (tblTpLcdMaster.UpdatedDate != null)
                        masterData.UpdatedDate = tblTpLcdMaster.UpdatedDate;


                     
                    _entity.Entry(masterData).State = EntityState.Modified;
                    _entity.SaveChanges();
                }

              
            }
            catch (Exception)
            {
                
                throw;
            }
            return true;
        }

        public List<tblTpLcdMaster> CountTpLcdStationinput()
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            List<tblTpLcdMaster> list;
            try
            {
                list = _entity.tblTpLcdMaster.Where(x => x.AddedDate >= startDate && x.AddedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblLcdGlueRework> GetTpLcdIssuesCount(tblLcdGlueRework rework)
        {
            var list = new List<tblLcdGlueRework>();

            try
            {

                list = _entity.tblLcdGlueRework.WhereIf(rework.Code != null, x => x.Code == rework.Code)
                     .WhereIf(rework.Status != null, x => x.Status == rework.Status)
                     .WhereIf(rework.AddedBy != null, x => x.AddedBy == rework.AddedBy)
                      .WhereIf(rework.ProjectId != null, x => x.ProjectId == rework.ProjectId)
                    .ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblLcdGlueIssuesList> GetAllIssueList()
        {

            List<tblLcdGlueIssuesList> list;
            try
            {
                list = _entity.tblLcdGlueIssuesList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public tblGlueMaster GetGlueStationInfo(tblGlueMaster tblGlueMaster)
        {
            tblGlueMaster master;

            try
            {

                master =
                    _entity.tblGlueMaster.WhereIf(tblGlueMaster.Code != null,
                        x => x.Code == tblGlueMaster.Code)
                        .WhereIf(tblGlueMaster.Passed != null, x => x.Passed == tblGlueMaster.Passed)
                        .WhereIf(tblGlueMaster.AddedBy != null, x => x.AddedBy == tblGlueMaster.AddedBy)
                        .FirstOrDefault();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return master;
        }

        public bool InsertGlueStation(tblGlueMaster tblGlueMaster)
        {
            try
            {
                _entity.tblGlueMaster.Add(tblGlueMaster);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool UpdateGlueStation(tblGlueMaster tblglueMaster)
        {
            try
            {
                var masterData = _entity.tblGlueMaster.FirstOrDefault(x => x.Code == tblglueMaster.Code);


                if (masterData != null)
                {

                    if (!string.IsNullOrEmpty(tblglueMaster.Code))
                        masterData.Passed = tblglueMaster.Passed;
                    if (tblglueMaster.UpdatedBy != null)
                        masterData.UpdatedBy = tblglueMaster.UpdatedBy;
                    if (tblglueMaster.UpdatedDate != null)
                        masterData.UpdatedDate = tblglueMaster.UpdatedDate;



                    _entity.Entry(masterData).State = EntityState.Modified;
                    _entity.SaveChanges();
                }


            }
            catch (Exception exception)
            {

                throw exception;
            }
            return true;
        }

        public List<tblGlueMaster> CountGlueStationinput()
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1).AddTicks(-1);
            List<tblGlueMaster> list;
            try
            {
                list = _entity.tblGlueMaster.Where(x => x.AddedDate >= startDate && x.AddedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<ProjectBomMode> CallOracleTest(string model, string color)
        {
            var list = new List<ProjectBomMode>();
            var newList = new List<ProjectBomMode>();

            try
            {
              

                var employeeQuery = @"SELECT
     substr(iasy.segment1,1,20) Assembly,( iasy.SEGMENT1||'.'||iasy.SEGMENT2||'.'||iasy.SEGMENT3)  ITEM_CODE,iasy.DESCRIPTION,
                 substr(icmp.segment1,1,20) Component,
                 substr(comp.component_quantity,1,8) Quantity,
                  ( icmp.SEGMENT1||'.'||icmp.SEGMENT2||'.'||icmp.SEGMENT3)  SPARE_ITEM_CODE,icmp.DESCRIPTION SPARE_DESCRIPTION
FROM
                 apps.mtl_system_items_B iasy,
                 apps.bom_bill_of_materials bom,
                 apps.bom_inventory_components comp,
                 apps.mtl_system_items_B icmp
WHERE
           
                 iasy.organization_id = 646 AND
                 iasy.inventory_item_id = bom.assembly_item_id AND
                 iasy.organization_id = bom.organization_id AND
                 bom.bill_sequence_id = comp.bill_sequence_id AND
                 comp.component_item_id = icmp.inventory_item_id AND
                 icmp.organization_id = 646 AND
                
                 LOWER(icmp.DESCRIPTION) LIKE '%" + model + "%'";
                var connection = OracleDatabaseConnection.GetOldConnection();
                OracleDataReader oracleDataReader = null;
                var oracleCommand = new OracleCommand(employeeQuery, connection) { CommandType = CommandType.Text };

                connection.Open();
                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {

                    while (oracleDataReader.Read())
                    {

                        var projectBom = new ProjectBomMode
                        {
                            ITEM_CODE = oracleDataReader["ITEM_CODE"].ToString(),
                            DESCRIPTION = oracleDataReader["DESCRIPTION"].ToString(),
                            Quantity = oracleDataReader["Quantity"].ToString(),
                            SPARE_ITEM_CODE = oracleDataReader["SPARE_ITEM_CODE"].ToString(),
                            SPARE_DESCRIPTION = oracleDataReader["SPARE_DESCRIPTION"].ToString()
                        };
                        list.Add(projectBom);

                    }
                }


                newList = list.Where(a => a.DESCRIPTION.Contains(color)).ToList();

                oracleDataReader.Dispose();
                connection.Close();
                //connection.Dispose();
            }
            catch (Exception)
            {
                
                throw;
            }


           


            return newList;
        }
    }
}
