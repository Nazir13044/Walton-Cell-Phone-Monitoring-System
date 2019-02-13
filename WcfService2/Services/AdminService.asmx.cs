using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Services;
using WCMS_BLL.Manager;
using WCMS_COMMON;
using WCMS_ENTITY;

namespace WcfService2.Services
{
    /// <summary>
    /// Summary description for AdminService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminService :WebService
    {

        AdminManager adminManager=new AdminManager();


        [WebMethod]
        public Result InsertRoles(tblRoles roles)
        {
            try
            {
                return adminManager.InsertRoles(roles);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public Result InsertMainMenu(tblMainMenu tblMainMenu)
        {
            try
            {
                return adminManager.InsertMainMenu(tblMainMenu);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

     

        [WebMethod]
        public List<tblMainMenu> GetMainMenusNames()
        {
            List<tblMainMenu> _bomList = new List<tblMainMenu>();
            try
            {
                _bomList = adminManager.GetMainMenusNames();
            }
            catch (Exception ex)
            {
               
            }

            return _bomList;
        }



        [WebMethod]
        public List<tblRoles> GetUserRoleNames()
        {
            var list = new List<tblRoles>();
            try
            {
                list = adminManager.GetUserRoleNames();
            }
            catch (Exception ex)
            {

            }

            return list;
        }


        public Result InsertSubMenu(tblSubMenu tblSubMenu)
        {
            try
            {
                return adminManager.InsertSubMenu(tblSubMenu);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }
         [WebMethod]
        public Result InsertProductionLine(tblProductionLine productionLine)
        {
            try
            {
                return adminManager.InsertProductionLine(productionLine);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

       

        [WebMethod]
         public List<tblProductionLine> GetLineList()
        {
            var list = new List<tblProductionLine>();
            try
            {
                list = adminManager.GetLineList();
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return list;
        }

        [WebMethod]
        public List<tblProductionLine> GetLineListById(int id)
        {
            var list = new List<tblProductionLine>();
            try
            {
                list = adminManager.GetLineListById(id);
            }
            catch (Exception ex)
            {
                //if (log.IsErrorEnabled)
                //{
                //    log.Error("Select Region : " + ex.Message);
                //}
            }

            return list;
        }
         [WebMethod]
        public Result UpdateProductionLine(tblProductionLine productionLine)
        {
            try
            {
                return adminManager.UpdateProductionLine(productionLine);
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

         public Result DeleteProductionLine(int id)
         {
             try
             {
                 return adminManager.DeleteProductionLine(id);
             }
             catch (Exception ex)
             {
                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }

         public Result InsertProductionLineSetup(tblAssemblyLineSetup assemblyLine)
         {
             try
             {
                 return adminManager.InsertProductionLineSetup(assemblyLine);
             }
             catch (Exception ex)
             {
                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }

         public Result InsertProductionLineSetupDetails(tblAssemblyLineSetupDetails tblAssemblyLineSetupDetails)
         {
             try
             {
                 return adminManager.InsertProductionLineSetupDetails(tblAssemblyLineSetupDetails);
             }
             catch (Exception ex)
             {
                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }

         public Result UpdateUserLineInfo(tblLogin assemblyLine)
         {
             try
             {
                 return adminManager.UpdateUserLineInfo(assemblyLine);
             }
             catch (Exception ex)
             {
                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }

         public Result InsertLineStatus(tblLineStatus lineStatus)
         {
             try
             {
                 return adminManager.InsertLineStatus(lineStatus);
             }
             catch (Exception ex)
             {
                 return new Result { IsSuccess = false, Message = ex.Message };
             }
         }

       


         [WebMethod]
         public List<tblLineStatus> GetLinesStausList()
         {
             var list = new List<tblLineStatus>();
             try
             {
                 list = adminManager.GetLinesStausList();
             }
             catch (Exception ex)
             {
                 //if (log.IsErrorEnabled)
                 //{
                 //    log.Error("Select Region : " + ex.Message);
                 //}
             }

             return list;
         }
    }
}
