            using System;

public interface IUnitOfWork : IDisposable
{
    IAdresseRepository Addresses { get; }
    ITelefonRepository Telefons { get; }
    IPersonkartotekRepository Personkartoteks { get; }
    IPersonRepository Persons { get; }
    IByRepository Bys { get; }
    void Save();
}
