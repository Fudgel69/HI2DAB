            using System;

public interface IUnitOfWork : IDisposable
{
    IAdresseRepository Adresses { get; }
    ITelefonRepository Telefons { get; }
    IPersonkartotekRepository Personkartoteks { get; }
    IPersonRepository Persons { get; }
    IByRepository Bys { get; }
    void Save();
}
