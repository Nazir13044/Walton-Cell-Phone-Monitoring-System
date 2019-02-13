using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WCMS_BLL.Manager;
using WCMS_COMMON;
using WCMS_ENTITY;
using BR_BLL;
using WCMS_COMMON;
using WCMS_ENTITY;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;

namespace WcfService2.Services
{
    /// <summary>
    /// Summary description for ProductionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductionService : System.Web.Services.WebService
    {
        private ProductionManager productionManager = new ProductionManager();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }



        [WebMethod]

        public Result InsertFunctionalQcStatus(ProductionMaster productionMaster)
        {
            try
            {
                return productionManager.InsertFunctionalQcStatus(productionMaster);
            }
            catch (Exception ex)
            {
                return new Result {IsSuccess = false, Message = ex.Message};
            }
        }


        [WebMethod]
        public List<tblRework> GetQcStatusHistory(tblRework _Entity)
        {
            List<tblRework> reworksHisReworks = new List<tblRework>();
            try
            {
                reworksHisReworks = productionManager.GetQcStatusHistory(_Entity);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Communication : " + ex.Message);
                //}
            }

            return reworksHisReworks;
        }




        [WebMethod]
        public Result UpdateQcStatusHistory(List<ProductionMaster> productionList)
        {

            try
            {
                return productionManager.UpdateQcStatusHistory(productionList);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result {IsSuccess = false, Message = ex.Message};
            }


        }


        [WebMethod]
        public Result InsertFunctionalRework(tblRework rework)
        {
            try
            {
                return productionManager.InsertFunctionalRework(rework);
            }
            catch (Exception ex)
            {
                return new Result {IsSuccess = false, Message = ex.Message};
            }
        }

        [WebMethod]

        public List<tblRework> GetIssueResult(tblRework rework)
        {
            List<tblRework> reworks = new List<tblRework>();
            try
            {
                reworks = productionManager.GetIssueResult(rework);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Communication : " + ex.Message);
                //}
            }

            return reworks;
        }

        public Result UpdateRework(List<tblRework> rework)
        {
            try
            {
                return productionManager.UpdateRework(rework);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result {IsSuccess = false, Message = ex.Message};
            }

        }

        public Result UpdateReworkTask(tblRework reworks)
        {
            try
            {
                return productionManager.UpdateReworkTask(reworks);
            }
            catch (Exception ex)
            {

                return new Result {IsSuccess = false, Message = ex.Message};
            }
        }

        [WebMethod]
        public Result InsertBomList(BomList bomList)
        {
            try
            {
                return productionManager.InsertBomList(bomList);
            }
            catch (Exception ex)
            {
                return new Result {IsSuccess = false, Message = ex.Message};
            }
        }









