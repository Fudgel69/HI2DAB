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
                #region Oprettelse af objekter

                //Laver en by
                By Aarhus = new By()
                {
                    Bynavn = "Aarhus",
                    Postnummer = 8000

                };

                //Laver tre adresser, alle i Aarhus
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

                //Personen Bo bliver oprettet
                Person Bo = new Person()
                {
                    Fornavn = "Bo",
                    Efternavn = "Bertelsen",
                    SekAdresse = new List<Adresse>(),
                    PrimAdresse = Hjem
                };
                Bo.SekAdresse.Add(Sommerhus);

                //Personen Brian bliver oprettet
                Person Brian = new Person()
                {
                    Fornavn = "Brian",
                    Mellemnavn = "Mørk",
                    Efternavn = "Mikkelsen",
                    SekAdresse = new List<Adresse>(),
                    PrimAdresse = Arbejde
                };

                #endregion

                //Creérer person-instanser i databasen
                _UnitOfWork.Persons.Add(Bo);
                _UnitOfWork.Persons.Add(Brian);
                _UnitOfWork.Save();

                //Returner person
                Person personEt = _UnitOfWork.Persons.GetById(Bo.PersonId);
                Console.WriteLine("{0}, {1}", personEt.Efternavn, personEt.Fornavn);


                _UnitOfWork.Persons.Delete(Bo);
                _UnitOfWork.Save();

                Brian.Email = "bri@n.com";
                Brian.SekAdresse.Add(Arbejde);
                _UnitOfWork.Save();

                //Find adresser i Aarhus (8000)
                IEnumerable<Adresse> adr = _UnitOfWork.Addresses.Find(t => t.Byer.Postnummer == 8000);


                foreach (var address in adr)
                {
                    Console.WriteLine("{0}, {1}, 8000", address.Vejnavn, address.Husnummer);
                }

                #region Delete it
                //_UnitOfWork.Persons.Delete(Brian);

                //_UnitOfWork.Bys.DeleteRange(Aarhus);
                //_UnitOfWork.Addresses.Delete(Hjem);
                //_UnitOfWork.Addresses.Delete(Arbejde);
                //_UnitOfWork.Addresses.Delete(Sommerhus);

                //_UnitOfWork.Save();
                //_UnitOfWork.Dispose();
                
                #endregion
            }
            Console.WriteLine("Donzo!");
            Console.ReadKey();
        }
    }
}
