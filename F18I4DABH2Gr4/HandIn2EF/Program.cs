using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _UnitOfWork = new UnitOfWork(new PKKontekst()))
            {
                #region Create objects

                // create town for reference
                By Aarhus = new By()
                {
                    Bynavn = "Aarhus",
                    Postnummer = 8000

                };

                // create addresses
                Adresse Hjem = new Adresse()
                {
                    Vejnavn = "Finlandsgade",
                    Husnummer = 22,
                    Type = "Hjem",
                    Byer = Aarhus
                };
                Adresse Sommerhus = new Adresse()
                {
                    Vejnavn = "Bogfinkevej",
                    Husnummer = 420,
                    Type = "Sommerhus",
                    Byer = Aarhus
                };
                Adresse Arbejde = new Adresse()
                {
                    Vejnavn = "Ceresbyen",
                    Husnummer = 69,
                    Type = "Arbejde",
                    Byer = Aarhus
                };

                // Lars
                Person Bo = new Person()
                {
                    Fornavn = "Bo",
                    Efternavn = "Bertelsen",

                    PrimAdresse = Hjem
                };
                Bo.SekAdresse.Add(Sommerhus);

                // Jakob
                Person Brian = new Person()
                {
                    Fornavn = "Brian",
                    Mellemnavn = "Mørk",
                    Efternavn = "Mikkelsen",

                    PrimAdresse = Arbejde
                };

                #endregion

                // Add persons
                _UnitOfWork.Persons.Add(Bo);
                _UnitOfWork.Persons.Add(Brian);
                _UnitOfWork.Save(); // this will create town, addresses and persons in DB

                // Get person
                Person p1 = _UnitOfWork.Persons.GetById(Bo.PersonId);
                Console.WriteLine("{0}, {1}", p1.Efternavn, p1.Fornavn);

                // Remove person
                _UnitOfWork.Persons.Delete(Bo);
                _UnitOfWork.Save();

                // Update person
                Brian.Email = "mail@gmail.com";
                Brian.SekAdresse.Add(Arbejde);
                _UnitOfWork.Save();

                // Find addresses in 8000
                IEnumerable<Adresse> adr = _UnitOfWork.Adresses.GetAll();

                foreach (var address in adr)
                {
                    Console.WriteLine("{0}, {1}, 8000", address.Vejnavn, address.Husnummer);
                }

                #region Clean Up
                _UnitOfWork.Persons.Delete(Brian);

                //unitOfWork.Addresses.Remove(home);
                //unitOfWork.Addresses.Remove(cottage);
                //unitOfWork.Addresses.Remove(work);

                // deleting the the town will delete its associated addresses
                _UnitOfWork.Bys.Delete(Aarhus);

                _UnitOfWork.Save();
                #endregion
            }
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
