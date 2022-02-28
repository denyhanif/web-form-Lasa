using Siloam.Ui.Lasa.Pages.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siloam.Ui.Lasa
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //log4net.ThreadContext.Properties["Organization"] = MyUser.GetOrgId();

           

            if (!IsPostBack)
            {

                try
                {
                    //data didapat dari form login
                    DataTable dt_login = (DataTable)Session[Helper.Session_DataLogin];

                    if (dt_login != null)
                    {
                        lblUsername.Text = dt_login.Rows[0]["user_name"].ToString();
                        lblFullname.Text = dt_login.Rows[0]["user_name"].ToString();
                        lblEmail.Text = dt_login.Rows[0]["full_name"].ToString();
                    }
                    else
                    {
                        Response.Redirect("~/Pages/Login_page.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                catch(Exception ex)
                {
                    //ShowToastr("Please Check Your Connection!", "Error Load Data", "error");

                }
            }

            // function: show toast message 
            void ShowToastr(string message, string title, string type)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "toastr_message",
                     String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
            }
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Pages/Login_page.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}