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
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "personAddress")]
        public virtual Address Address { get; set; }

        [JsonProperty(PropertyName = "telephoneNumber")]
        public virtual TelephoneNumber TelephoneNumbers { get; set; }

        public bool Completed { get; set; }
    }
}