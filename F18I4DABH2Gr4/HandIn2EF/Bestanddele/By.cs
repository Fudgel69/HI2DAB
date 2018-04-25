using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HandIn2EF
{
    public class By
    {
        [Key]
        public int ById { get; set; }
        public int Postnummer { get; set; }
        public string Bynavn { get; set; }
    }
}