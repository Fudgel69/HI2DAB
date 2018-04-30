using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;
    [Serializable]
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string PersonId { get; set; }
        public string Fornavn { get; set; }

        public string Mellemnavn { get; set; }

        public string Efternavn { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "personAddress")]
        public virtual Adresse Adresse { get; set; }

        [JsonProperty(PropertyName = "telephoneNumber")]
        public virtual Telefon Nummer { get; set; }

        public bool Completed { get; set; }
    }
}