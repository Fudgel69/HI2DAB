using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using HandIn2.Repository;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace HandIn2
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private const string EndpointUrl = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private readonly DocumentClient _client;
        private readonly string _collectionId;
        private readonly string _databaseId;

        public Repository(string dbId, string collectionId)
        {
            _collectionId = collectionId;
            _databaseId = dbId;

            _client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);

            _client.CreateDatabaseIfNotExistsAsync(new Database { Id = _databaseId });
            _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_databaseId), new DocumentCollection { Id = _collectionId });
        }
        public TEntity Get(int id)
        {
            try
            {
                Document document =
                    _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, id.ToString())).Result;
                return (TEntity)(dynamic)document;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public IEnumerable<TEntity> GetAll()
        {
            IDocumentQuery<TEntity> query = _client
                .CreateDocumentQuery<TEntity>(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId))
                .AsDocumentQuery();

            List<TEntity> results = new List<TEntity>();
            while (query.HasMoreResults)
            {
                results.AddRange(query.ExecuteNextAsync<TEntity>().Result);
            }

            return results;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IDocumentQuery<TEntity> query = _client
                .CreateDocumentQuery<TEntity>(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId))
                .Where(predicate).AsDocumentQuery();
            List<TEntity> results = new List<TEntity>();
            while (query.HasMoreResults)
            {
                results.AddRange(query.ExecuteNextAsync<TEntity>().Result);
            }

            return results;
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId), entity);

        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Add(entity);
            }
        }

        public void Remove(TEntity entity)
        {
            Type type = entity.GetType();

            PropertyInfo property = type.GetProperty("Id");

            string id = property.GetValue(entity, null).ToString();

            _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, id));
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity person in entities)
            {
                Remove(person);
            }
        }
    }
}