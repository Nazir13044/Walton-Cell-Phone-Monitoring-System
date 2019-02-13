using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_DAL.Interfaces
{
    public interface ILcdGlueStation
   
    {
        bool InsertLcdGlueWorkingModels(WCMS_ENTITY.tblLcdGlueWorkingModels workingModel);

        bool UpdateGlueWorkingModels(WCMS_ENTITY.tblLcdGlueWorkingModels workingModel);

        List<WCMS_ENTITY.tblLcdGlueWorkingModels> LoadWorkingModelData();

        WCMS_ENTITY.tblTpLcdMaster GetTpLcdStationInfo(WCMS_ENTITY.tblTpLcdMaster tblTpLcdMaster);

        bool InsertTpLcdStation(WCMS_ENTITY.tblTpLcdMaster tblTpLcdMaster);

        bool InsertTpLcdReworkStation(WCMS_ENTITY.tblLcdGlueRework rework);

        bool UpdateTpLcdStation(WCMS_ENTITY.tblTpLcdMaster tblTpLcdMaster);

        List<WCMS_ENTITY.tblTpLcdMaster> CountTpLcdStationinput();

        List<WCMS_ENTITY.tblLcdGlueRework> GetTpLcdIssuesCount(WCMS_ENTITY.tblLcdGlueRework rework);

        List<WCMS_ENTITY.tblLcdGlueIssuesList> GetAllIssueList();

        WCMS_ENTITY.tblGlueMaster GetGlueStationInfo(WCMS_ENTITY.tblGlueMaster tblGlueMaster);

        bool InsertGlueStation(WCMS_ENTITY.tblGlueMaster tblGlueMaster);

        bool UpdateGlueStation(WCMS_ENTITY.tblGlueMaster tblglueMaster);

        List<WCMS_ENTITY.tblGlueMaster> CountGlueStationinput();

        List<WCMS_ENTITY.CustomModelEntity.ProjectBomMode> CallOracleTest(string model, string color);
    }
}
