using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using UpdateEmployeesInKPIProject;
using WCMS_COMMON;
using WCMS_DAL.HelperClass;
using WCMS_DAL.Interfaces;
using WCMS_DAL.Selecting;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;

namespace WCMS_DAL.Inserting
{
    public class WCMS_DAL_Reporting : IReporting
    {
        private readonly WCMSEntities _entity = new WCMSEntities();
        private readonly WCMSCellPhoneProjectEntities _wcmsCellPhoneProjectEntities = new WCMSCellPhoneProjectEntities();

        public List<DailyProductionModel> GetProductCount(int projectId, string date)
        {
            List<DailyProductionModel> list;

            try
            {
                var project = new SqlParameter
                {
                    ParameterName = "@projectId",
                    Value = Convert.ToInt64(projectId)
                };
                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };


                list =
                    _entity.Database.SqlQuery<DailyProductionModel>("exec SPGetProductCount @projectId, @date", project,
                        targetdate).ToList();


            }

            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<HourlyTargetModel> GetHourlyTaregtEfficiencyReport(int projectId, int lineId, string date = "")
        {

            var list = new List<HourlyTargetModel>();


            try
            {

                var project = new SqlParameter
                {
                    ParameterName = "@projectId",
                    Value = Convert.ToInt64(projectId)
                };
                var line = new SqlParameter
                {
                    ParameterName = "@lineId",
                    Value = Convert.ToInt64(lineId)
                };
                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };

                list =
                    _entity.Database.SqlQuery<HourlyTargetModel>(
                        "exec SpHourlyTargetEfficiency @projectId,@lineId, @date", project, line, targetdate).ToList();



            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;




        }

