using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WCMS_BLL.Manager;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;

namespace WcfService2.Services
{
    /// <summary>
    /// Summary description for CkdReportService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CkdReportService : System.Web.Services.WebService
    {
        private CkdReportManager reportManager = new CkdReportManager();
        

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public List<CkdModel> DisplayPassFailCount(string date)
        {
            var List = new List<CkdModel>();

            try
            {
                List = CkdReportManager.DisplayPassFailCount(date);

            }
            catch (Exception ex)
            {

            }

            return List;
        }

        public List<CkdModel> GetCkdReport(string date, string Model)
        {
            var List = new List<CkdModel>();

            try
            {
                List = reportManager.GetCkdReport(date, Model);

            }
            catch (Exception ex)
            {

            }

            return List;
        }


        public List<CkdModel> GetCkdMmiReportInfo(string date, string Model)
        {
            var List = new List<CkdModel>();

            try
            {
                List = reportManager.GetCkdMmiReportInfo(date, Model);

            }
            catch (Exception ex)
            {

            }

            return List;
        }


        public List<CkdModel> GetCkdSmtReportInfo(string date, string Model)
        {
            var List = new List<CkdModel>();

            try
            {
                List = reportManager.GetCkdSmtReportInfo(date, Model);

            }
            catch (Exception ex)
            {

            }

            return List;
        }


        public List<CkdModel> GetCkdSoftwareLoadReportInfo(string date, string Model)
        {
            var List = new List<CkdModel>();

            try
            {
                List = reportManager.GetCkdSoftwareLoadReportInfo(date, Model);

            }
            catch (Exception ex)
            {

            }

            return List;
        }


        public List<CkdModel> GetCkdRfReportInfo(string date, string Model)
        {
            var List = new List<CkdModel>();

            try
            {
                List = reportManager.GetCkdRfReportInfo(date, Model);

            }
            catch (Exception ex)
            {

            }

            return List;
        }


      


    }

   
}
