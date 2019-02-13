using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_ENTITY;

namespace WCMS_DAL.Interfaces
{
    public interface ICKD
    {

        bool InsertCkdMmiComponentInfo(tblCkdMmiMaster mmItabltestComponent);

        List<tblCkdMmiMaster> GetCkdMmiMasterInfo(WCMS_ENTITY.tblCkdMmiMaster tblCkdMmiMaster);

        bool UpdateCkdMmiInfo(tblCkdMmiMaster mmItabltestComponent);
        bool InsertCkdSmtComponentInfo(WCMS_ENTITY.tblCkdSmtMaster smtTableTestComponent);
        List<tblCkdSmtMaster> GetCkdSmtMasterInfo(WCMS_ENTITY.tblCkdSmtMaster tblCkdSmtMaster);


        bool UpdateCkdSmtInfo(tblCkdSmtMaster smtTableTestComponent);
        bool InsertRfStationInformation(WCMS_ENTITY.tblCkdRfMaster rfTableTestComponent);
        List<tblCkdRfMaster> GetCkdRfMasterInfo(WCMS_ENTITY.tblCkdRfMaster tblCkdRfMaster);
        bool UpdateCkdRfInfo(tblCkdRfMaster rfTableTestComponent);
        bool InsertSoftwareLoadStationInformation(WCMS_ENTITY.tblCkdSoftwareLoadMaster softwareLoadTableTestComponent);
        List<tblCkdSoftwareLoadMaster> GetCkdSoftwareLoadMasterInfo(WCMS_ENTITY.tblCkdSoftwareLoadMaster tblCkdSoftwareLoadMaster);
        bool UpdateCkdSoftwareLoadInfo(tblCkdSoftwareLoadMaster softwareLoadTableTestComponent);

        List<tblCkdSoftwareLoadMaster> GetSoftwareLoadQrCount();

        List<tblCkdSmtMaster> GetSmtQrCount();



        
        bool InsertCkdRework(tblCkdRework rework);
        List<tblCkdRfMaster> GetRfQrCount();
        List<tblCkdMmiMaster> GetMmiQrCount();
        List<tblCkdSmtMaster> GetAnyParaMeterInfo(tblCkdSmtMaster tblCkdSmtMaster);
        List<tblCkdIssues> GetAllIssueList();
    }
}
