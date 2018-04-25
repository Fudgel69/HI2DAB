﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace HandIn2
{
    public class Personkartotek
    {
        [Key]
        public int PersonkartotekId { get; set; }
        public virtual List<Person> Bekendte { get; set; }
    }
}