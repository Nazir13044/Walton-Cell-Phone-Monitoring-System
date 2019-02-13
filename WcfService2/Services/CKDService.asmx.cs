using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WCMS_BLL.Manager;
using WCMS_COMMON;
using WCMS_ENTITY;

namespace WcfService2.Services
{
    /// <summary>
    /// Summary description for CKDService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CKDService : System.Web.Services.WebService
    {
        readonly CKDManager _ckdManage = new CKDManager();
       


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public Result InsertCkdMmiComponentInfo(tblCkdMmiMaster mmItabltestComponent)
        {
            try
            {
                //tblTest mmItabltestComponent = null;
                return _ckdManage.InsertCkdMmiComponentInfo(mmItabltestComponent);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public  List< tblCkdMmiMaster> GetCkdMmiMasterInfo(tblCkdMmiMaster tblCkdMmiMaster)
        {
            List<tblCkdMmiMaster> mmiMasterList;

            try
            {
                mmiMasterList = _ckdManage.GetCkdMmiMasterInfo(tblCkdMmiMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mmiMasterList;
        }

        public Result UpdateCkdMmiInfo(tblCkdMmiMaster mmItabltestComponent)
        {
            try
            {
                return _ckdManage.UpdateCkdMmiInfo(mmItabltestComponent);
            }
            catch (Exception ex)
            {
                
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertCkdSmtComponentInfo(tblCkdSmtMaster smtTableTestComponent)
        {
            try
            {
                //tblTest mmItabltestComponent = null;
                return _ckdManage.InsertCkdSmtComponentInfo(smtTableTestComponent);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<tblCkdSmtMaster> GetCkdSmtMasterInfo(tblCkdSmtMaster tblCkdSmtMaster)
        {
            List<tblCkdSmtMaster> smtMasterList;

            try
            {
                smtMasterList = _ckdManage.GetCkdSmtMasterInfo(tblCkdSmtMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return smtMasterList;
        }

        public Result UpdateCkdSmtInfo(tblCkdSmtMaster smtTableTestComponent)
        {
            try
            {
                return _ckdManage.UpdateCkdSmtInfo(smtTableTestComponent);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertCkdRfComponentInfo(tblCkdRfMaster rfTableTestComponent)
        {
            try
            {
                //tblTest mmItabltestComponent = null;
                return _ckdManage.InsertCkdRfComponentInfo(rfTableTestComponent);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<tblCkdRfMaster> GetCkdRfMasterInfo(tblCkdRfMaster tblCkdRfMaster)
        {
            List<tblCkdRfMaster> rfMasterList;

            try
            {
                rfMasterList = _ckdManage.GetCkdRfMasterInfo(tblCkdRfMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rfMasterList;
        }

       

        public Result UpdateCkdRfInfo(tblCkdRfMaster rfTableTestComponent)
        {
            try
            {
                return _ckdManage.UpdateCkdrfInfo(rfTableTestComponent);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        //SoftwareLoad

        public Result InsertCkdSoftwareLoadComponentInfo(tblCkdSoftwareLoadMaster softwareLoadTableTestComponent)
        {
            try
            {
                //tblTest mmItabltestComponent = null;
                return _ckdManage.InsertCkdSoftwareLoadComponentInfo(softwareLoadTableTestComponent);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<tblCkdSoftwareLoadMaster> GetCkdSoftwareLoadMasterInfo(tblCkdSoftwareLoadMaster tblCkdSoftwareLoadMaster)
        {
            List<tblCkdSoftwareLoadMaster> softwareLoadMasterList;

            try
            {
                softwareLoadMasterList = _ckdManage.GetCkdSoftwareLoadMasterInfo(tblCkdSoftwareLoadMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return softwareLoadMasterList;
        }



        public Result UpdateCkdSoftwareLoadInfo(tblCkdSoftwareLoadMaster softwareLoadTableTestComponent)
        {
            try
            {
                return _ckdManage.UpdateCkdSoftwareLoadInfo(softwareLoadTableTestComponent);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        [WebMethod]
        public List<tblCkdSoftwareLoadMaster> GetSoftwareLoadQrCount()
        {
            var list = new List<tblCkdSoftwareLoadMaster>();
            try
            {
                list = _ckdManage.GetSoftwareLoadQrCount();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<tblCkdSmtMaster> GetSmtQrCount()
        {
            var list = new List<tblCkdSmtMaster>();
            try
            {
                list = _ckdManage.GetSmtQrCount();
            }
            catch (Exception ex)
            {

            }
            return list;
        }


        [WebMethod]
        public Result InsertCkdRework(tblCkdRework rework)
        {
            try
            {
                return _ckdManage.InsertCkdRework(rework);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<tblCkdRfMaster> GetRfQrCount()
        {
            var list = new List<tblCkdRfMaster>();
            try
            {
                list = _ckdManage.GetRfQrCount();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<tblCkdMmiMaster> GetMmiQrCount()
        {
            var list = new List<tblCkdMmiMaster>();
            try
            {
                list = _ckdManage.GetMmiQrCount();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<tblCkdSmtMaster> GetAnyParaMeterInfo(tblCkdSmtMaster tblCkdSmtMaster)
        {
            List<tblCkdSmtMaster> smtMasterList;

            try
            {
                smtMasterList = _ckdManage.GetAnyParaMeterInfo(tblCkdSmtMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return smtMasterList;
        }

        public List<tblCkdIssues> GetAllIssueList()
        {
            var _IssueList = new List<tblCkdIssues>();
            try
            {
                _IssueList = _ckdManage.GetAllIssueList();
            }
            catch (Exception ex)
            {

            }

            return _IssueList;
        }
    }
}
