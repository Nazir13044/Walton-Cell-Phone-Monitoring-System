using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCMS_ENTITY;

namespace WCMS_DAL.Interfaces
{
    public interface IAdmin
    {
        bool InsertRoles(tblRoles roles);

        bool InsertMainMenu(tblMainMenu tblMainMenu);

        List<tblMainMenu> GetMainMenusNames();

        List<tblRoles> GetUserRoleNames();

        bool InsertSubMenu(tblSubMenu tblSubMenu);

        bool InsertProductionLine(tblProductionLine productionLine);

        List<tblProductionLine> GetLineList();

        List<tblProductionLine> GetLineListById(int id);

        bool UpdateProductionLine(tblProductionLine productionLine);

        bool DeleteProductionLine(int id);

        bool InsertProductionLineSetup(tblAssemblyLineSetup assemblyLine);

        bool InsertProductionLineSetupDetails(tblAssemblyLineSetupDetails tblAssemblyLineSetupDetails);

        bool UpdateUserLineInfo(tblLogin assemblyLine);

        bool InsertLineStatus(tblLineStatus lineStatus);

        List<tblLineStatus> GetLinesStausList();
    }
}
