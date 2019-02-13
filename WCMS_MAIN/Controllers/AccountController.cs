using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BR_BLL;
using WcfService2.Services;
using WCMS_COMMON;
using WCMS_ENTITY;
using WCMS_MAIN.HelperClass;
using WCMS_MAIN.Models;
using TransactionScope = System.Activities.Statements.TransactionScope;

namespace WCMS_MAIN.Controllers
{
    public class AccountController : Controller
    {
        CommonService _CommonService = new CommonService();
        readonly AdminService _adminService = new AdminService();
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogIn()
        {
           // String userIdentity = System.Web.HttpContext.Current.User.Identity.Name;
            //long userId = Convert.ToInt64(userIdentity == "" ? "0" : userIdentity);


            //FormsAuthentication.SignOut();
            // String Name =Page.User.Identity.Name;
            // HttpContext.Current.Page.User.Identity.Name = null;
            Session.Clear();
            Session.Abandon();
            var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            Response.Cookies.Add(cookie1);
            var cookie2 = new HttpCookie("ASP.NET_SessionId", "") { Expires = DateTime.Now.AddYears(-1) };
            Response.Cookies.Add(cookie2);
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LoginModel login)
        {


            if (ModelState.IsValid) //validating the user inputs
            {
                bool isExist = false;
                using (var _entity = new WCMSEntities())  // 
                {
                    isExist = _entity.tblLogin.Any(x => x.UserName.Trim().ToLower() == login.UserName.Trim().ToLower() && x.Password==login.Password); //validating the user name in tblLogin table whether the user name is exist or not
                    if (isExist)
                    {
                        LoginModel loginCredentials = _entity.tblLogin.Where(x => x.UserName.Trim().ToLower() == login.UserName.Trim().ToLower()).Select(x => new LoginModel
                        {
                            UserName = x.UserName,
                            RoleName = x.tblRoles.Roles,
                            UserRoleId = (int?) x.RoleId,
                            PackLineId = (int?)x.LineId,
                            UserId = x.Id,
                            UserLineId =x.LineId,
                            EmployeeName=x.EmployeeName
                        }).FirstOrDefault();  // Get the login user details and bind it to LoginModels class
                        List<MenuModel> menus = _entity.tblSubMenu.Where(x => x.RoleId == loginCredentials.UserRoleId && x.IsMenue==true).Select(x => new MenuModel
                        {
                            MainMenuId = x.tblMainMenu.Id,
                            MainMenuName = x.tblMainMenu.MainMenu,
                            SubMenuId = x.Id,
                            SubMenuName = x.SubMenu,
                            ControllerName = x.Controller,
                            ActionName = x.Action,
                            RoleId = x.RoleId
                            //RoleName = x.RoleName
                        }).ToList(); //Get the Menu details 

                        List<MenuModel> permissions = _entity.tblSubMenu.Where(x => x.RoleId == loginCredentials.UserRoleId || x.RoleId==0).Select(x => new MenuModel
                        {
                            MainMenuId = x.tblMainMenu.Id,
                            MainMenuName = x.tblMainMenu.MainMenu,
                            SubMenuId = x.Id,
                            SubMenuName = x.SubMenu,
                            ControllerName = x.Controller,
                            ActionName = x.Action,
                            RoleId = x.RoleId
                            //RoleName = x.RoleName
                        }).ToList(); //Get the Menu details 



                        FormsAuthentication.SetAuthCookie(loginCredentials.UserName, false); // set the formauthentication cookie

                        System.Web.HttpContext.Current.Session["WCMSLoginUserName"] = login.UserName;
                        DateTime startDate = DateTime.Today;
                        DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                        var getLiness = _entity.tblAssemblyLineSetup.Where(x => x.AssemblyLineId == loginCredentials.UserLineId && x.AddedDate >= startDate && x.AddedDate <= endDate).ToList();
                        var getLines = getLiness.OrderByDescending(a => a.AddedDate).FirstOrDefault();

                         var projectId = getLines != null ? getLines.ProjectId : 0;
                         var projectName = getLines != null ? getLines.ProjectName : "";

                         var lineId = getLines != null ? getLines.AssemblyLineId : loginCredentials.UserLineId;

                        Session["LoginCredentials"] = loginCredentials; //
                        Session["MenuMaster"] = menus; //
                        Session["permissions"] = permissions; //
                        Session["UserName"] = loginCredentials.UserName;
                        Session["EmpName"] = loginCredentials.EmployeeName;
                       // Session["ProjectId"] = _entity.tblAssemblyLineSetup.Where(x => x.AssemblyLineId == _loginCredentials.UserLineId) .Select(a => a.ProjectId);
                        //System.Web.HttpContext.Current.Session["WCMSLoginUserId"] = _loginCredentials.UserId;
                        System.Web.HttpContext.Current.Session["WCMSUserRoleId"] = loginCredentials.UserRoleId;
                        System.Web.HttpContext.Current.Session["WCMSUserRoleName"] = loginCredentials.RoleName;
                        System.Web.HttpContext.Current.Session["WCMSUserId"] = loginCredentials.UserId;
                        System.Web.HttpContext.Current.Session["WCMSProjectId"] = projectId;
                        System.Web.HttpContext.Current.Session["WCMSProjectName"] = projectName;
                        System.Web.HttpContext.Current.Session["WCMSLineId"] = lineId;
                        System.Web.HttpContext.Current.Session["WCMSPackLineId"] = loginCredentials.PackLineId;


                        var loginRoleName = loginCredentials.RoleName.ToLower();
                        var loginRoleId = loginCredentials.UserRoleId;
                        var workerHomePage = permissions.FirstOrDefault(a => a.RoleId == loginRoleId);


                        if (loginRoleId == 21)
                        {
                            if (workerHomePage != null)
                            return RedirectToAction("" + workerHomePage.ActionName + "", "" + workerHomePage.ControllerName + "");
                        }



                        //if (projectId == 0 && loginRoleId != 1 && loginRoleId != 9 && loginRoleId != 4 && loginRoleId != 10 && loginRoleId != 5 && loginRoleId != 6 && loginRoleId != 7 && loginRoleId != 15 && loginRoleId != 16 && loginRoleId != 17 && loginRoleId != 18 && loginRoleId != 19 && loginRoleId != 20)

                        if (projectId == 0 && loginRoleId == 12 )
                        
                        {
                            ViewBag.ErrorMsg = "No Active Project !! Please Add a Project!";
                            return View();
                        }

                        if (projectId == 0 &&loginCredentials.UserRoleId == 9)
                        {

                            return RedirectToAction("UserDashboard", "Home");

                        }

                        if (projectId == 0 &&loginCredentials.UserRoleId == 1)
                        {

                            return RedirectToAction("Dashboard", "Home");

                        }




                        if ((projectId == 0 || projectId != 0) && loginRoleId != 12)
                        {
                            if (workerHomePage != null)
                                return RedirectToAction("" + workerHomePage.ActionName + "", "" + workerHomePage.ControllerName + "");
                        }
                        if ((projectId != 0) && loginRoleId== 12)
                        {
                            if (workerHomePage != null)
                                return RedirectToAction("" + workerHomePage.ActionName + "", "" + workerHomePage.ControllerName + "");
                        }
                        //if (projectId == 0 && (!loginRoleName.StartsWith("admin") && !loginRoleName.StartsWith("line")))
                        //{
                        //    ViewBag.ErrorMsg = "No Active Project !! Please add a project!";
                        //    return View();

                        //}

                        //if (loginCredentials.UserName != "admin")
                        //{

                        //    return RedirectToAction("UserDashboard", "Home");
                           
                        //}

                        //else
                        //{
                        //    return RedirectToAction("Dashboard", "Home");
                        //}
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Please enter the valid credentials!";
                        return View();
                    }
                }
            }
            return View();

            //return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {

            //Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            //long userId = (long)IDictionary[3].Id;
            //var _CommonService = new CommonService();
            //var result = _CommonService.UpdateLastEntry(userId);

            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            FormsAuthentication.SignOut();
            var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "") {Expires = DateTime.Now.AddYears(-1)};
            Response.Cookies.Add(cookie1);
            var cookie2 = new HttpCookie("ASP.NET_SessionId", "") {Expires = DateTime.Now.AddYears(-1)};
            Response.Cookies.Add(cookie2);
            return RedirectToAction("LogIn");
        }

        
        public ActionResult CreateEmployee()
        
