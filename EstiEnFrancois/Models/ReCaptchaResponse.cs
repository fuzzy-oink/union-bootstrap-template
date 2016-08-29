using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EstiEnFrancois.Models
{
    public class ReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}