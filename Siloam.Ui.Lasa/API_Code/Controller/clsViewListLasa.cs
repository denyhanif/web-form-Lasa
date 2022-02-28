using Microsoft.VisualBasic.Logging;
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
    public class clsViewListLasa
    {

        public static async Task<string> GetDataLasa()
        {
           
            try
            {
                HttpClient http_data_lasa = new HttpClient();
                http_data_lasa.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLITEMLASA"].ToString());

                http_data_lasa.DefaultRequestHeaders.Accept.Clear();
                http_data_lasa.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var task = Task.Run(async () =>
                {
                    return await http_data_lasa.GetAsync(string.Format($"/dataLassa"));
                });

               //  Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "OrgID", OrgID.ToString(), "GetDataUser", StartTime, "OK", MyUser.GetUsername(), "/" + OrgID.ToString() + "/" + AppID.ToString() + "/" + RoleID.ToString(), "", ""));
                return task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception exx)
            {
                // Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "OrgID", OrgID.ToString(), "GetDataUser", StartTime, "ERROR", MyUser.GetUsername(), "/" + OrgID.ToString() + "/" + AppID.ToString() + "/" + RoleID.ToString(), "", exx.Message));
                return exx.Message;
            }
        }

        public static async Task<string> GetDataLasabySearch(string product_name)
        {
            // string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            try
            {
                HttpClient http_data_lasabysearch = new HttpClient();
                http_data_lasabysearch.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLITEMLASA"].ToString());

                http_data_lasabysearch.DefaultRequestHeaders.Accept.Clear();
                http_data_lasabysearch.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var task = Task.Run(async () =>
                {
                    return await http_data_lasabysearch.GetAsync(string.Format($"/selectLassabyname/ " + product_name));
                });

                //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "keyword", keyword, "GetDataOrganizationbySearch", StartTime, "OK", MyUser.GetUsername(), "/" + keyword, "", ""));
                return task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception exx)
            {
                //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "keyword", keyword, "GetDataOrganizationbySearch", StartTime, "ERROR", MyUser.GetUsername(), "/" + keyword, "", exx.Message));
                return exx.Message;
            }
        }

        public static async Task<string> PutDataLasa(long item_id, ParamUpdateLasa param_update)
        {
            //string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var JsonString = JsonConvert.SerializeObject(param_update);
            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");

            try
            {
                HttpClient http_putOrg = new HttpClient();
                http_putOrg.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLITEMLASA"].ToString());

                http_putOrg.DefaultRequestHeaders.Accept.Clear();
                http_putOrg.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var task = Task.Run(async () =>
                {
                    return await http_putOrg.PutAsync(string.Format($"/UpdateLasa/" + item_id), content);
                });

                //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "org_id", org_id.ToString(), "PutDataOrganization", StartTime, "OK", MyUser.GetUsername(), "/" + org_id.ToString(), JsonString, ""));
                return task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "org_id", org_id.ToString(), "PutDataOrganization", StartTime, "ERROR", MyUser.GetUsername(), "/" + org_id.ToString(), JsonString, ex.Message));
                return ex.Message;
            }
        }

        public static async Task<string> PostDataLasa(ParamMapingLasa param_map_lasa)
        {
            //string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var JsonString = JsonConvert.SerializeObject(param_map_lasa);
            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");

            try
            {
                HttpClient http_postlasa = new HttpClient();
                http_postlasa.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLITEMLASA"].ToString());

                http_postlasa.DefaultRequestHeaders.Accept.Clear();
                http_postlasa.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var task = Task.Run(async () =>
                {
                    return await http_postlasa.PostAsync(string.Format($"/InsertLasa"), content);
                });

                //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", MyUser.GetUsername(), "PostDataOrganization", StartTime, "OK", MyUser.GetUsername(), "", JsonString, ""));
                return task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", MyUser.GetUsername(), "PostDataOrganization", StartTime, "ERROR", MyUser.GetUsername(), "", JsonString, ex.Message));
                return ex.Message;
            }
        }

    }
}