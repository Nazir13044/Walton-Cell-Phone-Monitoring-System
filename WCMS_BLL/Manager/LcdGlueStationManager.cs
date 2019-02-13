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
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;

namespace WCMS_BLL.Manager
{
   public class LcdGlueStationManager
    {
       readonly ILcdGlueStation _iLcdGlueStation = new WCMS_DAL_LcdGlueStation();
        public Result InsertLcdGlueWorkingModels(tblLcdGlueWorkingModels workingModel)
        {
            try
            {

                
                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result {IsSuccess = _iLcdGlueStation.InsertLcdGlueWorkingModels(workingModel)};

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

        public Result UpdateGlueWorkingModels(tblLcdGlueWorkingModels workingModel)
        {
           
            var result = new Result();
            try
            {
                result.IsSuccess = _iLcdGlueStation.UpdateGlueWorkingModels(workingModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<tblLcdGlueWorkingModels> LoadWorkingModelData()
        {
            try
            {

                return _iLcdGlueStation.LoadWorkingModelData();
            }
            catch (Exception ex) { throw ex; }
        }

        public tblTpLcdMaster GetTpLcdStationInfo(tblTpLcdMaster tblTpLcdMaster)
        {
            try
            {

                return _iLcdGlueStation.GetTpLcdStationInfo(tblTpLcdMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertTpLcdStation(tblTpLcdMaster tblTpLcdMaster)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result { IsSuccess = _iLcdGlueStation.InsertTpLcdStation(tblTpLcdMaster) };

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

        public Result InsertTpLcdReworkStation(tblLcdGlueRework rework)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result { IsSuccess = _iLcdGlueStation.InsertTpLcdReworkStation(rework) };

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

        public Result UpdateTpLcdStation(tblTpLcdMaster tblTpLcdMaster)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result { IsSuccess = _iLcdGlueStation.UpdateTpLcdStation(tblTpLcdMaster) };

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

        public List<tblTpLcdMaster> CountTpLcdStationinput()
        {
            try
            {

                return _iLcdGlueStation.CountTpLcdStationinput();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblLcdGlueRework> GetTpLcdIssuesCount(tblLcdGlueRework rework)
        {
            
            try
            {
                return _iLcdGlueStation.GetTpLcdIssuesCount(rework);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tblLcdGlueIssuesList> GetAllIssueList()
        {
            try
            {

                return _iLcdGlueStation.GetAllIssueList();
            }
            catch (Exception ex) { throw ex; }
        }

        public tblGlueMaster GetGlueStationInfo(tblGlueMaster tblGlueMaster)
        {
            try
            {

                return _iLcdGlueStation.GetGlueStationInfo(tblGlueMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertGlueStation(tblGlueMaster tblGlueMaster)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result { IsSuccess = _iLcdGlueStation.InsertGlueStation(tblGlueMaster) };

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

        public Result UpdateGlueStation(tblGlueMaster tblglueMaster)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result { IsSuccess = _iLcdGlueStation.UpdateGlueStation(tblglueMaster) };

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

        public List<tblGlueMaster> CountGlueStationinput()
        {
            try
            {

                return _iLcdGlueStation.CountGlueStationinput();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<ProjectBomMode> CallOracleTest(string model, string color)
        {
            try
            {

                return _iLcdGlueStation.CallOracleTest(model,color);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
