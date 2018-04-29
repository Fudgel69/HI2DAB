using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class Adresse
    {
        [Key]
        public int AdresseID { get; set; }
        [Required]
        public string Vejnavn { get; set; }
        [Required]
        public int Husnummer { get; set; }
        public string Type { get; set; }
        [Required]
        public virtual By Byer { get; set; }
    }
}