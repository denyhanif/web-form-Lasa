using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Siloam.Ui.Lasa.API_Code.Models
{
    public class User
    {
        public Guid user_id { get; set; }
        public string user_name { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool is_active { get; set; }
        public DateTime create_date { get; set; }
    }

    public class Result_Data_user
    {
        private List<User> lists = new List<User>();
        [JsonProperty("data")]
        public List<User> list { get { return lists; } }
    }
}