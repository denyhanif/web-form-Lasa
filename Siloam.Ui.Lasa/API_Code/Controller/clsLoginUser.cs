using Newtonsoft.Json;
using Siloam.Ui.Lasa.API_Code.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Siloam.Ui.Lasa.API_Code.Controller
{
    public class clsLoginUser
    {
        //private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // login
        public static async Task<string> GetLogin(string UserName, string Password)
        {
            //string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            ParamLoginUser ParamLogin = new ParamLoginUser();
            ParamLogin.user_name = UserName;
            ParamLogin.password = Password;
            // ParamLogin.application_id = Guid.Parse(ConfigurationManager.AppSettings["ApplicationId"].ToString());

            string JsonString = JsonConvert.SerializeObject(ParamLogin);
            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");

            try
            {
                HttpClient http_login_user = new HttpClient();
                http_login_user.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLITEMLASA"].ToString());

                http_login_user.DefaultRequestHeaders.Accept.Clear();
                http_login_user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var task = Task.Run(async () =>
                {
                    return await http_login_user.PostAsync(string.Format($"/Login"), content);
                });

                //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", UserName, "GetLogin", StartTime, "OK", UserName, "", JsonString, ""));
                return task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception exx)
            {
                //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", UserName, "GetLogin", StartTime, "ERROR", UserName, "", JsonString, exx.Message));
                return exx.Message;
            }
        }


        // get page login
        //public static async Task<string> GetPageLogin(Guid UserID)
        //{
        //    //string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //    //string AppId = "";
        //    try
        //    {
        //        HttpClient http_Page_login = new HttpClient();
        //        http_Page_login.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLITEMLASA"].ToString());

        //        http_Page_login.DefaultRequestHeaders.Accept.Clear();
        //        http_Page_login.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        //AppId = ConfigurationManager.AppSettings["ApplicationId"].ToString();

        //        var task = Task.Run(async () =>
        //        {
        //            return await http_Page_login.GetAsync(string.Format($"/pageselectbyappandrole/" + UserID));
        //        });

        //        //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "UserID", UserID.ToString(), "GetPageLogin", StartTime, "OK", MyUser.GetUsername(), "/" + UserID.ToString() + "/" + AppId + "/" + RoleID.ToString() + "/" + OrgID.ToString(), "", ""));
        //        return task.Result.Content.ReadAsStringAsync().Result;
        //    }
        //    catch (Exception exx)
        //    {
        //        //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "UserID", UserID.ToString(), "GetPageLogin", StartTime, "ERROR", MyUser.GetUsername(), "/" + UserID.ToString() + "/" + AppId + "/" + RoleID.ToString() + "/" + OrgID.ToString(), "", exx.Message));
        //        return exx.Message;
        //    }
        //}


    }
}