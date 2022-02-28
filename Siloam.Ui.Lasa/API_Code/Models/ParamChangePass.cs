using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Siloam.Ui.Lasa.API_Code.Models
{
    public class ParamChangePass
    {
        public string user_name { get; set; }
        public string old_password { get; set; }
        public string new_password { get; set; }
    }
}