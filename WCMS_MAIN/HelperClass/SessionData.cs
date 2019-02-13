using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCMS_MAIN.HelperClass
{
    public class SessionData
    {
        public  SessionData(long id,string userName)
        {
            Id = id;
            Name = userName;

        }
            public long Id { get; set; }
            public string Name { get; set; }
    
             public static Dictionary<int, SessionData> GetSessionValues()
            {
                Dictionary<int, SessionData> sessionData = new Dictionary<int, SessionData>();
                
                if (HttpContext.Current.Session["WCMSUserRoleId"] == null)
                {
                    SessionData akSessionData = new SessionData(0, "UserRoleId");
                    sessionData.Add(1, akSessionData);
                }
                else
                {
                    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSUserRoleId"].ToString()), "UserRoleId");
                    sessionData.Add(1, aSessionData);
                }

                if (HttpContext.Current.Session["WCMSUserId"] == null)
                {
                    SessionData akSessionData = new SessionData(0, "UserId");
                    sessionData.Add(2, akSessionData);
                }
                else
                {
                    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSUserId"].ToString()), "UserId");
                    sessionData.Add(2, aSessionData);
                }

                if (HttpContext.Current.Session["WCMSProjectId"] == null)
                {
                    SessionData akSessionData = new SessionData(0, "ProjectId");
                    sessionData.Add(3, akSessionData);
                }
                else
                {
                    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSProjectId"].ToString()), "ProjectId");
                    sessionData.Add(3, aSessionData);
                }

                if (HttpContext.Current.Session["WCMSLineId"] == null)
                {
                    SessionData akSessionData = new SessionData(0, "LineId");
                    sessionData.Add(4, akSessionData);
                }
                else
                {
                    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSLineId"].ToString()), "LineId");
                    sessionData.Add(4, aSessionData);
                }


                if (HttpContext.Current.Session["WCMSPackLineId"] == null)
                {
                    SessionData akSessionData = new SessionData(0, "PckLineId");
                    sessionData.Add(5, akSessionData);
                }
                else
                {
                    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSPackLineId"].ToString()), "PckLineId");
                    sessionData.Add(5, aSessionData);
                }



                
                //if (HttpContext.Current.Session["WCMSLoginDepartment"] == null)
                //{
                //    SessionData aSessionData = new SessionData(0, "DepartmentId");
                //    sessionData.Add(2, aSessionData);
                //}
                //else
                //{
                //    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSLoginDepartment"].ToString()), HttpContext.Current.Session["WCMSLoginDepartment"].ToString());
                //    sessionData.Add(2, aSessionData);
                //}

                //if (HttpContext.Current.Session["WCMSUserRoleId"] == null)
                //{
                //    SessionData aSessionData = new SessionData(0, "RoleId");
                //    sessionData.Add(3, aSessionData);
                //}
                //else
                //{
                //    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSUserRoleId"].ToString()), HttpContext.Current.Session["WCMSUserRoleId"].ToString());
                //    sessionData.Add(3, aSessionData);
                //}

                //if (HttpContext.Current.Session["WCMSUserRoleId"] == null)
                //{
                //    SessionData aSessionData = new SessionData(0, "RoleId");
                //    sessionData.Add(4, aSessionData);
                //}
                //else
                //{
                //    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSUserRoleId"].ToString()), HttpContext.Current.Session["WCMSUserRoleName"].ToString());
                //    sessionData.Add(4, aSessionData);
                //}


                //if (HttpContext.Current.Session["WCMSLoginUserName"] == null)
                //{
                //    SessionData aSessionData = new SessionData(0, "UserName");
                //    sessionData.Add(5, aSessionData);
                //}
                //else
                //{
                //    SessionData aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["WCMSLoginUserName"].ToString()), "UserName");

                //    sessionData.Add(5, aSessionData);
                //}







               
                return sessionData;
            }


             
        }


    }
