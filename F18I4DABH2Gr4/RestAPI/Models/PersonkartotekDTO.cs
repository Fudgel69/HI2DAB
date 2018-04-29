using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class PersonkartotekDTO
    {
        public int PersonkartotekId { get; set; }
        public virtual List<Person> Bekendte { get; set; }
    }
}