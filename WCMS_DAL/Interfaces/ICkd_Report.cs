using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_ENTITY.CustomModelEntity;

namespace WCMS_DAL.Interfaces
{
    public interface ICkd_Report
    {
        List<CkdModel> DisplayPassFailCount(string date);
        List<CkdModel> GetCkdReport(string date, string Model);
        List<CkdModel> GetCkdMmiReportInfo(string date, string model);
        List<CkdModel> GetCkdSmtReportInfo(string date, string model);
        List<CkdModel> GetCkdSoftwareLoadReportInfo(string date, string model);
        List<CkdModel> GetCkdRfReportInfo(string date, string model);
    }
}
