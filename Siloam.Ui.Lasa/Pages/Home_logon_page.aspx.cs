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
    public partial class Home_logon_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //string userName = (string)(Session["user_name"]);
            //if (userName != null)
            //{
            //    Response.Redirect("~/Pages/Home_logon_page.aspx", false);
            //}


            // function for range of time
            DateTime present = DateTime.Now;
            DateTime pagi_A = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 1);
            DateTime pagi_B = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0);
            DateTime siang_A = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 1);
            DateTime siang_B = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0);
            DateTime sore_A = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 1);
            DateTime sore_B = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0);
            DateTime malam_A = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 1);
            DateTime malam_B = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 0);

            // check moment at the time
            if (present >= pagi_A && present <= pagi_B)
            {
                LabelWelcome.Text = "GOOD MORNING";
            }
            else if (present >= siang_A && present <= siang_B)
            {
                LabelWelcome.Text = "GOOD AFTERNOON";
            }
            else if (present >= sore_A && present <= sore_B)
            {
                LabelWelcome.Text = "GOOD EVENING";
            }
            else if (present >= malam_A && present <= malam_B)
            {
                LabelWelcome.Text = "GOOD NIGHT";
            }

            // inisialize name user after login
            DataTable dt_login = (DataTable)Session[Helper.Session_DataLogin];
            if (dt_login != null)
            {
                LabelName.Text = dt_login.Rows[0]["first_name"].ToString() + " " + dt_login.Rows[0]["last_name"].ToString();
            }
            else
            {
                Response.Redirect("~/Pages/Login_page.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void disablebrowserbackbutton()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }
    }
}