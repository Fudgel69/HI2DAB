using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RestAPI.Models
{
    public class ByDTO
    {
        public int ById { get; set; }
        public int Postnummer { get; set; }
        public string Bynavn { get; set; }
    }
}