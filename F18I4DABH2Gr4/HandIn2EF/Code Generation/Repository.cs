using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HandIn2EF;


    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PKKontekst Context;
        private readonly DbSet<TEntity> _entities;

        protected Repository(PKKontekst context)
        {
            Context = context;
            _entities = context.Set<TEntity>();
        }



    public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }
}




