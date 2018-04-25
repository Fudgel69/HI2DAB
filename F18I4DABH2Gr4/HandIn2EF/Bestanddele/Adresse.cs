using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2EF
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