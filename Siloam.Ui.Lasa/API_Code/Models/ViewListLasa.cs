using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Siloam.Ui.Lasa.API_Code.Models
{
    public class ViewListLasa
    {
        public long? item_id { get; set; }
        public long SalesItemId { get; set; }
        public string name { get; set; }
        public bool? is_lasa { get; set; }
        public Nullable<DateTime> modified { get; set; }
    }

    public class Result_Data_Lasa_List
    {
        private List<ViewListLasa> lists = new List<ViewListLasa>();
        [JsonProperty("data")]
        public List<ViewListLasa> list { get { return lists; } }
    }
}