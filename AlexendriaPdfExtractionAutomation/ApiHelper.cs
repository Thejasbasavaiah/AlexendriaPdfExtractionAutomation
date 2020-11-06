using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace AlexendriaPdfExtractionAutomation
{
    public static class ApiHelper
    {
        // Returns JSON string
        public static string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    return reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
        // POST a JSON string
        public static string POST(string url, string jsonContent, bool isAlexandriaUrl = false)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            if (isAlexandriaUrl)
                client.DefaultRequestHeaders.Add("x-api-key", ConfigHelper.GetAlexandriaKey());
            System.Net.Http.HttpContent content = new StringContent(jsonContent, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(url, content).Result;
            if (messge.IsSuccessStatusCode)
            {
                return messge.Content.ReadAsStringAsync().Result;
            }
            return null;
        }
    }
}
