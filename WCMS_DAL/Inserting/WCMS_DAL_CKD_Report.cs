using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_DAL.Interfaces;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;

namespace WCMS_DAL.Inserting
{
   public class WCMS_DAL_CKD_Report : ICkd_Report
    {
       private readonly WCMSEntities _entity = new WCMSEntities();
       public List<CkdModel> DisplayPassFailCount(string date)
        {
            var list = new List<CkdModel>();


            try
            {


                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };


                list = _entity.Database.SqlQuery<CkdModel>("exec SpCkdMaster @date", targetdate).ToList();


            }
            catch (Exception ex)
            { throw ex; };

            return list;
        }

       public List<CkdModel> GetCkdReport(string date, string model)
       {

           var list = new List<CkdModel>();


           try
           {



               var targetdate = new SqlParameter
               {
                   ParameterName = "@date",
                   Value = date
               };

               var targetmodel = new SqlParameter
               {
                   ParameterName = "@model",
                   Value = String.IsNullOrEmpty(model) ? (object)DBNull.Value : model
               };




               list = _entity.Database.SqlQuery<CkdModel>("exec SpCkdReport @date,@model", targetdate, targetmodel).ToList();


           }
           catch (Exception ex) { throw ex; };

           return list;
       }



       public List<CkdModel> GetCkdMmiReportInfo(string date, string model)
       {

           var list = new List<CkdModel>();


           try
           {



               var targetdate = new SqlParameter
               {
                   ParameterName = "@date",
                   Value = date
               };

               var targetmodel = new SqlParameter
               {
                   ParameterName = "@model",
                   Value = String.IsNullOrEmpty(model) ? (object)DBNull.Value : model
               };




               list = _entity.Database.SqlQuery<CkdModel>("exec SpCkdMmiReport @date,@model", targetdate, targetmodel).ToList();


           }
           catch (Exception ex) { throw ex; };

           return list;
       }

      

       public List<CkdModel> GetCkdSmtReportInfo(string date, string model)
       {

           var list = new List<CkdModel>();


           try
           {

               var targetdate = new SqlParameter
               {
                   ParameterName = "@date",
                   Value = date
               };

               var targetmodel = new SqlParameter
               {
                   ParameterName = "@model",
                   Value = String.IsNullOrEmpty(model) ? (object)DBNull.Value : model
               };




               list = _entity.Database.SqlQuery<CkdModel>("exec SpCkdSmtReport @date,@model", targetdate, targetmodel).ToList();


           }
           catch (Exception ex) { throw ex; };

           return list;
       }


       public List<CkdModel> GetCkdSoftwareLoadReportInfo(string date, string model)
       {

           var list = new List<CkdModel>();


           try
           {

               var targetdate = new SqlParameter
               {
                   ParameterName = "@date",
                   Value = date
               };

               var targetmodel = new SqlParameter
               {
                   ParameterName = "@model",
                   Value = String.IsNullOrEmpty(model) ? (object)DBNull.Value : model
               };




               list = _entity.Database.SqlQuery<CkdModel>("exec SpCkdSoftwareLoadReport @date,@model", targetdate, targetmodel).ToList();


           }
           catch (Exception ex) { throw ex; };

           return list;
       }


       public List<CkdModel> GetCkdRfReportInfo(string date, string model)
       {

           var list = new List<CkdModel>();


           try
           {

               var targetdate = new SqlParameter
               {
                   ParameterName = "@date",
                   Value = date
               };

               var targetmodel = new SqlParameter
               {
                   ParameterName = "@model",
                   Value = String.IsNullOrEmpty(model) ? (object)DBNull.Value : model
               };




               list = _entity.Database.SqlQuery<CkdModel>("exec SpCkdRfReport @date,@model", targetdate, targetmodel).ToList();


           }
           catch (Exception ex) { throw ex; };

           return list;
       }
    }
}
