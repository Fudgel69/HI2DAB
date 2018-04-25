using System;
using HandIn2EF;

public class UnitOfWork : IUnitOfWork
{
    private PKKontekst _context;

    public UnitOfWork(PKKontekst context)
    {
        _context = context;
    }

	//Delete this default constructor if using an IoC container
	public UnitOfWork()
	{
		_context = new PKKontekst();
	}
	
    public IProgramRepository Programs
    {
        get { return new ProgramRepository(_context); }
    }

    public IAdresseRepository Adresses
    {
        get { return new AdresseRepository(_context); }
    }

    public ITelefonRepository Telefons
    {
        get { return new TelefonRepository(_context); }
    }

    public IPersonkartotekRepository Personkartoteks
    {
        get { return new PersonkartotekRepository(_context); }
    }

    public IPersonRepository Persons
    {
        get { return new PersonRepository(_context); }
    }

    public IByRepository Bys
    {
        get { return new ByRepository(_context); }
    }

    
    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
