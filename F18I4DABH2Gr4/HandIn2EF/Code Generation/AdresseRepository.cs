using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandIn2EF;


public class AdresseRepository : Repository<Adresse>, IAdresseRepository
{
    private PKKontekst _context;

    public AdresseRepository(PKKontekst context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ITelefonRepository.cs file
}


