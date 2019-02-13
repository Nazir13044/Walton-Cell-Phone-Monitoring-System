using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCMS_ENTITY;
using WCMS_COMMON;
using WCMS_ENTITY.CustomModelEntity;


namespace WCMS_DAL.Interfaces
{
    public interface IInsertingSetupCommon
    {
        bool InsertEmployeeInfo(EmployeeInfo employee);
        bool InsertProjectBomList(ProjectBomList oProjectBomList);
        bool InsertLoginInfo(tblLogin login);

        bool UpdateLoginUser(tblLogin login, string newPassword);

        bool CreateDailyPackagingList(tblDailyPacking oDailyPacking);

        bool InsertComponentRequisition(tblComponentRequisition componentRequisition);

        bool UpdateComponentRequisitionList(tblAssemblyLineSetupDetails tblAssemblyLineSetupDetails);

        bool InsertBomList(BomList bomLists);

        bool InsertIssuedComponents(tblDailyIssuedComponents issuedComponents);

        bool InsertScrewStationInfo(tblScrew screw);

        bool InsertLogisticsSendData(List<tblLogisticsSentItems> logisticsSendList);

        bool InsertWareHouseData(List<tblWarehouse> wareHouseData);

        Result InsertModelsImeiData(List<ImeiModelUpload> imeiModelUpload);
    }


}
