using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class CellphoneProvider
    {
        [JsonProperty(PropertyName = "providerName")]
        public string ProviderName { get; set; }
    }
}