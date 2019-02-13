using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfService2.Services;
using WCMS_ENTITY.CustomModelEntity;

namespace WCMS_MAIN.Controllers
{
    public class CkdReportController : Controller
    {
        readonly CkdReportService _ckdReportService = new CkdReportService();
        readonly AdminService _adminService = new AdminService();
        readonly CommonService _commonService = new CommonService();


        public ActionResult Ckd_Report()
        {
            DateTime serverTime = DateTime.Now;
            TempData["datep"] = serverTime.ToString("yyyy/MM/dd");
           
            return View();
        }

        public ActionResult Get_Ckd_Report()
        {
            

            return View();
        }

        public ActionResult GetCkdMmiReport()
        {

            return View();
        }

        public ActionResult GetCkdSmtReport()
        {
            return View();
        }

        public ActionResult GetCkdSoftwareLoadReport()
        {
            return View();
        }

        public ActionResult GetCkdRfReport()
        {
            return View();
        }


       
          public JsonResult DisplayPassFailCount(string date)
        
        {
            var list = _ckdReportService.DisplayPassFailCount(date).OrderBy(a=>a.LineId).ToList();
            var list1 = new List<CkdModel>();

            
            foreach (var ckdModel in list)
              {
              
                  var a = new CkdModel();
                  a.Model = ckdModel.Model;
                  a.LineId = ckdModel.LineId;
                  a.SMTPassed = ckdModel.SMTPassed;
                  a.SMTPFailed = ckdModel.SMTPFailed;
                  a.SoftwareLoadPassed = ckdModel.SoftwareLoadPassed;
                  a.SoftwareLoadPFailed = ckdModel.SoftwareLoadPFailed;
                  a.MMIPassed = ckdModel.MMIPassed;
                  a.MMIPFailed = ckdModel.MMIPFailed;
                  a.RfPassed = ckdModel.RfPassed;
                  a.RfPFailed = ckdModel.RfPFailed;

                  if (ckdModel.Model != null)
                  {
                      a.Model = ckdModel.Model;
                      //a.ProjectName = a.ProjectName.Remove(a.ProjectName.Length - 10, 10);
                  }



                


                 


                  list1.Add(a);
              }

            List<CkdModel> list2 = new List<CkdModel>();
            if (list1.Any())
            {
                foreach (var targetModel in list1)
                {
                    var indx = list2.FindIndex(i => i.LineId == targetModel.LineId);
                    if (indx == -1)
                    {
                        list2.Add(targetModel);
                    }
                    else
                    {
                        list2[indx].Model = list2[indx].Model + " , " + targetModel.Model;

                        list2[indx].SMTPassed += targetModel.SMTPassed;
                        list2[indx].SMTPFailed += targetModel.SMTPFailed;
                        list2[indx].SoftwareLoadPassed += targetModel.SoftwareLoadPassed;
                        list2[indx].SoftwareLoadPFailed += targetModel.SoftwareLoadPFailed;
                        list2[indx].MMIPassed += targetModel.MMIPassed; 
                        list2[indx].MMIPFailed += targetModel.MMIPFailed;
                        list2[indx].RfPassed += targetModel.RfPassed;
                        list2[indx].RfPFailed += targetModel.RfPFailed;
                       


                    }
                }
            }

           
          
            return Json(list2, JsonRequestBehavior.AllowGet);


        }



          public JsonResult GetCkdReport(string date, string Model)
          {



              var oQcList = _ckdReportService.GetCkdReport(date, Model).ToList();
               var List = new List<CkdModel>();
               foreach (var ckdModel in oQcList)
               {
                   var CkdModel = new CkdModel();                   
                   CkdModel.SMTPassed = ckdModel.SMTPassed;
                   CkdModel.SMTPFailed = ckdModel.SMTPFailed;
                   CkdModel.SoftwareLoadPassed = ckdModel.SoftwareLoadPassed;
                   CkdModel.SoftwareLoadPFailed = ckdModel.SoftwareLoadPFailed;
                   CkdModel.MMIPassed = ckdModel.MMIPassed;
                   CkdModel.MMIPFailed = ckdModel.MMIPFailed;
                   CkdModel.RfPassed = ckdModel.RfPassed;
                   CkdModel.RfPFailed = ckdModel.RfPFailed;
                   List.Add(CkdModel);
               }

              return Json( new {data=oQcList}, JsonRequestBehavior.AllowGet);

          }

          public JsonResult GetCkdMmiReportInfo(string date, string Model)
          {



              var oQcList = _ckdReportService.GetCkdMmiReportInfo(date, Model).ToList();
              var List = new List<CkdModel>();
              foreach (var ckdMmiModel in oQcList)
              {
                  var CkdMmiModel = new CkdModel();

                  CkdMmiModel.MMIPassed = ckdMmiModel.MMIPassed;
                  CkdMmiModel.MMIPFailed = ckdMmiModel.MMIPFailed;

                  List.Add(CkdMmiModel);
              }

              return Json(new { data = oQcList }, JsonRequestBehavior.AllowGet);

          }

          public JsonResult GetCkdSmtReportInfo(string date, string Model)
          {



              var oQcList = _ckdReportService.GetCkdSmtReportInfo(date, Model).ToList();
              var List = new List<CkdModel>();
              foreach (var ckdSmtModel in oQcList)
              {
                  var CkdSmtModel = new CkdModel();

                  CkdSmtModel.SMTPassed = ckdSmtModel.SMTPassed;
                  CkdSmtModel.SMTPFailed = ckdSmtModel.SMTPFailed;

                  List.Add(CkdSmtModel);
              }

              return Json(new { data = oQcList }, JsonRequestBehavior.AllowGet);

          }


          public JsonResult GetCkdSoftwareLoadReportInfo(string date, string Model)
          {



              var oQcList = _ckdReportService.GetCkdSoftwareLoadReportInfo(date, Model).ToList();
              var List = new List<CkdModel>();
              foreach (var ckdSoftwareLoadModel in oQcList)
              {
                  var CkdSoftwareLoadModel = new CkdModel();

                  CkdSoftwareLoadModel.SoftwareLoadPassed = ckdSoftwareLoadModel.SoftwareLoadPassed;
                  CkdSoftwareLoadModel.SoftwareLoadPFailed = ckdSoftwareLoadModel.SoftwareLoadPFailed;

                  List.Add(CkdSoftwareLoadModel);
              }

              return Json(new { data = oQcList }, JsonRequestBehavior.AllowGet);

          }

          public JsonResult GetCkdRfReportInfo(string date, string Model)
          {



              var oQcList = _ckdReportService.GetCkdRfReportInfo(date, Model).ToList();
              var List = new List<CkdModel>();
              foreach (var ckdRfModel in oQcList)
              {
                  var CkdRfModel = new CkdModel();

                  CkdRfModel.RfPassed = ckdRfModel.RfPassed;
                  CkdRfModel.RfPFailed = ckdRfModel.RfPFailed;

                  List.Add(CkdRfModel);
              }

              return Json(new { data = oQcList }, JsonRequestBehavior.AllowGet);

          }
        


       
	}
}