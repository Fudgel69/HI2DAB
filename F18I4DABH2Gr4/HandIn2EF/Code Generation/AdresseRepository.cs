                
using HandIn2EF;
              
public class AdresseRepository : Repository<Adresse>, IAdresseRepository
{
    private PKKontekst _context;

    public AdresseRepository(PKKontekst context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IAdresseRepository.cs file
}
