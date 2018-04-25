
    
using HandIn2EF;
              
public class ProgramRepository : Repository<Program>, IProgramRepository
{
    private PKKontekst _context;

    public ProgramRepository(PKKontekst context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IProgramRepository.cs file
}
