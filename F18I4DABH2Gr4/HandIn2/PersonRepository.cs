namespace HandIn2
{
    class PersonRepository : Repository<Person>
    {
        public PersonRepository(string dbId, string collectionId)
            : base(dbId, collectionId)
        {

        }
        public void ReplacePersonDocument(Person updatedPerson)
        {

        }
    }
}