using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class CityDB
    {
        [JsonProperty(PropertyName = "id")]
        public string CityId { get; set; }
        public List<City> Cities { get; set; }
    }
}