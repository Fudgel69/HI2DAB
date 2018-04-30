using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class ByDB
    {
        [JsonProperty(PropertyName = "id")]
        public string ById { get; set; }
        public List<By> Byer { get; set; }
    }
}