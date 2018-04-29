using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class City
    {

        [JsonProperty(PropertyName = "id")]
        public string CityId { get; set; }
        public List<City> Cities { get; set; }

        [JsonProperty(PropertyName = "cityName")]
        public string CityName { get; set; }
        [JsonProperty(PropertyName = "cityZipCode")]
        public int CityZipCode { get; set; }

        public bool Completed { get; set; }

    }
}