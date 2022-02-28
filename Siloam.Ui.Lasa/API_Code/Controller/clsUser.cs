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
    public class clsUser
    {

        // fungsi user forgot password
        public static async Task<string> GetDataUserForgotPass(string username, string email)
        {
            //string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            ParamForgotPass param = new ParamForgotPass();
            param.user_name = username;
            param.email = email;

            var JsonString = JsonConvert.SerializeObject(param);
            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");

            try
            {
                //string apicentralums = "http://10.85.129.91:8500"; //untuk persiapan ganti uri base address
                HttpClient http_data_userForgot = new HttpClient();
                http_data_userForgot.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLITEMLASA"].ToString());

                http_data_userForgot.DefaultRequestHeaders.Accept.Clear();
                http_data_userForgot.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var task = Task.Run(async () =>
                {
                    return await http_data_userForgot.PutAsync(string.Format($"/userselectbyforgotpassword"), content);
                });

                //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", username.ToString(), "GetDataUserForgotPass", StartTime, "OK", MyUser.GetUsername(), "", JsonString, ""));
                return task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception exx)
            {
                //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", username.ToString(), "GetDataUserForgotPass", StartTime, "ERROR", MyUser.GetUsername(), "", JsonString, exx.Message));
                return exx.Message;
            }
        }

        public static async Task<string> ChangePasswordUser(string username, string oldpass, string newpass)
        {
            string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            ParamChangePass param = new ParamChangePass();
            param.user_name = username;
            param.old_password = oldpass;
            param.new_password = newpass;

            var JsonString = JsonConvert.SerializeObject(param);
            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");

            try
            {
                //string apicentralums = "http://10.85.129.91:8500"; //untuk persiapan ganti uri base address
                HttpClient http_putuser = new HttpClient();
                http_putuser.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLITEMLASA"].ToString());

                http_putuser.DefaultRequestHeaders.Accept.Clear();
                http_putuser.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var task = Task.Run(async () =>
                {
                    return await http_putuser.PutAsync(string.Format($"/ChangePassword"), content);
                });

                //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", username.ToString(), "ChangePasswordUser", StartTime, "OK", username, "", JsonString, ""));
                return task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", username.ToString(), "ChangePasswordUser", StartTime, "ERROR", username, "", JsonString, ex.Message));
                return ex.Message;
            }
        }
    }
}