        public List<OQcReportModel> GetOQcReport(int projectId, string date)
        {
            var list = new List<OQcReportModel>();

            var ndate = DateTime.Parse(date, System.Globalization.CultureInfo.CurrentCulture);

            try
            {

                var project = new SqlParameter
                {
                    ParameterName = "@projectId",
                    Value = Convert.ToInt64(projectId)
                };
                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };

                list =
                    _entity.Database.SqlQuery<OQcReportModel>("exec SPOQcStatus @projectId, @date", project, targetdate)
                        .ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public List<HourlyTargetModel> HourlyStationineWiseFault(int projectId, string date)
        {
            var list = new List<HourlyTargetModel>();


            try
            {

                var project = new SqlParameter
                {
                    ParameterName = "@projectId",
                    Value = Convert.ToInt64(projectId)
                };
                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };

                //list = _entity.Database.SqlQuery<HourlyTargetModel>("exec SpHourlyTargetEfficiency @projectId, @date", project, targetdate).ToList();
                list =
                    _entity.Database.SqlQuery<HourlyTargetModel>("exec SpLineWiseHourlyTargetEfficiency @date",
                        targetdate).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public List<HourlyTargetModel> HourlyStationineWisestatus(string date)
        {
            var list = new List<HourlyTargetModel>();


            try
            {


                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };

                //list = _entity.Database.SqlQuery<HourlyTargetModel>("exec SpHourlyTargetEfficiency @projectId, @date", project, targetdate).ToList();
                list =
                    _entity.Database.SqlQuery<HourlyTargetModel>("exec SpLineWiseStationsHourlyStatus @date", targetdate)
                        .ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public List<HourlyTargetModel> DisplayProductionCount(string date)
        {
            var list = new List<HourlyTargetModel>();


            try
            {


                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };


                list =
                    _entity.Database.SqlQuery<HourlyTargetModel>("exec SpProductionLineCount @date", targetdate)
                        .ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public List<HourlyTargetModel> DisplayPackagingCount(string date)
        {
            var list = new List<HourlyTargetModel>();


            try
            {


                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };


                list =
                    _entity.Database.SqlQuery<HourlyTargetModel>("exec SpPackagingLineCount @date", targetdate).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }


        public List<HourlyTargetModel> GetLogisticsReport(string date, string project)
        {
            var list = new List<HourlyTargetModel>();


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
                    Value = String.IsNullOrEmpty(project) ? (object) DBNull.Value : project
                };




                list =
                    _entity.Database.SqlQuery<HourlyTargetModel>("exec MyLogisticsTest @date,@model", targetdate,
                        targetmodel).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public List<HourlyTargetModel> GetLogisticsReportByDate(DateTime fromdate, DateTime todate)
        {
            List<HourlyTargetModel> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);


            // DateTime startDate = DateTime.ParseExact(date);
            // DateTime endDate = DateTime.ParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture);



            try
            {

                list = (from imeiRecord in _entity.tblIMEIRecord
                    join logistics in _entity.tblLogistics on imeiRecord.IMEI1 equals logistics.Imei1
                    where logistics.AddedDate >= startDate && logistics.AddedDate <= toDate
                    orderby logistics.AddedDate descending

                    select new HourlyTargetModel
                    {

                        Model = imeiRecord.Model,
                        ProjectName = imeiRecord.Project,
                        Color = imeiRecord.Color ?? "",
                        Imei1 = logistics.Imei1,
                        Uploaded = logistics.Uploaded,
                        OracleUploaded = logistics.OracleUploaded

                    }).AsNoTracking().ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblLogistics> GetLogisticsReportWithDateModel(DateTime fromdate, DateTime todate, string model,
            string color)
        {
            List<tblLogistics> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);

            try
            {

                if (String.IsNullOrEmpty(color))
                {

                    list =
                        _entity.tblLogistics.Where(
                            x => x.Model == model && (x.AddedDate >= startDate && x.AddedDate <= toDate))

                            //.WhereIf(date != null, )
                            //.WhereIf(!String.IsNullOrEmpty( model), x => x.Model == model)

                            .AsNoTracking().ToList();

                }
                else
                {

                    list =
                        _entity.tblLogistics.Where(
                            x =>
                                x.Model == model && (x.AddedDate >= startDate && x.AddedDate <= toDate) &&
                                x.Color == color)

                            //.WhereIf(date != null, )
                            //.WhereIf(!String.IsNullOrEmpty( model), x => x.Model == model)

                            .AsNoTracking().ToList();
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<ImeiModelUpload> GetDetailsImeiData(DateTime fromdate, DateTime todate, string model, string color)
        {
            List<ImeiModelUpload> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);

            try
            {
                list = (from imeiRecord in _entity.tblIMEIRecord
                    join logistics in _entity.tblLogistics on imeiRecord.IMEI1 equals logistics.Imei1
                    where
                        (logistics.AddedDate >= startDate && logistics.AddedDate <= toDate) && logistics.Model == model &&
                        logistics.Color == color && logistics.Uploaded == null

                    select new ImeiModelUpload
                    {

                        Model = logistics.Model,
                        Color = logistics.Color ?? "",
                        Barcode = logistics.Imei1,
                        Barcode2 = logistics.Imei2,
                        UpdatedBy = imeiRecord.WO,
                        PrintDate = logistics.AddedDate,

                    }).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }






            return list;

        }

        public List<TpLcdReport> GetTpLcdReport(int project, DateTime fromdate, DateTime todate)
        {

            List<TpLcdReport> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);






            try
            {

                if (project != 0)
                {
                    list = (from tplcd in _entity.tblTpLcdMaster
                        join tblLog in _entity.tblLogin on tplcd.AddedBy equals tblLog.Id
                        where
                            tplcd.AddedDate >= startDate && tplcd.AddedDate <= toDate && tplcd.Passed == "Y" &&
                            tplcd.ProjectId == project
                        orderby tplcd.AddedDate descending

                        select new TpLcdReport
                        {

                            ProjectId = tplcd.ProjectId,
                            ProjectName = tplcd.ProjectName,
                            AddedBy = tplcd.AddedBy,
                            AddedName = tblLog.EmployeeName

                        }).AsNoTracking().ToList();
                }


                else
                {
                    list = (from tplcd in _entity.tblTpLcdMaster
                        join tblLog in _entity.tblLogin on tplcd.AddedBy equals tblLog.Id
                        where tplcd.AddedDate >= startDate && tplcd.AddedDate <= toDate && tplcd.Passed == "Y"
                        orderby tplcd.AddedDate descending

                        select new TpLcdReport
                        {

                            ProjectId = tplcd.ProjectId,
                            ProjectName = tplcd.ProjectName,
                            AddedBy = tplcd.AddedBy,
                            AddedName = tblLog.EmployeeName

                        }).AsNoTracking().ToList();
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<TpLcdReport> GetTpLcdIssuesReport(int project, DateTime fromdate, DateTime todate)
        {
            List<TpLcdReport> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);

            try
            {

                if (project != 0)
                {
                    list = (from rework in _entity.tblLcdGlueRework
                        join tblLog in _entity.tblLogin on rework.AddedBy equals tblLog.Id
                        where
                            rework.AddedDate >= startDate && rework.AddedDate <= toDate && rework.ProjectId == project &&
                            rework.FailedFrom == "TPLCD"
                        orderby rework.AddedDate descending

                        select new TpLcdReport
                        {

                            ProjectId = rework.ProjectId,
                            ProjectName = rework.ProjectName,
                            Issues = rework.Issue,
                            AddedBy = rework.AddedBy,
                            AddedName = tblLog.EmployeeName,
                            Status = rework.Status

                        }).AsNoTracking().ToList();
                }


                else
                {
                    list = (from rework in _entity.tblLcdGlueRework
                        join tblLog in _entity.tblLogin on rework.AddedBy equals tblLog.Id
                        where
                            rework.AddedDate >= startDate && rework.AddedDate <= toDate && rework.FailedFrom == "TPLCD"
                        orderby rework.AddedDate descending

                        select new TpLcdReport
                        {

                            ProjectId = rework.ProjectId,
                            ProjectName = rework.ProjectName,
                            Issues = rework.Issue,
                            AddedBy = rework.AddedBy,
                            AddedName = tblLog.EmployeeName,
                            Status = rework.Status
                        }).AsNoTracking().ToList();
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<TpLcdReport> GetTpLcdAllReport(string project, object dateFrom, object todate)
        {
            var list = new List<TpLcdReport>();


            try
            {



                var targetdatefrom = new SqlParameter
                {
                    ParameterName = "@dateFrom",
                    Value = dateFrom
                };
                var targetdateto = new SqlParameter
                {
                    ParameterName = "@todate",
                    Value = todate
                };

                var targetproject = new SqlParameter
                {
                    ParameterName = "@project",
                    Value = String.IsNullOrEmpty(project) ? (object) DBNull.Value : project
                };




                list =
                    _entity.Database.SqlQuery<TpLcdReport>("exec SpTpLcdReport @dateFrom,@todate,@project",
                        targetdatefrom, targetdateto, targetproject).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public List<GlueStationReport> GetTGlueStationReport(int project, DateTime fromdate, DateTime todate)
        {
            List<GlueStationReport> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);






            try
            {

                if (project != 0)
                {
                    list = (from glueMaster in _entity.tblGlueMaster
                        join tblLog in _entity.tblLogin on glueMaster.AddedBy equals tblLog.Id
                        where
                            glueMaster.AddedDate >= startDate && glueMaster.AddedDate <= toDate &&
                            glueMaster.Passed == "Y" && glueMaster.ProjectId == project
                        orderby glueMaster.AddedDate descending

                        select new GlueStationReport
                        {

                            ProjectId = glueMaster.ProjectId,
                            ProjectName = glueMaster.ProjectName,
                            AddedBy = glueMaster.AddedBy,
                            AddedName = tblLog.EmployeeName

                        }).AsNoTracking().ToList();
                }


                else
                {
                    list = (from glueMaster in _entity.tblGlueMaster
                        join tblLog in _entity.tblLogin on glueMaster.AddedBy equals tblLog.Id
                        where
                            glueMaster.AddedDate >= startDate && glueMaster.AddedDate <= toDate &&
                            glueMaster.Passed == "Y"
                        orderby glueMaster.AddedDate descending

                        select new GlueStationReport
                        {

                            ProjectId = glueMaster.ProjectId,
                            ProjectName = glueMaster.ProjectName,
                            AddedBy = glueMaster.AddedBy,
                            AddedName = tblLog.EmployeeName

                        }).AsNoTracking().ToList();
                }


                //GlueStationReport

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<GlueStationReport> GetGlueIssuesReport(int project, DateTime fromdate, DateTime todate)
        {
            List<GlueStationReport> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);

            try
            {

                if (project != 0)
                {
                    list = (from rework in _entity.tblLcdGlueRework
                        join tblLog in _entity.tblLogin on rework.AddedBy equals tblLog.Id
                        where
                            rework.AddedDate >= startDate && rework.AddedDate <= toDate && rework.ProjectId == project &&
                            rework.FailedFrom == "GLUE"
                        orderby rework.AddedDate descending

                        select new GlueStationReport
                        {

                            ProjectId = rework.ProjectId,
                            ProjectName = rework.ProjectName,
                            Issues = rework.Issue,
                            AddedBy = rework.AddedBy,
                            AddedName = tblLog.EmployeeName,
                            Status = rework.Status

                        }).AsNoTracking().ToList();
                }


                else
                {
                    list = (from rework in _entity.tblLcdGlueRework
                        join tblLog in _entity.tblLogin on rework.AddedBy equals tblLog.Id
                        where rework.AddedDate >= startDate && rework.AddedDate <= toDate && rework.FailedFrom == "GLUE"
                        orderby rework.AddedDate descending

                        select new GlueStationReport
                        {

                            ProjectId = rework.ProjectId,
                            ProjectName = rework.ProjectName,
                            Issues = rework.Issue,
                            AddedBy = rework.AddedBy,
                            AddedName = tblLog.EmployeeName,
                            Status = rework.Status
                        }).AsNoTracking().ToList();
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<GlueStationReport> GetGlueAllReport(string project, string dateFrom, object todate)
        {
            var list = new List<GlueStationReport>();


            try
            {



                var targetdatefrom = new SqlParameter
                {
                    ParameterName = "@dateFrom",
                    Value = dateFrom
                };
                var targetdateto = new SqlParameter
                {
                    ParameterName = "@todate",
                    Value = todate
                };

                var targetproject = new SqlParameter
                {
                    ParameterName = "@project",
                    Value = String.IsNullOrEmpty(project) ? (object) DBNull.Value : project
                };




                list =
                    _entity.Database.SqlQuery<GlueStationReport>("exec SpGlueStationReport @dateFrom,@todate,@project",
                        targetdatefrom, targetdateto, targetproject).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public List<PackingBoxModel> GetBoxPackingData(string fromdate, string todate, string project)
        {

            var list = new List<PackingBoxModel>();
            String connectionString = ConfigurationManager.ConnectionStrings["VsunAdoDBEntities"].ConnectionString;

            var queryString = "SELECT T_WOID, T_IMEI1,T_IMEI2,T_BOXID FROM [F_Project_" + project +
                              "] WHERE CONVERT(date,T_BOXID_Time) BETWEEN '" + fromdate + "' AND '" + todate + "'";




            using (var connection =
                new SqlConnection(connectionString))
            {

                var command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var box = new PackingBoxModel();

                        //var boxId = reader["T_BOXID"];
                        var imei1 = reader["T_IMEI1"];
                        var imei2 = reader["T_IMEI2"];
                        var woid = reader["T_WOID"];

                        box.Imei1 = imei1 == null ? "" : imei1.ToString();
                        box.Imei2 = imei2 == null ? "" : imei2.ToString();
                        box.WoId = woid == null ? "" : woid.ToString();
                        list.Add(box);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                ;

            }
            //var imeiList = _entity.tblIMEIRecord.Where(oh => oh.Project==project).ToList();

            //var list1 = (from vsun in list
            //             join imei in imeiList on vsun.Imei1 equals imei.IMEI1



            //    select new PackingBoxModel
            //    {

            //        Model = imei.Model,
            //        Color = imei.Color ?? "",
            //        Imei1 = vsun.Imei1,
            //        Imei2 = vsun.Imei2
            //        Uploaded = logistics.Uploaded

            //    }).ToList();



            return list;
        }

        public List<PackingBoxModel> GetVsunWoDetails(string woid, string project, string fromdate, string todate)
        {
            var list = new List<PackingBoxModel>();
            String connectionString = ConfigurationManager.ConnectionStrings["VsunAdoDBEntities"].ConnectionString;

            var queryString = "SELECT T_WOID,T_SN,T_IMEI1,T_IMEI2,T_BOXID FROM [F_Project_" + project +
                              "] WHERE T_WOID='" + woid + "' AND CONVERT(date,T_BOXID_Time) BETWEEN '" + fromdate +
                              "' AND '" + todate + "'";




            using (var connection =
                new SqlConnection(connectionString))
            {

                var command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var box = new PackingBoxModel();

                        //var boxId = reader["T_BOXID"];
                        var imei1 = reader["T_IMEI1"];
                        var imei2 = reader["T_IMEI2"];
                        var woids = reader["T_WOID"];
                        var sn = reader["T_SN"];
                        var boxcode = reader["T_BOXID"];

                        box.Imei1 = imei1 == null ? "" : imei1.ToString();
                        box.Imei2 = imei2 == null ? "" : imei2.ToString();
                        box.WoId = woids == null ? "" : woids.ToString();
                        box.Sn = sn == null ? "" : sn.ToString();
                        box.BoxId = boxcode == null ? "" : boxcode.ToString();
                        list.Add(box);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                ;

            }
            //var imeiList = _entity.tblIMEIRecord.Where(oh => oh.Project==project).ToList();

            //var list1 = (from vsun in list
            //             join imei in imeiList on vsun.Imei1 equals imei.IMEI1



            //    select new PackingBoxModel
            //    {

            //        Model = imei.Model,
            //        Color = imei.Color ?? "",
            //        Imei1 = vsun.Imei1,
            //        Imei2 = vsun.Imei2
            //        Uploaded = logistics.Uploaded

            //    }).ToList();



            return list;
        }

        public List<ReworkList> GetFaultListByDate(DateTime fromdate, DateTime todate)
        {

            try
            {
                List<ReworkList> issuelist;
                var startDate = fromdate;

                var endDate = todate;
                var toDate = endDate.AddDays(1).AddTicks(-1);

                var projectname = _wcmsCellPhoneProjectEntities.ProjectMasters.ToList();

                var list = (from rework in _entity.tblRework
                    join line in _entity.tblProductionLine on rework.LineId equals line.LineId
                    where rework.AddedDate >= startDate && rework.AddedDate <= toDate
                    orderby rework.AddedDate descending

                    select new ReworkList
                    {

                        ProjectId = (long) rework.ProjectId,
                        //ProjectName = production.ProjectName,
                        Issues = rework.Issues,
                        LineName = line.LineName,
                        LineId = (long) rework.LineId,
                        FailedStation = rework.FailedStation
                    }).AsNoTracking().ToList();

                issuelist = (from fullList in list
                    join proj in projectname on fullList.ProjectId equals proj.ProjectMasterId

                    select new ReworkList
                    {
                        ProjectId = (long) fullList.ProjectId,
                        ProjectName = proj.ProjectName,
                        Issues = fullList.Issues,
                        LineName = fullList.LineName,
                        LineId = fullList.LineId,
                        FailedStation = fullList.FailedStation
                    }).ToList();

                //list = _entity.tblRework.Where(a => a.AddedDate >= startDate && a.AddedDate <= toDate).ToList();        
                return issuelist;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<AssemblyLineInfo> GetAssemblyLineReport(string date, long line)
        {
            List<AssemblyLineInfo> assemblyLineInfoList;


            try
            {




                var targetdate = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };

                var targetline = new SqlParameter
                {
                    ParameterName = "@LineId",
                    Value = line
                };



                _entity.Database.CommandTimeout = 300;
                var list =
                    _entity.Database.SqlQuery<AssemblyLineInfo>("exec SPLineWiseReport @LineId,@date", targetdate,
                        targetline).ToList();


                var projectname = _wcmsCellPhoneProjectEntities.ProjectMasters.ToList();

                assemblyLineInfoList = (from fulllList in list
                    join proj in projectname on fulllList.ProjectId equals proj.ProjectMasterId

                    select new AssemblyLineInfo
                    {
                        ProjectId = (long) fulllList.ProjectId,
                        ProjectName = proj.ProjectName + "-" + proj.OrderNuber,
                        LineId = fulllList.LineId,
                        // LineName = fulllList.LineName,
                        Pcb = fulllList.Pcb,
                        ScrewDone = fulllList.ScrewDone,
                        FunctionalQc = fulllList.FunctionalQc,
                        AestheticQc = fulllList.AestheticQc,

                    }).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return assemblyLineInfoList;


        }

        public List<TpLcdReport> GetTpLcdOverAllReport(int project, string fromdate, string todate)
        {
            var list = new List<TpLcdReport>();
            //if (project == 0)
            //    project = null;

            try
            {


                var targetproject = new SqlParameter
                {
                    ParameterName = "@projectId",
                    //Value = Convert.ToInt64(project)
                    Value = project == 0 ? (object) DBNull.Value : Convert.ToInt64(project)
                };
                var targetdatefrom = new SqlParameter
                {
                    ParameterName = "@fromDate",
                    Value = fromdate
                };
                var targetdateto = new SqlParameter
                {
                    ParameterName = "@toDate",
                    Value = todate
                };






                list =
                    _entity.Database.SqlQuery<TpLcdReport>("exec [SpTp-LcdReport] @projectId, @fromDate,@toDate",
                        targetproject, targetdatefrom, targetdateto).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public List<ProductionQcFaultScenerioModel> GetProductionQcStatus(string fromdate, int projectId)
        {
            var list = new List<ProductionQcFaultScenerioModel>();
            try
            {
                var targetproject = new SqlParameter
                {
                    ParameterName = "@projectId",
                    //Value = Convert.ToInt64(project)
                    Value = projectId == 0 ? (object) DBNull.Value : Convert.ToInt64(projectId)
                };

                var targetdatefrom = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = fromdate
                };





                list =
                    _entity.Database.SqlQuery<ProductionQcFaultScenerioModel>(
                        "exec SpDailyProductionFault @projectId, @date", targetproject, targetdatefrom).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public DataTable GetAssemblyLineissuesByDate(string date, int project)
        {
            //var list = new DataTable();


            DataTable table = new DataTable();

            // var consString = ConfigurationManager.ConnectionStrings["adoWcms"].ConnectionString;
            // var con = new SqlConnection(consString);


            using (
                var con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["adoWcmsfactoryserver"].ConnectionString))
            {

                //using (var cmd = new SqlCommand("usp_GetABCD", con))
                con.Open();
                using (var cmd = new SqlCommand("SPLineWiseIssueCount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
                    if (project == 0)
                        cmd.Parameters.Add("@projectId", SqlDbType.VarChar).Value = (object) DBNull.Value;
                    else
                    {
                        cmd.Parameters.Add("@projectId", SqlDbType.VarChar).Value = Convert.ToInt64(project);
                    }


                    using (var da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(table);
                    }
                }
                con.Close();


            }
            //var count = 1;
            foreach (DataColumn dc in table.Columns)
            {


                var str = dc.ColumnName;

                if (str != "IssueName" && str != "FailedStation")
                {
                    var projectId = Convert.ToInt64(str.Substring(7)); //key.slice(-3);


                    var projectName =
                        _wcmsCellPhoneProjectEntities.ProjectMasters.FirstOrDefault(x => x.ProjectMasterId == projectId);

                    var linename = str.Substring(0, str.Length - 3);

                    dc.ColumnName = linename + (projectName.ProjectName).Substring(6) + "-" + projectName.OrderNuber;
                }



                //count++;
            }
            table.AcceptChanges();
            //var t = table.AsEnumerable().Select(r =>.Field<string>("Description")).ToList();

            var filter = table.AsEnumerable().Where(x => x.Field<string>("FailedStation") == "ASTQC").CopyToDataTable();
            ;


            //var list=new DataTable();
            //try
            //{


            //    var targetdatefrom = new SqlParameter
            //    {
            //        ParameterName = "@date",
            //        Value = date
            //    };





            //    list = _entity.Database.SqlQuery<DataTable>("exec [SPLineWiseIssueCount]  @date", targetdatefrom);


            //}
            //catch (Exception ex) { throw ex; };


            return filter;
        }

        public List<RepairStationInfoModel> GetFullRepairStationReport(int project, DateTime fromdate, DateTime todate)
        {
            try
            {
                List<RepairStationInfoModel> issuelist;
                var startDate = fromdate;

                var endDate = todate;
                var toDate = endDate.AddDays(1).AddTicks(-1);

                var projectname = _wcmsCellPhoneProjectEntities.ProjectMasters.ToList();

                var list = (from rework in _entity.tblRework
                    join line in _entity.tblProductionLine on rework.LineId equals line.LineId
                    join repstat in _entity.tblRepairStatus on rework.ReworkId equals repstat.ReworkId into repstats
                    from repstat in repstats.DefaultIfEmpty()

                    join repcom in _entity.tblRepairComponents on rework.ReworkId equals repcom.ReworkId into repcoms
                    from repcom in repcoms.DefaultIfEmpty()

                    join log in _entity.tblLogin on rework.FinishedBy equals log.Id
                    where rework.FinishedDate >= startDate && rework.FinishedDate <= toDate
                    orderby rework.AddedDate descending

                    select new RepairStationInfoModel
                    {

                        ProjectId = (long) rework.ProjectId,
                        LineName = line.LineName,
                        LineId = (long) rework.LineId,
                        FailedStation = rework.FailedStation,
                        FinishedBy = rework.FinishedBy,
                        QcIssue = rework.Issues,
                        IsFaulty = repstat.IsFaulty == true ? "Y" : "N",
                        RepairIssue = repstat.Issue,
                        MaterialFault = repstat.MaterialFault == true ? "Y" : "N",
                        ProcessFault = repstat.ProcessFault == true ? "Y" : "N",
                        RepairRemarks = repstat.Remarks,
                        UsedComponents = repcom.UsedComponents,
                        UsedQuantity = repcom.UsedQuantity,
                        WasteQuantity = repcom.WasteQuantiy,
                        ComponentsRemarks = repcom.Remarks
                    }).AsNoTracking().ToList();

                issuelist = (from fullList in list
                    join proj in projectname on fullList.ProjectId equals proj.ProjectMasterId

                    select new RepairStationInfoModel
                    {
                        ProjectId = (long) fullList.ProjectId,
                        ProjectName = proj.ProjectName,

                        LineName = fullList.LineName,
                        LineId = (long) fullList.LineId,
                        FailedStation = fullList.FailedStation,
                        QcIssue = fullList.QcIssue,
                        IsFaulty = fullList.IsFaulty,
                        RepairIssue = fullList.RepairIssue,
                        MaterialFault = fullList.MaterialFault,
                        ProcessFault = fullList.ProcessFault,
                        RepairRemarks = fullList.RepairRemarks,
                        UsedComponents = fullList.UsedComponents,
                        UsedQuantity = fullList.UsedQuantity,
                        WasteQuantity = fullList.WasteQuantity,
                        ComponentsRemarks = fullList.ComponentsRemarks,
                        FinishedBy = fullList.FinishedBy,
                    }).ToList();

                //list = _entity.tblRework.Where(a => a.AddedDate >= startDate && a.AddedDate <= toDate).ToList();        
                return issuelist;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<HourlyTargetModel> GetLogisticsReportForUpload(DateTime fromdate, DateTime todate)
        {
            List<HourlyTargetModel> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);


            // DateTime startDate = DateTime.ParseExact(date);
            // DateTime endDate = DateTime.ParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture);



            try
            {

                list = (from imeiRecord in _entity.tblIMEIRecord
                    join logistics in _entity.tblLogistics on imeiRecord.IMEI1 equals logistics.Imei1
                    where
                        logistics.AddedDate >= startDate && logistics.AddedDate <= toDate && logistics.Uploaded == null
                    orderby logistics.AddedDate descending

                    select new HourlyTargetModel
                    {

                        Model = imeiRecord.Model,
                        Color = imeiRecord.Color ?? "",
                        Imei1 = logistics.Imei1,
                        Uploaded = logistics.Uploaded

                    }).AsNoTracking().ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<AssemblyLineproductionStatusModel> GetAssemblylineProductionStatusReport(int project,
            string fromdate, string todate)
        {
            var list = new List<AssemblyLineproductionStatusModel>();
            //if (project == 0)
            //    project = null;

            try
            {


                var targetproject = new SqlParameter
                {
                    ParameterName = "@projectId",
                    //Value = Convert.ToInt64(project)
                    Value = project == 0 ? (object) DBNull.Value : Convert.ToInt64(project)
                };
                var targetdatefrom = new SqlParameter
                {
                    ParameterName = "@fromDate",
                    Value = fromdate
                };
                var targetdateto = new SqlParameter
                {
                    ParameterName = "@toDate",
                    Value = todate
                };






                list =
                    _entity.Database.SqlQuery<AssemblyLineproductionStatusModel>(
                        "exec [SPAssemblylineProductionStatus] @projectId, @fromDate,@toDate", targetproject,
                        targetdatefrom, targetdateto).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;

            return list;
        }

        public DataTable GetFuAssemblyLineissuesByDate(string date, int project)
        {
            var table = new DataTable();
            using (
                var con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["adoWcmsfactoryserver"].ConnectionString))
            {

                //using (var cmd = new SqlCommand("usp_GetABCD", con))
                con.Open();
                using (var cmd = new SqlCommand("SPLineWiseIssueCount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
                    if (project == 0)
                        cmd.Parameters.Add("@projectId", SqlDbType.VarChar).Value = (object) DBNull.Value;
                    else
                    {
                        cmd.Parameters.Add("@projectId", SqlDbType.VarChar).Value = Convert.ToInt64(project);
                    }

                    using (var da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(table);
                    }
                }
                con.Close();


            }
            foreach (DataColumn dc in table.Columns)
            {


                var str = dc.ColumnName;

                if (str != "IssueName" && str != "FailedStation")
                {
                    var projectId = Convert.ToInt64(str.Substring(7)); //key.slice(-3);


                    var projectName =
                        _wcmsCellPhoneProjectEntities.ProjectMasters.FirstOrDefault(x => x.ProjectMasterId == projectId);

                    var linename = str.Substring(0, str.Length - 3);

                    dc.ColumnName = linename + (projectName.ProjectName).Substring(6) + "-" + projectName.OrderNuber;
                }
            }
            table.AcceptChanges();
            //var t = table.AsEnumerable().Select(r =>.Field<string>("Description")).ToList();

            var filter = table.AsEnumerable().Where(x => x.Field<string>("FailedStation") == "FUQC").CopyToDataTable();
            ;




            return filter;
        }

        public List<ReworkList> GetFaultListByProject(long project)
        {



            try
            {
                List<ReworkList> issuelist;


                var projectname = _wcmsCellPhoneProjectEntities.ProjectMasters.ToList();


                var totalProduction =
                    _entity.ProductionMaster.Count(a => a.ProjectId == project && a.FinallyPassed == "Y");

                var list = (from rework in _entity.tblRework
                    join line in _entity.tblProductionLine on rework.LineId equals line.LineId
                    where rework.ProjectId == project
                    orderby rework.AddedDate descending

                    select new ReworkList
                    {

                        ProjectId = (long) rework.ProjectId,
                        //ProjectName = production.ProjectName,
                        Issues = rework.Issues,
                        LineName = line.LineName,
                        LineId = (long) rework.LineId,
                        FailedStation = rework.FailedStation
                    }).AsNoTracking().ToList();

                issuelist = (from fullList in list
                    join proj in projectname on fullList.ProjectId equals proj.ProjectMasterId

                    select new ReworkList
                    {
                        ProjectId = (long) fullList.ProjectId,
                        ProjectName = proj.ProjectName,
                        Issues = fullList.Issues,
                        LineName = fullList.LineName,
                        LineId = fullList.LineId,
                        FailedStation = fullList.FailedStation,
                        TotalProduction = totalProduction

                    }).ToList();

                //list = _entity.tblRework.Where(a => a.AddedDate >= startDate && a.AddedDate <= toDate).ToList();        
                return issuelist;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<AssemblyLineproductionStatusModel> GetPackagingProductionStatusReport(int project, string fromdate,
            string todate)
        {
            var list = new List<AssemblyLineproductionStatusModel>();
            //if (project == 0)
            //    project = null;

            try
            {


                var targetproject = new SqlParameter
                {
                    ParameterName = "@projectId",
                    //Value = Convert.ToInt64(project)
                    Value = project == 0 ? (object) DBNull.Value : Convert.ToInt64(project)
                };
                var targetdatefrom = new SqlParameter
                {
                    ParameterName = "@fromDate",
                    Value = fromdate
                };
                var targetdateto = new SqlParameter
                {
                    ParameterName = "@toDate",
                    Value = todate
                };






                list =
                    _entity.Database.SqlQuery<AssemblyLineproductionStatusModel>(
                        "exec [SPPackaginglineProductionStatus] @projectId, @fromDate,@toDate", targetproject,
                        targetdatefrom, targetdateto).ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;


            return list;
        }

        public DataTable GetRepairAndSolderingReport(string fromdate, string todate, int projectId)
        {
            var table = new DataTable();
            using (
                var con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["adoWcmsfactoryserver"].ConnectionString))
            {

                //using (var cmd = new SqlCommand("usp_GetABCD", con))
                con.Open();
                using (var cmd = new SqlCommand("SPRepairAndSolderingInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;
                    cmd.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;
                    if (projectId == 0)
                        cmd.Parameters.Add("@projectId", SqlDbType.VarChar).Value = (object) DBNull.Value;
                    else
                    {
                        cmd.Parameters.Add("@projectId", SqlDbType.VarChar).Value = Convert.ToInt64(projectId);
                    }

                    using (var da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(table);
                    }
                }
                con.Close();


            }
            //foreach (DataColumn dc in table.Columns)
            //{


            //    var str = dc.ColumnName;

            //    if (str != "IssueName" && str != "FailedStation")
            //    {
            //        var projectIds = Convert.ToInt64(str.Substring(7)); //key.slice(-3);


            //        var projectName =
            //            _wcmsCellPhoneProjectEntities.ProjectMasters.FirstOrDefault(x => x.ProjectMasterId == projectId);

            //        var linename = str.Substring(0, str.Length - 3);

            //        dc.ColumnName = linename + (projectName.ProjectName).Substring(6) + "-" + projectName.OrderNuber;
            //    }
            //}
            //table.AcceptChanges();
            ////var t = table.AsEnumerable().Select(r =>.Field<string>("Description")).ToList();

            //var filter = table.AsEnumerable().Where(x => x.Field<string>("FailedStation") == "FUQC").CopyToDataTable(); ;




            return table;
        }

        public List<AgingQcStationModel> GetAgingReport(DateTime fromdate, DateTime todate, long? project)
        {
            List<AgingQcStationModel> list;
            var startDate = fromdate;

            var endDate = todate;
            var toDate = endDate.AddDays(1).AddTicks(-1);
            try
            {

                if (project == null || project == 0)
                {
                    list = (from ag in _entity.tblAgingMaster
                        //join log in _entity.tblLogin on ag.AddedBy equals log.AddedBy
                        where ag.AddedDate >= startDate && ag.AddedDate <= toDate

                        select new AgingQcStationModel
                        {

                            ProjectName = ag.ProjectName,
                            MobileCode = ag.MobileCode,
                            AgingBatch = ag.AgingBatch,
                            AgingPass = ag.AgingPassed,
                            AgingIssue = ag.AgingIssue,
                            AgingReworked = ag.Reworked == true ? "YES" : "NO",
                            //CheckedBy = log.EmployeeName + "-" + log.EmployeeId

                        }).AsNoTracking().ToList();

                }

                else
                {
                    list = (from ag in _entity.tblAgingMaster
                        //join log in _entity.tblLogin on ag.AddedBy equals log.AddedBy
                        where ag.AddedDate >= startDate && ag.AddedDate <= toDate && ag.ProjectId == project

                        select new AgingQcStationModel
                        {

                            ProjectName = ag.ProjectName,
                            MobileCode = ag.MobileCode,
                            AgingBatch = ag.AgingBatch,
                            AgingPass = ag.AgingPassed,
                            AgingIssue = ag.AgingIssue,
                            AgingReworked = ag.Reworked == true ? "YES" : "NO",
                            // CheckedBy = log.EmployeeName + "-" + log.EmployeeId

                        }).AsNoTracking().ToList();
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<AgingChargingModel> GetChargerAgingReport(DateTime fromdate, DateTime todate, long? project)
        {
            List<AgingChargingModel> list;
            var startDate = fromdate;

            var endDate = todate;
            var toDate = endDate.AddDays(1).AddTicks(-1);
            try
            {

                if (project == null || project == 0)
                {
                    list = (from ag in _entity.tblChargerMaster
                        //join log in _entity.tblLogin on ag.AddedBy equals log.AddedBy
                        where ag.AddedDate >= startDate && ag.AddedDate <= toDate

                        select new AgingChargingModel
                        {

                            ProjectName = ag.ProjectName,
                            MobileCode = ag.MobileCode,
                            ChargerBatch = ag.ChargingBatch,
                            ChargingPass = ag.ChargingPassed,
                            ChargingIssue = ag.ChargingIssue,
                            ChargingReworked = ag.Reworked == true ? "YES" : "NO",
                            //CheckedBy = log.EmployeeName + "-" + log.EmployeeId

                        }).AsNoTracking().ToList();

                }

                else
                {
                    list = (from ag in _entity.tblChargerMaster
                        //join log in _entity.tblLogin on ag.AddedBy equals log.AddedBy
                        where ag.AddedDate >= startDate && ag.AddedDate <= toDate && ag.ProjectId == project

                        select new AgingChargingModel
                        {

                            ProjectName = ag.ProjectName,
                            MobileCode = ag.MobileCode,
                            ChargerBatch = ag.ChargingBatch,
                            ChargingPass = ag.ChargingPassed,
                            ChargingIssue = ag.ChargingIssue,
                            ChargingReworked = ag.Reworked == true ? "YES" : "NO",
                            // CheckedBy = log.EmployeeName + "-" + log.EmployeeId

                        }).AsNoTracking().ToList();
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<PackagingOQCModel> GetOQCDetailsReport(DateTime fromdate, DateTime todate, long? project)
        {
            List<PackagingOQCModel> list = null;
            var startDate = fromdate;

            var endDate = todate;
            var toDate = endDate.AddDays(1).AddTicks(-1);
            try
            {

                if (project == null || project == 0)
                {
                    list = (from oqc in _entity.tblOqcCheckedItems
                        join imei in _entity.tblIMEIRecord on oqc.Imei1 equals imei.IMEI1
                        where oqc.AddedDate >= startDate && oqc.AddedDate <= toDate
                        orderby imei.Model

                        select new PackagingOQCModel
                        {

                            Model = imei.Model,
                            Project = imei.Project,
                            Color = imei.Color,
                            Imei1 = oqc.Imei1,
                            Imei2 = oqc.Imei2,
                            Status = oqc.OqcStatus == "P" ? "PASSED" : "FAILED",
                            Issues = oqc.Issues,
                            AddedDate = oqc.AddedDate


                        }).AsNoTracking().ToList();

                }

                //else
                //{
                //    list = (from ag in _entity.tblChargerMaster
                //            //join log in _entity.tblLogin on ag.AddedBy equals log.AddedBy
                //            where ag.AddedDate >= startDate && ag.AddedDate <= toDate && ag.ProjectId == project

                //            select new AgingChargingModel
                //            {

                //                ProjectName = ag.ProjectName,
                //                MobileCode = ag.MobileCode,
                //                ChargerBatch = ag.ChargingBatch,
                //                ChargingPass = ag.ChargingPassed,
                //                ChargingIssue = ag.ChargingIssue,
                //                ChargingReworked = ag.Reworked == true ? "YES" : "NO",
                //                // CheckedBy = log.EmployeeName + "-" + log.EmployeeId

                //            }).AsNoTracking().ToList();
                //}




            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public static string DateString()
        {
            var dateStr = "";
            var month = DateTime.Now.ToString("MMM");

            var day = DateTime.Now.ToString("dd");
            var year = DateTime.Now.ToString("yy");

            dateStr = day + "-" + month + "-" + year;
            return dateStr;
        }

        public static string DateString2()
        {
            var dateStr = "";
            var month = DateTime.Now.ToString("MM");

            var day = DateTime.Now.ToString("dd");
            var year = DateTime.Now.ToString("yyyy");
            string time = DateTime.Now.ToString("hh:mm:ss tt");

            dateStr = month + "/" + day + "/" + year+" "+ time;

            return dateStr;

        }




        public bool CheckAndUploadImeiToOracle(DateTime fromdate, DateTime todate, string model, string color,
            int quantity, List<ImeiModelUpload> list, string oracletranscationCode)
        {

            int inventoryitemId = 0;
            object jobId = null;
            object stockQuantity = null;
            var startDate = fromdate;

            var endDate = todate;
            var toDate = endDate.AddDays(1).AddTicks(-1);

            // _entity.Database.Connection.Open();

            //var list = _entity.tblLogistics.Where(x => x.Model == model && (x.AddedDate >= startDate && x.AddedDate <= toDate) && x.Color == color).AsNoTracking().ToList();

            //_entity.Dispose();

            //oracle Connection Open  

            var connection = OracleDatabaseConnection.GetOldConnection();
            var pushconnection = OracleDatabaseConnection.GetImeiOracleConnection();
            OracleDataReader oracleDataReader = null;
            OracleDataReader oracleDataReader1 = null;
            OracleDataReader oracleDataReader2 = null;
            connection.Open();

            //var list = _entity.tblLogistics.Where(x => x.Model == model && (x.AddedDate >= startDate && x.AddedDate <= toDate) && x.Color == color).AsNoTracking().ToList();
            // Item master query 
            var itemMasterQuery = @"SELECT MSI.CREATION_DATE, MSI.ORGANIZATION_ID, MSI.INVENTORY_ITEM_ID ,
                                    MSI.SEGMENT1 || '.' || MSI.SEGMENT2 || '.' || MSI.SEGMENT3 ITEM_CODE,   MSI.DESCRIPTION ITEM_NAME,
                                    MSI.PRIMARY_UOM_CODE UOM,   MCB.SEGMENT1,    MCB.SEGMENT2,    MCB.SEGMENT3,     MCB.SEGMENT4,    MCB.SEGMENT5, MSI.ATTRIBUTE5 ITEM_COLOR
                                    FROM MTL_SYSTEM_ITEMS MSI,   MTL_ITEM_CATEGORIES MIC,   MTL_CATEGORIES_B MCB
                                    WHERE    MIC.CATEGORY_SET_ID = 1100000041 
                                    AND MSI.INVENTORY_ITEM_ID = MIC.INVENTORY_ITEM_ID
                                    AND MSI.ORGANIZATION_ID = MIC.ORGANIZATION_ID
                                    AND MIC.CATEGORY_ID = MCB.CATEGORY_ID
                                    AND MSI.INVENTORY_ITEM_STATUS_CODE='Active'
                                    AND MCB.SEGMENT1 = 'FINISHED GOODS'   AND MSI.ORGANIZATION_ID=646 
                                    AND LOWER(MCB.SEGMENT5)='" + model.ToLower() +
                                  "' AND LOWER(MSI.DESCRIPTION) LIKE '%" + color.ToLower() + "%'";

            var oracleCommand = new OracleCommand(itemMasterQuery, connection) {CommandType = CommandType.Text};

            oracleDataReader = oracleCommand.ExecuteReader();

            if (oracleDataReader.HasRows)
            {

                while (oracleDataReader.Read())
                {


                    inventoryitemId = Convert.ToInt32(oracleDataReader["INVENTORY_ITEM_ID"]);


                }
            }
            oracleDataReader.Dispose();
            oracleDataReader.Close();
            connection.Close();
            connection.Dispose();

            //Insert Data To Oracle 
            //Insert Data To Oracle 


            //  _entity.Database.Connection.Open();
            //**GET THE LIST **//
            //_entity.Dispose();
            //            var entity1 = new WCMSEntities();
            //entity1.Database.Connection.Open();
            //            var list = entity1.tblLogistics.Where(x => x.Model == model && (x.AddedDate >= startDate && x.AddedDate <= toDate) && x.Color == color).AsNoTracking().ToList();
            //            entity1.Dispose();

            var commoDALGetCommonSelecting = new DALGetCommonSelecting();
            var oracleUploadList = new List<OracleUploadEntity>();
            pushconnection.Open();
            foreach (var items in list)
            {

                var checkDuplcate = @"SELECT COUNT(1) FROM APPS.XX_PRODUCTION_ENTRY WHERE SERIAL_NO='" + items.Imei1 + "'";
                var oracldupCommand = new OracleCommand(checkDuplcate, pushconnection) { CommandType = CommandType.Text };
                var res = oracldupCommand.ExecuteScalar();

                //if (oracleDataReader1.HasRows)
                //{

                //    while (oracleDataReader1.Read())
                //    {


                //        jobId = (oracleDataReader1["SERIAL_NO"]).ToString();


                //    }
                //}

                if (Convert.ToInt32(res)==0)
                {
                    var oracleUploadItems = new OracleUploadEntity();

                    oracleUploadItems.SequenceId = DateTime.Now.Ticks;

                    oracleUploadItems.OrganizationId = 646;

                    oracleUploadItems.TranscationDate = DateString();


                    oracleUploadItems.EbsItemId = inventoryitemId;

                    oracleUploadItems.ItemModel = items.Model;

                    oracleUploadItems.ItemColor = items.Color;


                    var versionString = items.WO;


                    var index = versionString.IndexOf("_", versionString.IndexOf("_", versionString.IndexOf("_") + 1) + 1);

                    var version = versionString.Substring(0, index);

                    oracleUploadItems.ItemVersion = version + "_" + oracletranscationCode;

                    oracleUploadItems.JobId = null;

                    oracleUploadItems.SeriaNo = items.Imei1;

                    oracleUploadItems.ImpFlag = 0;

                    oracleUploadItems.ImpReference = null;

                    oracleUploadItems.CreatedBy = "WCMS";

                    oracleUploadItems.CreationDate = Convert.ToDateTime(String.Format("{0:G}", DateTime.Now)); ;// DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

                    oracleUploadItems.LastUpdatedBy = "WCMS";

                    oracleUploadItems.LastDateUpdatedDate = DateTime.Now; //DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

                    oracleUploadItems.Remarks = "Logistics-Uploaded";

                    oracleUploadItems.DataSource = "WCMS";

                    oracleUploadList.Add(oracleUploadItems);
                }





                    
                }


            
           

            pushconnection.Close();
           // pushconnection.Dispose();
            bool returnValue = false;
                try
                {
                    
                    pushconnection.Open();
                    //OracleTransaction transaction = pushconnection.BeginTransaction();
                    // Assign transaction object for a pending local transaction
                  
                    string query =
                        @"insert into APPS.XX_PRODUCTION_ENTRY (SEQ_ID,ORG_ID, TRAN_DATE,EBS_ITEM_ID,ITEM_MODEL,ITEM_COLOR,ITEM_VERSION,JOB_ID,SERIAL_NO,IMP_FLAG,IMP_REF,CREATED_BY,CREATION_DATE,LAST_UPDATE_BY,LAST_UPDATE_DATE,REMARKS,DATA_SOURCE )
                                  values (:seqId,:orgId, :tranDate, :ebsItemId,:itemModel,:itemColor,:itemVersion,:jobId,:serialNo,:impFlag,:impRef,:createdBy,:createdDate,:lastUpdateBy,:lastUpdateDate,:remarks,:dataSource)";
                  


                    using (var command = pushconnection.CreateCommand())
                    {
                        //command.Transaction = transaction;

                        command.CommandText = query;
                        command.CommandType = CommandType.Text;
                        command.BindByName = true;
                        // In order to use ArrayBinding, the ArrayBindCount property
                        // of OracleCommand object must be set to the number of records to be inserted
                        command.ArrayBindCount = oracleUploadList.Count;
                        command.Parameters.Add(":seqId", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.SequenceId).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":orgId", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.OrganizationId).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":tranDate", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.TranscationDate).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":ebsItemId", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.EbsItemId).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":itemModel", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.ItemModel).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":itemColor", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.ItemColor).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":itemVersion", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.ItemVersion).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":jobId", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.JobId).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":serialNo", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.SeriaNo).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":impFlag", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.ImpFlag).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":impRef", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.ImpReference).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":createdBy", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.CreatedBy).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":createdDate", OracleDbType.Date,
                            oracleUploadList.Select(c => c.CreationDate).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":lastUpdateBy", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.LastUpdatedBy).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":lastUpdateDate", OracleDbType.Date,
                            oracleUploadList.Select(c => c.LastDateUpdatedDate).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":remarks", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.Remarks).ToArray(), ParameterDirection.Input);
                        command.Parameters.Add(":dataSource", OracleDbType.Varchar2,
                            oracleUploadList.Select(c => c.DataSource).ToArray(), ParameterDirection.Input);


                        if (oracleUploadList.Count > 0)
                        {
                            int result = command.ExecuteNonQuery();
                            if (result == oracleUploadList.Count)
                            {
                                // transaction.Commit();
                                returnValue = true;
                                pushconnection.Close();
                            }

                            else
                            {
                                // transaction.Rollback();
                                pushconnection.Close();
                            }
                        }
                        else
                        {
                            returnValue = true;
                            pushconnection.Close();
                        }

                        
                    }


                }
                catch (OracleException ex)
                {

                    //Log error thrown
                }
                finally
                {
                    pushconnection.Close();
                    _entity.Database.Connection.Close();
                }
                return returnValue;

            }

        public List<ImeiModelUpload> GetLogisticsDataToUploadOracle(DateTime fromdate, DateTime todate, string model, string color)
        {
            List<ImeiModelUpload> list;
            DateTime startDate = fromdate;

            DateTime endDate = todate;
            DateTime toDate = endDate.AddDays(1).AddTicks(-1);

            try
            {
                list = (from imeiRecord in _entity.tblIMEIRecord
                        join logistics in _entity.tblLogistics on imeiRecord.IMEI1 equals logistics.Imei1
                        where
                            (logistics.AddedDate >= startDate && logistics.AddedDate <= toDate) && logistics.Model == model &&
                            logistics.Color == color

                        select new ImeiModelUpload
                        {

                            Model = logistics.Model,
                            Color = logistics.Color ?? "",
                            Imei1 = logistics.Imei1,
                            Imei2 = logistics.Imei2,
                            WO = imeiRecord.WO,
                            PrintDate = logistics.AddedDate,

                        }).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }






            return list;
        }
    }
    }

