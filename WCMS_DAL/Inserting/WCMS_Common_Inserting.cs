using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCMS_COMMON;
using WCMS_DAL.Interfaces;
using System.Transactions;
using WCMS_ENTITY;
using System.Diagnostics;
using WCMS_ENTITY.CustomModelEntity;

namespace WCMS_DAL.Inserting
{
    public class WCMS_Common_Inserting : IInsertingSetupCommon
    {
        private readonly WCMSEntities _entity = new WCMSEntities();

        //[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        //  [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertEmployeeInfo(EmployeeInfo employee)
        {
            try
            {
                _entity.EmployeeInfo.Add(employee);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        public bool InsertProjectBomList(ProjectBomList oProjectBomList)
        {
            try
            {
                _entity.ProjectBomList.Add(oProjectBomList);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertLoginInfo(tblLogin login)
        {
            try
            {
                _entity.tblLogin.Add(login);
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
        public bool UpdateLoginUser(tblLogin login, string newPassword)
        {
            _entity.Configuration.LazyLoadingEnabled = false;
            tblLogin loginList = _entity.tblLogin.FirstOrDefault(x => x.Id == login.Id && x.Password == login.Password);
            //FirstOrDefault(x => x.Id == login.Id && x.Password == login.Password);


            if (loginList != null)
            {
                if (login.Password != "")
                    loginList.Password = newPassword;


                _entity.Entry(loginList).State = EntityState.Modified;
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
        public bool CreateDailyPackagingList(tblDailyPacking oDailyPacking)
        {
            try
            {
                _entity.tblDailyPacking.Add(oDailyPacking);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertComponentRequisition(tblComponentRequisition componentRequisition)
        {
            try
            {
                _entity.tblComponentRequisition.Add(componentRequisition);
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
        public bool UpdateComponentRequisitionList(tblAssemblyLineSetupDetails tblAssemblyLineSetupDetails)
        {

            _entity.Configuration.LazyLoadingEnabled = false;
            tblComponentRequisition componentRequisition =
                _entity.tblComponentRequisition.FirstOrDefault(
                    x => x.ComponentId == tblAssemblyLineSetupDetails.ComponentId);

            if (componentRequisition != null)
            {


                if (tblAssemblyLineSetupDetails != null)
                    componentRequisition.UsedQuantity = componentRequisition.UsedQuantity +
                                                        tblAssemblyLineSetupDetails.SubmitQuantity;

                _entity.Entry(componentRequisition).State = EntityState.Modified;
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
        public bool InsertBomList(BomList bomLists)
        {
            try
            {
                _entity.BomList.Add(bomLists);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertIssuedComponents(tblDailyIssuedComponents issuedComponents)
        {
            try
            {
                _entity.tblDailyIssuedComponents.Add(issuedComponents);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertScrewStationInfo(tblScrew screw)
        {
            try
            {
                _entity.tblScrew.Add(screw);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertLogisticsSendData(List<tblLogisticsSentItems> logisticsSendList)
        {
            try
            {

                foreach (var tblLogisticsSentItemse in logisticsSendList)
                {
                    //var logisticsSendItems = new tblLogisticsSentItems();

                    var logisticsSendItems = new tblLogisticsSentItems
                    {
                        BoxCode = tblLogisticsSentItemse.BoxCode,
                        Imei1 = tblLogisticsSentItemse.Imei1,
                        Imei2 = tblLogisticsSentItemse.Imei2,
                        Color = tblLogisticsSentItemse.Color,
                        Model = tblLogisticsSentItemse.Model,
                        AddedBy = tblLogisticsSentItemse.AddedBy,
                        AddedDate = tblLogisticsSentItemse.AddedDate
                    };
                    _entity.tblLogisticsSentItems.Add(logisticsSendItems);
                    _entity.SaveChanges();
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool InsertWareHouseData(List<tblWarehouse> wareHouseData)
        {
            try
            {

                foreach (var warehouse in wareHouseData)
                {
                    //var logisticsSendItems = new tblLogisticsSentItems();

                    var entity = new tblWarehouse
                    {
                        BoxCode = warehouse.BoxCode,
                        Imei1 = warehouse.Imei1,
                        Imei2 = warehouse.Imei2,
                        Color = warehouse.Color,
                        Model = warehouse.Model,
                        AddedBy = warehouse.AddedBy,
                        AddedDate = warehouse.AddedDate
                    };
                    _entity.tblWarehouse.Add(entity);
                    _entity.SaveChanges();
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public Result InsertModelsImeiData(List<ImeiModelUpload> imeiModelUpload)
        {

            try
            {
                var consString = ConfigurationManager.ConnectionStrings["adoWcms"].ConnectionString;
                

                var result = new Result();

                
                var dto = new DataTable();

                dto.Columns.AddRange(new DataColumn[13]
            {
                new DataColumn("RecID", typeof (Guid)),
                new DataColumn("PrintDate", typeof (DateTime)),
                new DataColumn("ProductType", typeof (string)),
                new DataColumn("Model", typeof (string)),
                new DataColumn("Color", typeof (string)),
                new DataColumn("BarCode", typeof (string)),
                new DataColumn("BarCode2", typeof (string)),
                new DataColumn("DelieveredTo", typeof (string)),
                new DataColumn("AddedBy", typeof (string)),
                new DataColumn("PrintSuccess", typeof (bool)),
                new DataColumn("DateAdded", typeof (DateTime)),
                new DataColumn("Updatedby", typeof (string)),
                new DataColumn("DateUpdated", typeof (string))
            });



                foreach (var itm in imeiModelUpload)
                {
                    var con = new SqlConnection(consString);
                    
                    con.Open();
                    using (
                        var sqlCommand = new SqlCommand("SELECT COUNT(*) from [tblBarCodeInv] where [BarCode]= @im1",
                            con))
                    {
                       // sqlCommand.CommandTimeout= 720;
                        
                        sqlCommand.Parameters.AddWithValue("@im1", itm.Barcode);

                        var userCount = (int) sqlCommand.ExecuteScalar();


                        if (userCount == 0)
                        {

                            var row = dto.NewRow();
                            row["RecID"] = Guid.NewGuid();
                            row["PrintDate"] = itm.PrintDate;
                            row["ProductType"] = "Cell Phone";
                            row["Model"] = itm.Model;
                            row["Color"] = itm.Color;
                            row["BarCode"] = itm.Barcode;
                            row["BarCode2"] = itm.Barcode2;
                            row["DelieveredTo"] = itm.DeliveredTo;
                            row["AddedBy"] = "raihan";
                            row["PrintSuccess"] = true;
                            row["DateAdded"] = DateTime.Now;
                            row["Updatedby"] = itm.UpdatedBy;
                            row["DateUpdated"] = DateTime.Now.ToString("yyyyMMdd");

                            dto.Rows.Add(row);

                        }
                        sqlCommand.Dispose();
                    }

                    con.Close();
                    con.Dispose();
                    
                }
                //con.Close();
               // con.Dispose();
                var con1 = new SqlConnection(consString);
                con1.Open();
                using (var sqlTransaction = con1.BeginTransaction())
                {
                    using (
                        var sqlBulkCopy = new SqlBulkCopy(con1, SqlBulkCopyOptions.Default,
                            sqlTransaction))
                    {
                        //Set the database table name  tblShadowIMEIRecord
                        sqlBulkCopy.DestinationTableName = "dbo.tblBarCodeInv"; //"dbo.tblIMEIRecord";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("RecID", "RecID");
                        sqlBulkCopy.ColumnMappings.Add("PrintDate", "PrintDate");
                        sqlBulkCopy.ColumnMappings.Add("ProductType", "ProductType");
                        sqlBulkCopy.ColumnMappings.Add("Model", "Model");
                        sqlBulkCopy.ColumnMappings.Add("Color", "Color");
                        sqlBulkCopy.ColumnMappings.Add("BarCode", "BarCode");
                        sqlBulkCopy.ColumnMappings.Add("BarCode2", "BarCode2");
                        sqlBulkCopy.ColumnMappings.Add("DelieveredTo", "DelieveredTo");
                        sqlBulkCopy.ColumnMappings.Add("AddedBy", "AddedBy");
                        sqlBulkCopy.ColumnMappings.Add("PrintSuccess", "PrintSuccess");
                        sqlBulkCopy.ColumnMappings.Add("DateAdded", "DateAdded");
                        sqlBulkCopy.ColumnMappings.Add("Updatedby", "Updatedby");
                        sqlBulkCopy.ColumnMappings.Add("DateUpdated", "DateUpdated");
                        try
                        {
                            sqlBulkCopy.WriteToServer(dto);
                            sqlTransaction.Commit();


                            con1.Close();
                            result.Message = "Data Uploaded Susccessfully";
                            result.IsSuccess = true;
                            return result;
                            //var message = rowCount + " Data has been Imported successfully." + "\n" + duplicateRow + " Duplicate Rows Found" + "\n";  //+ "Duplicates Values Are =" + duplicate + "

                        }
                        catch (Exception exception)
                        {
                            sqlTransaction.Rollback();
                            result.Message = exception.Message;
                            return result;
                        }
                    }
                }

            }
            catch (Exception)
            {
                
                throw;
            }


           
}


        


    }
}
