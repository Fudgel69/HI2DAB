using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestAPICosmos.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string CPR { get; set; }
        [Required]
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        [Required]
        public string Efternavn { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string AdressID { get; set; }
    }
}