using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexendriaPdfExtractionAutomation.AlexendriaModels
{
   

        public class UploadResponse
        {
            public string IsError { get; set; }
            public Body Body { get; set; }
            public string Status { get; set; }
            public string Key { get; set; }
        }

        public class Body
        {
            public string url { get; set; }
            public field fields { get; set; }

        }

        public class field
        {
            public string key { get; set; }
            public string AWSAccessKeyId { get; set; }

            [JsonProperty("x-amz-security-token")]
            public string XAmzSecurityToken { get; set; }
            public string policy { get; set; }
            public string signature { get; set; }
        }
    }


