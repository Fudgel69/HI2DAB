                
using HandIn2EF;
              
public class PersonkartotekRepository : Repository<Personkartotek>, IPersonkartotekRepository
{
    private PKKontekst _context;

    public PersonkartotekRepository(PKKontekst context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPersonkartotekRepository.cs file
}
