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
    /// Summary description for LoginService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginService : System.Web.Services.WebService
    {
        CommonManager _CommonManager= new CommonManager();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }




        //public Result InsertEmployeeInfo(Employee _employee)
        //{
        //    try
        //    {
        //        return _CommonManager.InsertEmployeeInfo(_employee);
        //    }
        //    catch (Exception ex)
        //    {
        //        //if (log.IsErrorEnabled)
        //        //log.Error("Select Bearer: " + ex.Message);
        //        return new Result { IsSuccess = false, Message = ex.Message };
        //    }
        //}


    }
}
