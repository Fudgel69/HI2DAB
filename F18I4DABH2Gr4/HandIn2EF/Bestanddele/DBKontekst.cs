using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2EF
{
    public class PKKontekst : DbContext
    {
        public PKKontekst()
            : base("HandIn2_I4DABGr4")
        {
        }
        public DbSet<Personkartotek> Personkartoteker { get; set; }
        public DbSet<Person> Personer { get; set; }
        public DbSet<Telefon> Telefoner { get; set; }
        public DbSet<Adresse> Adresser { get; set; }
        public DbSet<By> Byer { get; set; }
    }


}