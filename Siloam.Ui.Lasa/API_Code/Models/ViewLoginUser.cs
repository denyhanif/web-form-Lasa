using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Siloam.Ui.Lasa.API_Code.Models
{
    public class ViewLoginUser
    {
       
        public string user_name { get; set; }
        public string full_name { get; set; }
        public string password { get; set; }
       
    }

    public class Result_login_user
    {
        private List<ViewLoginUser> lists = new List<ViewLoginUser>();
        [JsonProperty("data")]
        public List<ViewLoginUser> list { get { return lists; } }
    }
}