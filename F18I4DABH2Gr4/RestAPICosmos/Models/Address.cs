using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class Address
    {

        [JsonProperty(PropertyName = "id")]
        public string AddressId { get; set; }
        [JsonProperty(PropertyName = "addressName")]
        public string AddressName { get; set; }
        [JsonProperty(PropertyName = "addressNumber")]
        public int AddressNumber { get; set; }
        [JsonProperty(PropertyName = "addressType")]
        public string AddressType { get; set; }


        public virtual City ZipCode { get; set; }

        public bool Completed { get; set; }
    }
}