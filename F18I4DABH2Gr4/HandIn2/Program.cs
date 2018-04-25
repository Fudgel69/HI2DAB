using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Runtime.CompilerServices;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace HandIn2
{
    class Program
    {
        private const string EndpointUrl = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private DocumentClient client;

        static void Main(string[] args)
        {

            try
            {
                Program p = new Program();
                p.GetStartedDemo().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }

            //using (var db = new PKKontekst())
            //{

            //    if (!db.Personkartoteker.Any())
            //    {
            //        var kart = new Personkartotek() { PersonkartotekId = 1 };
            //        db.Personkartoteker.Add(kart);
            //        db.SaveChanges();
            //        Console.WriteLine("Heyo!");
            //    }
            //    /*
            //    db.Byer.AddOrUpdate(new By(){Postnummer = 7830, Bynavn = "Sevel"});
            //    db.SaveChanges();
                
            //    db.Adresser.AddOrUpdate(new Adresse(){Byer = db.Byer.Find(3), Husnummer = 22, Vejnavn = "Vesterpik", Type = "Sommerhus"});
            //    db.Adresser.AddOrUpdate(new Adresse() { Byer = db.Byer.Find(4), Husnummer = 2, Vejnavn = "Vestorerpik", Type = "Hjem" });
            //    db.SaveChanges();

            //    db.Telefoner.AddOrUpdate(new Telefon(){Nummer = 88888888, Teleselskab = "Telia", Type = "Arbejde"});
            //    db.Telefoner.AddOrUpdate(new Telefon() { Nummer = 12345678, Teleselskab = "Telenor", Type = "Privat" });
            //    db.SaveChanges();

            //    List<Telefon> PetersTelefoner = new List<Telefon>() ;
            //    PetersTelefoner.Add(db.Telefoner.Find(1));
            //    PetersTelefoner.Add(db.Telefoner.Find(2));

            //    db.Personer.AddOrUpdate(new Person()
            //    {
            //        Fornavn = "Peter",
            //        Mellemnavn = "Lundin",
            //        Efternavn = "Madsen",
            //        Email = "peter@peter.dk",
            //        PersTelefon = PetersTelefoner,
            //        PrimAdresse = db.Adresser.Find(3),
            //        SekAdresse = null,
            //        Type = "Ansat"
            //    });
            //    db.SaveChanges();
            //    var p = new Person();
            //    db.Personkartoteker.Find(1).Bekendte.Add(db.Personer.Find(1));
            //    Console.WriteLine("Penis");
            // */
            //    Console.WriteLine("Fundet i personkartotekets forreste plads er:");
            //    Console.WriteLine($"Fornavn: {db.Personer.Find(1).Fornavn}");
            //    Console.WriteLine($"Mellemnavn: {db.Personer.Find(1).Mellemnavn}");
            //    Console.WriteLine($"Efternavn: {db.Personer.Find(1).Efternavn}");
            //    Console.WriteLine($"Email: {db.Personer.Find(1).Email}");
            //    Console.WriteLine($"Type: {db.Personer.Find(1).Type}");
            //    Console.WriteLine($"By: {db.Byer.Find(3).Bynavn}");
            //    Console.WriteLine($"Hjemmetelefon: {db.Telefoner.Find(2).Nummer}");
            //}
        }


        private async Task GetStartedDemo()
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);

            await this.client.CreateDatabaseIfNotExistsAsync(new Microsoft.Azure.Documents.Database { Id = "NytKartotek" });
            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("NytKartotek"), new DocumentCollection { Id = "Birgits Kartotek" });

            By Sevel = new By { Bynavn = "Sevel", Postnummer = 7830};
            By Holstebro = new By { Bynavn = "Holstebro", Postnummer = 7500 };

            #region BoNyPerson

            //Lægger personen Bo ind som et dokument
            Person BoPerson = new Person
            {
                CPR = "022333-0101",
                Fornavn = "Bo",
                Mellemnavn = "Bent",
                Efternavn = "Andersen",
                Email = "Bo.Andersen@hotmail.com",
                Type = "Far",

                PersTelefon = new List<Telefon>
                {
                    new Telefon
                    {
                        Nummer = 88888888,
                        Teleselskab = "Telia",
                        Type = "Arbejdstelefon"
                    },

                    new Telefon
                    {
                        Nummer = 12345678,
                        Teleselskab = "Sonofon",
                        Type = "Hustelefon"
                    }
                },

                PrimAdresse = new Adresse
                {
                    Vejnavn = "Klosterheden",
                    Husnummer = 12,
                    Type = "Privat",
                    Byer = Sevel
                },

                SekAdresse = new List<Adresse>
                {
                    new Adresse
                    {
                        Vejnavn = "Sommerhusvej" ,
                        Husnummer = 15 ,
                        Type = "Sommerhus" ,
                        Byer = Holstebro
                    },

                    new Adresse
                    {
                        Vejnavn = "Arbejdervænget" ,
                        Husnummer = 2 ,
                        Type = "Arbejde" ,
                        Byer = Holstebro
                    },

                }
            };

            await this.CreatePersonDocumentIfNotExists("NytKartotek", "Birgits Kartotek", BoPerson);


            #endregion

            #region PeterNyPerson
            Person PeterPerson = new Person
            {
                CPR = "123456-0203",
                Fornavn = "Peter",
                Mellemnavn = "",
                Efternavn = "Andersen",
                Email = "Peter.Andersen@hotmail.com",
                Type = "Søn",

                PersTelefon = new List<Telefon>
                {
                    new Telefon
                    {
                        Nummer = 99999999,
                        Teleselskab = "Telia",
                        Type = "Privat"
                    },
                },

                PrimAdresse = new Adresse
                {
                    Vejnavn = "Klostertorvet",
                    Husnummer = 15,
                    Type = "Privat",
                    Byer = Holstebro
                },

                SekAdresse = new List<Adresse>
                {

                }
            };

            await this.CreatePersonDocumentIfNotExists("NytKartotek", "Birgits Kartotek", PeterPerson);


            #endregion

            BoPerson.Mellemnavn = "Søby";

            await this.ReplacePersonDocument("NytKartotek", "Birgits Kartotek", "022333-0101", BoPerson);

            this.ExecuteSimpleQuery("NytKartotek", "Birgits Kartotek");

            await this.DeleteFamilyDocument("NytKartotek", "Birgits Kartotek", "123456-0203");

            await this.client.DeleteDatabaseAsync(UriFactory.CreateDatabaseUri("NytKartotek"));

        }

        #region ConsolePrompt
        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }


        #endregion

        #region CreatePersonDocumentIfNotExists

        private async Task CreatePersonDocumentIfNotExists(string databaseName, string collectionName, Person _person)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, _person.CPR));
                this.WriteToConsoleAndPromptToContinue("Found {0}", _person.CPR);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), _person);
                    this.WriteToConsoleAndPromptToContinue("Created Person: {0}", _person.CPR);
                }
                else
                {
                    throw;
                }
            }
        }

        #endregion

        #region ExecSimpleQuery

        //Exec Simple Query
        private void ExecuteSimpleQuery(string databaseName, string collectionName)
        {
            // Set some common query options
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            // Here we find the Andersen family via its LastName
            IQueryable<Person> personQuery = this.client.CreateDocumentQuery<Person>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
                .Where(f => f.Efternavn == "Petersen");

            // The query is executed synchronously here, but can also be executed asynchronously via the IDocumentQuery<T> interface
            Console.WriteLine("Running LINQ query...");
            foreach (Person pers in personQuery)
            {
                Console.WriteLine("\tRead {0}", pers);
            }

            // Now execute the same query via direct SQL
            IQueryable<Person> personQuerySql = this.client.CreateDocumentQuery<Person>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                "SELECT * FROM Persons WHERE Persons.Efternavn = 'Petersen'",
                queryOptions);

            Console.WriteLine("Running direct SQL query...");
            foreach (Person pers in personQuerySql)
            {
                Console.WriteLine("\tRead {0}", pers);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        #endregion

        #region ReplacePersonDocument

        private async Task ReplacePersonDocument(string databaseName, string collectionName, string CPR, Person updatePerson)
        {
            await this.client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, CPR), updatePerson);
            this.WriteToConsoleAndPromptToContinue("Replaced Person: {0}", CPR);
        }

        #endregion

        #region DeleteDoc
        private async Task DeleteFamilyDocument(string databaseName, string collectionName, string documentName)
        {
            await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, documentName));
            Console.WriteLine("Deleted Person {0}", documentName);
        }

        #endregion

    }
}
