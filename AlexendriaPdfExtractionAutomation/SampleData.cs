using AlexendriaPdfExtractionAutomation.AlexendriaModels;
using ApiServicesTestAutomation.modelfiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlexendriaPdfExtractionAutomation
{
    public static class SampleData
    {
        public static PageResponse GetPageNumberData()
        {
            using (StreamReader r = new StreamReader(@".\sampledata\PageNumber.json"))
            {
                string json = r.ReadToEnd();
                PageResponse items = JsonConvert.DeserializeObject<PageResponse>(json);
                return items;

            }
        }

        public static TableResponse GetTableData(string schedule)
        {
            using (StreamReader r = new StreamReader(@".\sampledata\TableData.json"))
            {
                string json = r.ReadToEnd();
                List<TableResponse> items = JsonConvert.DeserializeObject<List<TableResponse>>(json);
                return items.Where(item => item.Body.FinancialStmtName == schedule).FirstOrDefault();
            }
        }

    }
}
