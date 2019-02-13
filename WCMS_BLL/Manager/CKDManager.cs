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

namespace WCMS_BLL.Manager
{
    public class CKDManager
    {
        IProduction _iProductionInsert = new WCMS_DAL_Production();
        readonly ISelectingCommon _isSelectingCommon = new DALGetCommonSelecting();
        readonly IInsertingSetupCommon _insertingSetupCommon = new WCMS_Common_Inserting();
       
        readonly ICKD _ickd = new WCMS_DAL_CKD();

        public Result InsertCkdMmiComponentInfo(tblCkdMmiMaster mmItabltestComponent)
        {
      
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.InsertCkdMmiComponentInfo(mmItabltestComponent);

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



        public List<tblCkdMmiMaster> GetCkdMmiMasterInfo(tblCkdMmiMaster tblCkdMmiMaster)
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetCkdMmiMasterInfo(tblCkdMmiMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result UpdateCkdMmiInfo(tblCkdMmiMaster mmItabltestComponent)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.UpdateCkdMmiInfo(mmItabltestComponent);

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

        public Result InsertCkdSmtComponentInfo(tblCkdSmtMaster smtTableTestComponent)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.InsertCkdSmtComponentInfo(smtTableTestComponent);

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

        public List<tblCkdSmtMaster> GetCkdSmtMasterInfo(tblCkdSmtMaster tblCkdSmtMaster)
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetCkdSmtMasterInfo(tblCkdSmtMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result UpdateCkdSmtInfo(tblCkdSmtMaster smtTableTestComponent)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.UpdateCkdSmtInfo(smtTableTestComponent);

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

        public Result InsertCkdRfComponentInfo(tblCkdRfMaster rfTableTestComponent)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.InsertRfStationInformation(rfTableTestComponent);

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

        public List<tblCkdRfMaster> GetCkdRfMasterInfo(tblCkdRfMaster tblCkdRfMaster)
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetCkdRfMasterInfo(tblCkdRfMaster);
            }
            catch (Exception ex) { throw ex; }
        }

      

        public Result UpdateCkdrfInfo(tblCkdRfMaster rfTableTestComponent)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.UpdateCkdRfInfo(rfTableTestComponent);

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

        public Result InsertCkdSoftwareLoadComponentInfo(tblCkdSoftwareLoadMaster softwareLoadTableTestComponent)
        {
        
          try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.InsertSoftwareLoadStationInformation(softwareLoadTableTestComponent);

                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public List<tblCkdSoftwareLoadMaster> GetCkdSoftwareLoadMasterInfo(tblCkdSoftwareLoadMaster tblCkdSoftwareLoadMaster)
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetCkdSoftwareLoadMasterInfo(tblCkdSoftwareLoadMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result UpdateCkdSoftwareLoadInfo(tblCkdSoftwareLoadMaster softwareLoadTableTestComponent)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.UpdateCkdSoftwareLoadInfo(softwareLoadTableTestComponent);

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


        //Count
        public List<tblCkdSoftwareLoadMaster> GetSoftwareLoadQrCount()
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetSoftwareLoadQrCount();
            }
            catch (Exception ex) 
            { throw ex; }
        }

        public List<tblCkdSmtMaster> GetSmtQrCount()
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetSmtQrCount();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<tblCkdRfMaster> GetRfQrCount()
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetRfQrCount();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<tblCkdMmiMaster> GetMmiQrCount()
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetMmiQrCount();
            }
            catch (Exception ex)
            { throw ex; }
        }



        public Result InsertCkdRework(tblCkdRework rework)
        {
            try
            {


                using (
                    var transaction = new TransactionScope(TransactionScopeOption.Required,
                        ApplicationState.TransactionOptions))
                {
                    var result = new Result();
                    result.IsSuccess = _ickd.InsertCkdRework(rework);

                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }


        public List<tblCkdSmtMaster> GetAnyParaMeterInfo(tblCkdSmtMaster tblCkdSmtMaster)
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetAnyParaMeterInfo(tblCkdSmtMaster);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblCkdIssues> GetAllIssueList()
        {
            try
            {
                ICKD iDataAccessSelect = new WCMS_DAL_CKD();
                return iDataAccessSelect.GetAllIssueList();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
