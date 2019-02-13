using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCMS_DAL.Interfaces;
using WCMS_COMMON;
using WCMS_DAL.Inserting;
using WCMS_DAL.Interfaces;
using WCMS_DAL.Selecting;
using WCMS_ENTITY;
using System.Transactions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WCMS_DAL.Inserting
{
    public class WCMS_DAL_Admin:IAdmin
    {
         private WCMSEntities _entity = new WCMSEntities();
       
        
        
         [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertRoles(tblRoles roles)
        {
            try
            {
                _entity.tblRoles.Add(roles);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
         [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
         [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertMainMenu(tblMainMenu tblMainMenu)
        {
            try
            {
                _entity.tblMainMenu.Add(tblMainMenu);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<tblMainMenu> GetMainMenusNames()
        {
            List<tblMainMenu> list;
            try
            {
                list = _entity.tblMainMenu.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblRoles> GetUserRoleNames()
        {
            List<tblRoles> list;
            try
            {
                list = _entity.tblRoles.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertSubMenu(tblSubMenu tblSubMenu)
        {
            try
            {
                _entity.tblSubMenu.Add(tblSubMenu);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertProductionLine(tblProductionLine productionLine)
        {
            try
            {
                _entity.tblProductionLine.Add(productionLine);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<tblProductionLine> GetLineList()
        {
            List<tblProductionLine> list;
            try
            {
                list = _entity.tblProductionLine.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<tblProductionLine> GetLineListById(int id)
        {
            List<tblProductionLine> list;
            try
            {
                list = _entity.tblProductionLine.Where(x=>x.LineId==id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public bool UpdateProductionLine(tblProductionLine productionLine)
        {
            _entity.Configuration.LazyLoadingEnabled = false;
            tblProductionLine list = _entity.tblProductionLine.FirstOrDefault(x => x.LineId == productionLine.LineId);


            if (list != null)
            {
                if (productionLine.LineName != "")
                    list.LineName = productionLine.LineName;


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

            tblProductionLine line = _entity.tblProductionLine.Find(id);

            if (line != null)
            {
                _entity.tblProductionLine.Remove(line);

                _entity.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;

        }
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertProductionLineSetup(tblAssemblyLineSetup assemblyLine)
        {
            try
            {
                _entity.tblAssemblyLineSetup.Add(assemblyLine);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertProductionLineSetupDetails(tblAssemblyLineSetupDetails tblAssemblyLineSetupDetails)
        {
            try
            {
                _entity.tblAssemblyLineSetupDetails.Add(tblAssemblyLineSetupDetails);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool UpdateUserLineInfo(tblLogin assemblyLine)
        {
            _entity.Configuration.LazyLoadingEnabled = false;
            tblLogin list = _entity.tblLogin.FirstOrDefault(x => x.Id == assemblyLine.Id);


            if (list != null)
            {
                if (assemblyLine.LineId != 0)
                    list.LineId = assemblyLine.LineId;
                if (assemblyLine.LineName != "")
                    list.LineName = assemblyLine.LineName;
                if (assemblyLine.AddedBy != 0)
                    list.AddedBy = assemblyLine.AddedBy;
                if (assemblyLine.AddedDate != null)
                    list.AddedDate = assemblyLine.AddedDate;
                _entity.Entry(list).State = EntityState.Modified;
                _entity.SaveChanges();
            }
            else
            {
                return false;
            }


            return true;
        }

        public bool InsertLineStatus(tblLineStatus lineStatus)
        {
            try
            {
                _entity.tblLineStatus.Add(lineStatus);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<tblLineStatus> GetLinesStausList()
        {
            List<tblLineStatus> list;
            List<tblLineStatus> list1;
            List<tblLineStatus> list2;
            try

            {
               // list = _entity.tblLineStatus.GroupBy(a => a.LineId).SelectMany(g => g).OrderByDescending(a => a.AddedDate).ToList();


                list = _entity.tblLineStatus.AsEnumerable()
    .OrderByDescending(d => d.AddedDate)
    .GroupBy(d => d.LineId).OrderBy(d=>d.Key)
    .Select(g => g.First())
    .ToList();

                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
    }
}
