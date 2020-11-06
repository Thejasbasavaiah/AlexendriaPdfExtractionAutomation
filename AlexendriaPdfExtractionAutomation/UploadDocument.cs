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
    public static class UploadDocument
    {
        

        
        public static async Task<string> UploadFileAsync(string filePath)
        {
            //fetch the S3 Bucket details 
            var client = new RestClient(ConfigHelper.GetAlexandriaUrl() + "/doc/upload")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-api-key", ConfigHelper.GetAlexandriaKey());
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {

                var resobj = JsonConvert.DeserializeObject<UploadResponse>(response.Content);

                //Upload file to S3 
                HttpClient httpClient = new HttpClient();
                MultipartFormDataContent form = new MultipartFormDataContent();
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    form.Add(new StringContent(resobj.Body.fields.key), "key");
                    form.Add(new StringContent(resobj.Body.fields.AWSAccessKeyId), "AWSAccessKeyId");
                    form.Add(new StringContent(resobj.Body.fields.XAmzSecurityToken), "x-amz-security-token");
                    form.Add(new StringContent(resobj.Body.fields.policy), "policy");
                    form.Add(new StringContent(resobj.Body.fields.signature), "signature");
                    form.Add(new ByteArrayContent(fileBytes), "file");
                    HttpResponseMessage responses3 = await httpClient.PostAsync(resobj.Body.url, form);

                    responses3.EnsureSuccessStatusCode();
                    httpClient.Dispose();
                    return JsonConvert.SerializeObject(resobj.Body.fields.key);
                }
            }
            else return response.ErrorMessage;
        }

    }
}

