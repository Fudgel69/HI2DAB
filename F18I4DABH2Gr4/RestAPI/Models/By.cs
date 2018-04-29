using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RestAPI.Models
{
    public class By
    {
        [Key]
        public int ById { get; set; }
        [Required]
        public int Postnummer { get; set; }
        [Required]
        public string Bynavn { get; set; }
    }
}