using Core.Entites;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var addedEntity = db.Entry<TEntity>(entity);
                addedEntity.State = EntityState.Added;
                db.SaveChanges();

                return entity;
            }
        }

        public bool Delete(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var addedEntity = db.Entry<TEntity>(entity);
                addedEntity.State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext db = new TContext())
            {
                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext db = new TContext())
            {
                return filter == null
                              ? db.Set<TEntity>().ToList()
                              : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var addedEntity = db.Entry<TEntity>(entity);
                addedEntity.State = EntityState.Modified;
                db.SaveChanges();

                return entity;
            }
        }
    }
}
