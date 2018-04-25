                
using HandIn2EF;
              
public class TelefonRepository : Repository<Telefon>, ITelefonRepository
{
    private PKKontekst _context;

    public TelefonRepository(PKKontekst context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ITelefonRepository.cs file
}
