using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_DAL.Inserting;
using WCMS_DAL.Interfaces;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;

namespace WCMS_BLL.Manager
{
    public class CkdReportManager
    {
        static readonly ICkd_Report iDisplayPassFailCount = new WCMS_DAL_CKD_Report();

        public static List<CkdModel> DisplayPassFailCount(string date)
        {
            try
            {
                return iDisplayPassFailCount.DisplayPassFailCount(date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CkdModel> GetCkdReport(string date, string Model)
        {
            try
            {
                return iDisplayPassFailCount.GetCkdReport(date, Model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CkdModel> GetCkdMmiReportInfo(string date, string Model)
        {
            try
            {
                return iDisplayPassFailCount.GetCkdMmiReportInfo(date, Model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CkdModel> GetCkdSmtReportInfo(string date, string Model)
        {
            try
            {
                return iDisplayPassFailCount.GetCkdSmtReportInfo(date, Model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CkdModel> GetCkdSoftwareLoadReportInfo(string date, string Model)
        {
            try
            {
                return iDisplayPassFailCount.GetCkdSoftwareLoadReportInfo(date, Model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CkdModel> GetCkdRfReportInfo(string date, string Model)
        {
            try
            {
                return iDisplayPassFailCount.GetCkdRfReportInfo(date, Model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
