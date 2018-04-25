                
using HandIn2EF;
              
public class PersonRepository : Repository<Person>, IPersonRepository
{
    private PKKontekst _context;

    public PersonRepository(PKKontekst context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPersonRepository.cs file
}
