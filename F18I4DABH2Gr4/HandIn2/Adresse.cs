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
    public class Adresse
    {
        [Key]
        public int AdresseID { get; set; }
        public string Vejnavn { get; set; }
        public int Husnummer { get; set; }
        public string Type { get; set; }
        public virtual By Byer { get; set; }
    }
}