        public Result InsertSolderingInfo(tblSolderingOthers oSolderList)
        {
            try
            {
                return productionManager.InsertSolderingInfo(oSolderList);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertDeletedOQcBatchInfo(tblDeletdPackagingBatchData oQcBatchInfo)
        {
            try
            {
                return productionManager.InsertDeletedOQcBatchInfo(oQcBatchInfo);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }


        //public List<tblRework> GetAssemblineInfo(tblRework tblRework)
        //{
        //    var reworkList = new List<tblAssemblyLineSetup>();

        //    try
        //    {
        //        reworkList = _CommonManager.GetAssemblineInfo(tblAssemblyLineSetup);
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return reworkList;
        //}



        [WebMethod]
        public List<tblRework> IssueHistoryByImei(string imei)
        {
            var reworksHisReworks = new List<tblRework>();
            try
            {
                reworksHisReworks = productionManager.IssueHistoryByImei(imei);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Communication : " + ex.Message);
                //}
            }

            return reworksHisReworks;
        }


        public List<tblRework> GetReworkDetailsByImei(string imei)
        {
            var reworksHisReworks = new List<tblRework>();
            try
            {
                reworksHisReworks = productionManager.GetReworkDetailsByImei(imei);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Communication : " + ex.Message);
                //}
            }

            return reworksHisReworks;
        }



        public Result InsertAgingcBatchInfo(AgingBatchInfo agingBatchInfo)
        {
            try
            {
                return productionManager.InsertAgingcBatchInfo(agingBatchInfo);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }
         [WebMethod]
        public Result UpdateProductionBatchStatus(List<ProductionMaster> producList)
        {
            try
            {
                return productionManager.UpdateProductionBatchStatus(producList);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }

        }



         public Result InsertAgingBatchQcInfo(List<ProductionMaster> productionAgingQc, string batchStatus, long userId, long lineId, long projectId)
         {
             try
             {
                 return productionManager.InsertAgingBatchQcInfo(productionAgingQc, batchStatus, userId, lineId, projectId);
             }
             catch (Exception ex)
             {
                 //if (log.IsErrorEnabled)
                 //    log.Error("Insert Sales Order : " + ex.Message);
                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }
        [WebMethod]
         public Result UpdateOQCBatchInfo(List<tblPackagingBatch> batchInfoList)
         {
             try
             {
                 return productionManager.UpdateOQCBatchInfo(batchInfoList);
             }
             catch (Exception ex)
             {
                 //if (log.IsErrorEnabled)
                 //    log.Error("Insert Sales Order : " + ex.Message);
                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }

        public Result GenerateImeiBatch(long userId, long projectId, string imeiCode)
        {
            try
            {
                return productionManager.GenerateImeiBatch( userId,  projectId, imeiCode);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<tblPackagingBatch> CountPackagingBatch(long projectId, long userId)
        {
            List<tblPackagingBatch> list;
            try
            {


                list = productionManager.CountPackagingBatch( projectId,userId);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
              
            }

            return list;
        }

       

        public Result DeleteOQCBatchInfoData(System.Collections.Generic.List<WCMS_ENTITY.tblPackagingBatch> oQcBatchInfoList)
        {
            try
            {
                return productionManager.DeleteOQCBatchInfoData(oQcBatchInfoList);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertOqcBatch(List<tblPackagingBatch> oQcBatchInfo)
        {
            try
            {
                return productionManager.InsertOqcBatch(oQcBatchInfo);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertLogisticsData(tblLogistics logisticsList)
        {
            try
            {
                return productionManager.InsertLogisticsData(logisticsList);
            }
            catch (Exception ex)
            {
                
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }



        public Result UpdateLogisticsData(List<WCMS_ENTITY.CustomModelEntity.ImeiModelUpload> imeiModelUpload)
        {
            try
            {
                return productionManager.UpdateLogisticsData(imeiModelUpload);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertRepairStatus(List<tblRepairStatus> repairStatus)
        {
            try
            {
                return productionManager.InsertRepairStatus(repairStatus);
            }
            catch (Exception ex)
            {
                
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertRepairComponents(List<tblRepairComponents> repairComponents)
        {
            try
            {
                return productionManager.InsertRepairComponents(repairComponents);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertAgingQcStationinfo(List<tblAgingMaster> agingBatchList)
        {
            try
            {
                return productionManager.InsertAgingQcStationinfo(agingBatchList);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result UpdateAgingQcStationinfo(List<tblAgingMaster> agingCheckedList)
        {
            try
            {
                return productionManager.UpdateAgingQcStationinfo(agingCheckedList);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result UpdateBatchInfo(AgingBatchInfo batchInfo)
        {
            try
            {
                return productionManager.UpdateBatchInfo(batchInfo);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertOqcCheckedItems(tblOqcCheckedItems checkedItems)
        {
            try
            {
                return productionManager.InsertOqcCheckedItems(checkedItems);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }



        public Result InsertAgingBatchStatus(AgingBatch batchesult)
        {
            try
            {
                return productionManager.InsertAgingBatchStatus(batchesult);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertChargingQcStationinfo(List<tblChargerMaster> chargingCheckedList)
        {
            try
            {
                return productionManager.InsertChargingQcStationinfo(chargingCheckedList);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result UpdateLogisticsDataForOracleUpload(List<ImeiModelUpload> list, string oracletranscationCode)
        {
            try
            {
                return productionManager.UpdateLogisticsDataForOracleUpload(list, oracletranscationCode);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //    log.Error("Insert Sales Order : " + ex.Message);
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
