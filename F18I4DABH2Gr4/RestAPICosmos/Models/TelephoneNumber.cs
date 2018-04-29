using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICosmos.Models
{
    using Newtonsoft.Json;

    public class TelephoneNumber
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "telephoneType")]
        public string TelephoneNumberType { get; set; }
        public virtual CellphoneProvider CellphoneProvider { get; set; }
    }
}