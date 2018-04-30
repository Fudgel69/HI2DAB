using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class Adresse
    {

        [JsonProperty(PropertyName = "id")]
        public string AdresseID { get; set; }
        [JsonProperty(PropertyName = "addressName")]
        public string Vejnavn { get; set; }
        [JsonProperty(PropertyName = "addressNumber")]
        public int Husnummer { get; set; }
        [JsonProperty(PropertyName = "addressType")]
        public string Type { get; set; }


        public virtual By Postnummer { get; set; }

        public bool Completed { get; set; }
    }
}