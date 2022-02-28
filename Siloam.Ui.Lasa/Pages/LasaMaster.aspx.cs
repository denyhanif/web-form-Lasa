using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Siloam.Ui.Lasa.API_Code.Controller;
using Siloam.Ui.Lasa.API_Code.Models;
using Siloam.Ui.Lasa.Pages.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siloam.Ui.Lasa.Pages
{
    public partial class LasaMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            getDataLasa();
        }

        // toast
        void ShowToastr(string message, string title, string type)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "toastr_message",
                String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        //fungsi link pagination pada gridview
        protected void GridViewLasa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewLasa.PageIndex = e.NewPageIndex;
            if (HiddenFlagCari.Value == "0")
            {
                getDataLasa();
            }
            else if (HiddenFlagCari.Value == "1")
            {
                getDataLasaSearch(Search_masterData.Text);
            }
        }

        //get list data organization
        void getDataLasa()
        {
            //string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            try
            {
                List<ViewListLasa> ListLasaData = new List<ViewListLasa>();
                var Get_Lasa = clsViewListLasa.GetDataLasa();
                var Get_DataLasa = JsonConvert.DeserializeObject<Result_Data_Lasa_List>(Get_Lasa.Result.ToString());

                ListLasaData = Get_DataLasa.list;

                if (ListLasaData.Count() > 0)
                {
                    DataTable dt_lasa = Helper.ToDataTable(ListLasaData);

                    //fungsi sorting datatable
                    dt_lasa.DefaultView.Sort = "SalesItemId ASC";
                    dt_lasa = dt_lasa.DefaultView.ToTable();

                    GridViewLasa.DataSource = dt_lasa;
                    GridViewLasa.DataBind();
                }
                else
                {
                    var Response = (JObject)JsonConvert.DeserializeObject<dynamic>(Get_Lasa.Result);
                    var Status = Response.Property("status").Value.ToString();
                    var Message = Response.Property("message").Value.ToString();

                    ShowToastr(Message, Status, "warning");
                }
                //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", MyUser.GetUsername(), "getDataOrganization", StartTime, "OK", MyUser.GetUsername(), "", "", ""));
            }
            catch (Exception exx)
            {
                //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", MyUser.GetUsername(), "getDataOrganization", StartTime, "ERROR", MyUser.GetUsername(), "", "", exx.Message));
                ShowToastr("Please Check Your Connection!", "Error Load Data", "Error");
            }
        }

        //get list data organization pencarian
        void getDataLasaSearch(string keyword)
        {
            // string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            try
            {
                List<ViewListLasa> ListLasaData = new List<ViewListLasa>();
                var Get_Lasa = clsViewListLasa.GetDataLasabySearch(keyword);
                var Get_DataLasa = JsonConvert.DeserializeObject<Result_Data_Lasa_List>(Get_Lasa.Result.ToString());

                ListLasaData = Get_DataLasa.list;

                if (ListLasaData.Count() > 0)
                {
                    DataTable dt_lasa = Helper.ToDataTable(ListLasaData);

                    //fungsi sorting datatable
                    dt_lasa.DefaultView.Sort = "SalesItemId ASC";
                    dt_lasa = dt_lasa.DefaultView.ToTable();

                    GridViewLasa.DataSource = dt_lasa;
                    GridViewLasa.DataBind();
                }
                else
                {
                    var Response = (JObject)JsonConvert.DeserializeObject<dynamic>(Get_Lasa.Result);
                    var Status = Response.Property("status").Value.ToString();
                    var Message = Response.Property("message").Value.ToString();

                    ShowToastr(Message, "Data not found", "warning");
                }
                //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", MyUser.GetUsername(), "getDataOrganizationSearch", StartTime, "OK", MyUser.GetUsername(), "", "", ""));
            }
            catch (Exception exx)
            {
                //Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", MyUser.GetUsername(), "getDataOrganizationSearch", StartTime, "ERROR", MyUser.GetUsername(), "", "", exx.Message));
                ShowToastr("Please Check Your Connection!", "Error Load Data", "Error");
            }
        }

        //fungsi klik button tpencarian
        protected void ButtonCari_Click(object sender, EventArgs e)
        {
            if (Search_masterData.Text != "")
            {
                getDataLasaSearch(Search_masterData.Text);
                HiddenFlagCari.Value = 1.ToString();
            }
            else
            {
                getDataLasa();
                HiddenFlagCari.Value = 0.ToString();
            }
        }


        // fungsi button save edit data
        protected void Edit_ButtonSaveLasa_Click(object sender, EventArgs e)
        {
            //string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            ParamUpdateLasa model_param_update = new ParamUpdateLasa();

            model_param_update.item_id = long.Parse(HiddenTransactionID.Value.ToString());
            model_param_update.is_lasa = bool.Parse(Rb_is_lasa_edit.SelectedValue.ToString());

            try
            {
                var hasil = clsViewListLasa.PutDataLasa(model_param_update.item_id, model_param_update);

                var Response = (JObject)JsonConvert.DeserializeObject<dynamic>(hasil.Result);
                var Status = Response.Property("status").Value.ToString();
                var Message = Response.Property("message").Value.ToString();

                if (Status == "Fail")
                {
                    p_Edit.Attributes.Remove("style");
                    p_Edit.Attributes.Add("style", "display:block; color:red;");
                    p_Edit.InnerText = "Save Failed!";
                    ShowToastr(Status + "! " + Message, "Save Failed", "error");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "message", "$('#modalEditLasa').modal('hide');", addScriptTags: true);
                    ShowToastr("Lasa : data successfully changed", "Save Success", "success");
                    getDataLasa();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", MyUser.GetUsername(), "Edit_ButtonSaveOrg_Click", StartTime, "OK", MyUser.GetUsername(), "", "", ""));
        }

        protected void Add_ButtonSaveLasa_Click(object sender, EventArgs e)
        {
            // string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            ParamMapingLasa param_input_lasa = new ParamMapingLasa();

            param_input_lasa.SalesItemId = long.Parse(HiddenField_SalesId.Value.ToString());
            param_input_lasa.is_lasa = bool.Parse(Add_RadioButtonList.SelectedValue.ToString());

                    var hasil = clsViewListLasa.PostDataLasa(param_input_lasa);

                    var Response = (JObject)JsonConvert.DeserializeObject<dynamic>(hasil.Result);
                    var Status = Response.Property("status").Value.ToString();
                    var Message = Response.Property("message").Value.ToString();

                    if (Status == "Fail")
                    {
                        p_Add.Attributes.Remove("style");
                        p_Add.Attributes.Add("style", "display:block; color:red;");
                        p_Add.InnerText = "Save Failed!";
                        ShowToastr(Status + "! " + Message, "Save Failed", "error");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "message", "$('#modalMapingLasa').modal('hide');", addScriptTags: true);
                        ShowToastr("Lasa : data successfully added", "Save Success", "success");
                        getDataLasa();

                        //clearFormAdd();
                    }
                
            


            //Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", MyUser.GetUsername(), "Add_ButtonSaveOrg_Click", StartTime, "OK", MyUser.GetUsername(), "", "", ""));
        }
    }
}