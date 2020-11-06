using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServicesTestAutomation.modelfiles
{
    public partial class PageBody
    {
        public int page_num { get; set; }
        public string table_name { get; set; }
        public string unit_text { get; set; }
        public string currency { get; set; }
        public string short_name { get; set; }
    }

    public class PageResponse
    {
        [JsonProperty("body")]
        public List<PageBody> pageBody { get; set; }
    }





}