        {
            return View();

        }

        public ActionResult EmployeeList()
        {
            return View();

        }

        [HttpPost]
        public JsonResult GetRegisterdeEmployee()

     {
            //long userId = (long)IDictionary[2].Id;

            var list = _CommonService.GetRegisterdeEmployee().ToList();


         var   news = new List<tblLogin>();

            foreach (var item in list)
            {

                var test = new tblLogin();

                test.EmployeeName = item.EmployeeName;
                test.EmployeeId = item.EmployeeId;
                test.UserName = item.UserName;
                test.RoleName = item.RoleName;
                test.LineName = item.LineName;
                news.Add(test);
            }




            return Json(new { data = news }, JsonRequestBehavior.AllowGet);

        }


        //get employee information autocompete 

        public JsonResult GetEmployeeList(string term)
        {
            var eList = new List<Employee>();
            try
            {
                eList = _CommonService.GetEmployeeList(term).ToList(); 
            }
            catch (Exception ex)
            {
                //_ErrorHelper.ErrorProcess(ex);
            }
            var objstate = eList.Select(x => new { value = x.Name, Id = x.EmployeeId,designation=x.Designation,moble=x.MobileNumber,department=x.Department,departmentId=x.DepartmentId,sectionId=x.SectionId }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }

        //get employee information autocompete 

        [HttpPost]
        public JsonResult CreateEmployee(WCMS_ENTITY.EmployeeInfo employee, tblLogin login)
        {
           
            Result _Result = new Result();
            Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            long UserId = (long)IDictionary[2].Id;
            //Employee employees = new Employee();

                try
                {
                    var existingUserEmployee = _CommonService.GetEmployeeByID(new WCMS_ENTITY.EmployeeInfo() { EmployeeId = employee.EmployeeId });

                    if (existingUserEmployee.Count == 0)

                    {
                         employee.AddedBy = UserId;
                         employee.AddedDate =DateTime.Now;
                        _Result = _CommonService.InsertEmployeeInfo(employee, login);
                    }
                    else
                    {
                        _Result.Message = "User Already Exists";
                    }
                }
                catch (Exception ex)
                {
                    return Json("Error");
                }
            return Json(_Result);
        }
        
        public ActionResult ChangePassword()
        {

            return View();

        }

        [HttpPost]
        public JsonResult UpdatePassword(tblLogin login, string newPassword)
        {

            Result _Result = new Result();
            Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            int UserId = (int)IDictionary[2].Id;

            var checkLoginUser = _CommonService.GetLoginUser(new tblLogin() { Id = UserId, Password = login.Password });
            if (checkLoginUser.Count != 0)
            {
                login.Id = UserId;
                _Result = _CommonService.UpdateLoginUser(login, newPassword);
            }
            else
            {
                _Result.Message = "Invalid User Credentials";
            }
            return Json(_Result);
        }




        public JsonResult GetAllUserRoleNames()
        {
            List<tblRoles> list = new List<tblRoles>();
            try
            {
                list = _adminService.GetUserRoleNames().ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.Roles, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }


    }
}