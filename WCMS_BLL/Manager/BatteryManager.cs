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
   public class BatteryManager
    {

        IProduction _iProductionInsert = new WCMS_DAL_Production();
        readonly ISelectingCommon _isSelectingCommon = new DALGetCommonSelecting();
        readonly IInsertingSetupCommon _insertingSetupCommon = new WCMS_Common_Inserting();
        readonly IBattery _iBattery = new WCMS_DAL_BatteryStation();


        public Result InsertBatteryComponentInfo(tblBatteryComponentInfo batteryComponent)
        {
            try
            {

               
                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _iBattery.InsertBatteryComponentInfo(batteryComponent);

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


        public List<tblBatteryComponentInfo> ProjectNameExist(tblBatteryComponentInfo tblLineSetup)
        {
            try
            {
                IBattery iAdmin = new WCMS_DAL_BatteryStation();
                return iAdmin.ProjectNameExist(tblLineSetup);
            }
            catch (Exception ex) 
            { throw ex; }
        }

        public List<tblBatteryComponentInfo> GetListByPcbIssue()
        {
            try
            {
                IBattery iBattery = new WCMS_DAL_BatteryStation();
                return iBattery.GetListByPcbIssue();
            }
            catch (Exception ex) { throw ex; }
        }


        public List<tblBatteryComponentInfo> GetLineListById(int id)
        {
            try
            {
                IBattery iBattery = new WCMS_DAL_BatteryStation();
                return iBattery.GetLineListById(id);
            }
            catch (Exception ex) { throw ex; }
        }





        public Result UpdateBatteryLine(tblBatteryComponentInfo productionLine)
        {
            try
            {
                IBattery iBattery = new WCMS_DAL_BatteryStation();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iBattery.UpdateBatteryLine(productionLine);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public Result DeleteProductionLine(int id)
        {
            try
            {
                IBattery iBattery = new WCMS_DAL_BatteryStation();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iBattery.DeleteProductionLine(id);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }



        //public Result InsertProductionLine(tblBatteryComponentInfo productionLine)
        //{
        //    try
        //    {
        //        IBattery iBattery = new WCMS_DAL_BatteryStation();
        //        using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
        //        {
        //            Result _Result = new Result();
        //            _Result.IsSuccess = iBattery.InsertProductionLine(productionLine);

        //            if (_Result.IsSuccess)
        //                transaction.Complete();
        //            return _Result;
        //        }
        //    }
        //    catch (Exception ex) { throw ex; }
        //}


        }



      

  
}

