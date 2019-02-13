using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BR_BLL;
using WCMS_COMMON;
using WCMS_DAL.Inserting;
using WCMS_DAL.Interfaces;
using WCMS_DAL.Selecting;
using WCMS_ENTITY;

namespace WCMS_BLL.Manager
{
    public class AdminManager
    {
        public Result InsertRoles(tblRoles roles)
        {
            try
            {
              IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.InsertRoles(roles);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public Result InsertMainMenu(tblMainMenu tblMainMenu)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.InsertMainMenu(tblMainMenu);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblMainMenu> GetMainMenusNames()
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                return iAdmin.GetMainMenusNames();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblRoles> GetUserRoleNames()
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                return iAdmin.GetUserRoleNames();
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertSubMenu(tblSubMenu tblSubMenu)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.InsertSubMenu(tblSubMenu);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertProductionLine(tblProductionLine productionLine)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.InsertProductionLine(productionLine);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblProductionLine> GetLineList()
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                return iAdmin.GetLineList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblProductionLine> GetLineListById(int id)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                return iAdmin.GetLineListById(id);
            }
            catch (Exception ex) { throw ex; }
        }

        public Result UpdateProductionLine(tblProductionLine productionLine)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.UpdateProductionLine(productionLine);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Result DeleteProductionLine(int id)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.DeleteProductionLine(id);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertProductionLineSetup(tblAssemblyLineSetup assemblyLine)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.InsertProductionLineSetup(assemblyLine);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertProductionLineSetupDetails(tblAssemblyLineSetupDetails tblAssemblyLineSetupDetails)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.InsertProductionLineSetupDetails(tblAssemblyLineSetupDetails);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Result UpdateUserLineInfo(tblLogin assemblyLine)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    Result _Result = new Result();
                    _Result.IsSuccess = iAdmin.UpdateUserLineInfo(assemblyLine);

                    if (_Result.IsSuccess)
                        transaction.Complete();
                    return _Result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Result InsertLineStatus(tblLineStatus lineStatus)
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, ApplicationState.TransactionOptions))
                {
                    var result = new Result();

                   
                    result.IsSuccess = iAdmin.InsertLineStatus(lineStatus);

                    if (result.IsSuccess)
                        transaction.Complete();
                    return result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<tblLineStatus> GetLinesStausList()
        {
            try
            {
                IAdmin iAdmin = new WCMS_DAL_Admin();
                return iAdmin.GetLinesStausList();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
