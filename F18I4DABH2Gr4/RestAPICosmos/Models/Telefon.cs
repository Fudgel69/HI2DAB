using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class Telefon
    {
        [JsonProperty(PropertyName = "nummer")]
        public int Nummer { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
        public string Teleselskab { get; set; }
    }
}