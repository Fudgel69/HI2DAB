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
    public class PKKontekst : DbContext
    {
        public DbSet<Personkartotek> Personkartoteker { get; set; }
        public DbSet<Person> Personer { get; set; }
        public DbSet<Telefon> Telefoner { get; set; }
        public DbSet<Adresse> Adresser { get; set; }
        public DbSet<By> Byer { get; set; }
    }


}