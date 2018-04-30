using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class By
    {

        [JsonProperty(PropertyName = "id")]
        public string ById { get; set; }
        public List<By> Byer { get; set; }

        [JsonProperty(PropertyName = "cityName")]
        public string ByNavn { get; set; }
        [JsonProperty(PropertyName = "cityZipCode")]
        public int Postnummer { get; set; }

        public bool Completed { get; set; }

    }
}