using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace HandIn2
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string CPR { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public virtual List<Telefon> PersTelefon { get; set; }
        public virtual Adresse PrimAdresse { get; set; }
        public virtual List<Adresse> SekAdresse { get; set; }
    }
}