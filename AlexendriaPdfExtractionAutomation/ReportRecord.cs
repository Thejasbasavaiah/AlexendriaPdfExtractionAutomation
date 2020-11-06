using AlexendriaPdfExtractionAutomation.AlexendriaModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlexendriaPdfExtractionAutomation
{
    public class ReportRecord
    {
        public string filename  { get; set; }
        public string IS_page_num { get; set; }
        public string BS_page_num { get; set; }
        public string CF_page_num { get; set; }
        public List<LineItemStat> lineItemStat { get; set; }
    }

    public class LineItemStat
    {
        public string Schedule { get; set; }
        public string LineItemCount { get; set; }
        public string MappedLineItemCount { get; set; }
        public string UnmapedLineItem { get; set; }

    }



}

