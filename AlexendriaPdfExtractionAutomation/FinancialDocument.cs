using System;
using Xunit;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ApiServicesTestAutomation.modelfiles;
using AlexendriaPdfExtractionAutomation;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ApiServicesTestAutomation
{

    public class FinancialDocument
    {

        public PageResponse GetDocumentPageNo(string pdfKey)
        {
            var client = new RestClient(ConfigHelper.GetAlexandriaUrl() + "/doc/")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-api-key", ConfigHelper.GetAlexandriaKey());// token 
            request.AddOrUpdateParameter("key", pdfKey);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {

                var resobj = Newtonsoft.Json.JsonConvert.DeserializeObject<PageResponse>(response.Content);
                return resobj;
            }
            return default(PageResponse);
        }


        public TableResponse GetDocumentTable(PageResponse pageInfo)
        {
            var client = new RestClient(ConfigHelper.GetAlexandriaUrl() + "/doc/")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-api-key", ConfigHelper.GetAlexandriaKey());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(pageInfo),
                ParameterType.RequestBody); ;
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<TableResponse>(response.Content);
            }
            else return default(TableResponse);
        }
    }
}

 