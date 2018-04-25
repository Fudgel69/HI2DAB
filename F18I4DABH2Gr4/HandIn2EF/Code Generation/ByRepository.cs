                
using HandIn2EF;
              
public class ByRepository : Repository<By>, IByRepository
{
    private PKKontekst _context;

    public ByRepository(PKKontekst context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IByRepository.cs file
}
