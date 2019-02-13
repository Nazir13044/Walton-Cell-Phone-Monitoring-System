using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCMS_DAL.HelperClass;
using WCMS_DAL.Interfaces;
using WCMS_ENTITY;
using WCMS_ENTITY.CustomModelEntity;
using WCMS_MAIN.Models;

namespace WCMS_DAL.Inserting
{
    public class WCMS_DAL_BatteryStation : IBattery
    {
        private readonly WCMSEntities _entity = new WCMSEntities();

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertBatteryComponentInfo(tblBatteryComponentInfo batteryComponent)
        {
            try
            {

                _entity.tblBatteryComponentInfo.Add(batteryComponent);
                _entity.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public List<tblBatteryComponentInfo> GetListByPcbIssue()
        {
            List<tblBatteryComponentInfo> list;
            try
            {
                list = _entity.tblBatteryComponentInfo.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblBatteryComponentInfo> GetLineListById(int id)
        {
            List<tblBatteryComponentInfo> list;
            try
            {
                list = _entity.tblBatteryComponentInfo.Where(x => x.Id == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public bool UpdateBatteryLine(tblBatteryComponentInfo productionLine)
        {
            _entity.Configuration.LazyLoadingEnabled = false;
            tblBatteryComponentInfo list = _entity.tblBatteryComponentInfo.FirstOrDefault(x => x.Id == productionLine.Id);

            if (list != null)
            {
                if (productionLine.ProjectName != "")
                
                list.ProjectName = productionLine.ProjectName;
   
                list.PcbPassed = productionLine.PcbPassed;
           
                list.PcbIssued = productionLine.PcbIssued;
                list.PcbFailed = productionLine.PcbFailed;
                list.CellIssued = productionLine.CellIssued;
                list.CellPassed = productionLine.CellPassed;
                list.CellFailed = productionLine.CellFailed;

                _entity.Entry(list).State = EntityState.Modified;
                _entity.SaveChanges();
            }
           
            else
            {
                return false;
            }
            return true;
        }


        public bool DeleteProductionLine(int id)
        {

            _entity.Configuration.LazyLoadingEnabled = false;

            tblBatteryComponentInfo line = _entity.tblBatteryComponentInfo.Find(id);

            if (line != null)
            {
                _entity.tblBatteryComponentInfo.Remove(line);

                _entity.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;

        }


        public bool InsertProductionLine(tblBatteryComponentInfo productionLine)
        {
            try
            {
                _entity.tblBatteryComponentInfo.Add(productionLine);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<tblBatteryComponentInfo> ProjectNameExist(tblBatteryComponentInfo tblLineSetup)
        {
            List<tblBatteryComponentInfo> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _entity.tblBatteryComponentInfo.Where(a => a.AddedDate >= startDate && a.AddedDate <= endDate && a.ProjectName == tblLineSetup.ProjectName).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }
    }
}
