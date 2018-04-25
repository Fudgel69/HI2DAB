using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2EF
{
    public class Telefon
    {
        [Key]
        public int Nummer { get; set; }
        public string Type { get; set; }
        public string Teleselskab { get; set; }
    }
}