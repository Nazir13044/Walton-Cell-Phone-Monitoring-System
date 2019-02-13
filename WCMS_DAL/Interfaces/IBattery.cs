using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_ENTITY;

namespace WCMS_DAL.Interfaces
{
   public interface IBattery
    {
        bool InsertBatteryComponentInfo(WCMS_ENTITY.tblBatteryComponentInfo batteryComponent);
       List<tblBatteryComponentInfo> GetListByPcbIssue();


       
       List<tblBatteryComponentInfo> GetLineListById(int id);
       bool UpdateBatteryLine(tblBatteryComponentInfo productionLine);
       bool DeleteProductionLine(int id);
       bool InsertProductionLine(tblBatteryComponentInfo productionLine);
       List<tblBatteryComponentInfo> ProjectNameExist(tblBatteryComponentInfo tblLineSetup);
    }
}
