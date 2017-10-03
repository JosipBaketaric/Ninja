using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ninja.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

         public GenericRepository(DbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Tracking method.
        /// Use Find for non tracking bost.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(int id)
        {

            try
            {
                if (id == null || id < 0)
                {
                    throw new ArgumentNullException("Id not valid");
                }

                return this.Context.Set<TEntity>().Find(id);
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Without tracking method!
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return this.Context.Set<TEntity>().AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Without tracking method!
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {
                    throw new ArgumentNullException("Predicate not valid");
                }

                return this.Context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        /// <summary>
        /// Without tracking method!
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity FindOne(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {
                    throw new ArgumentNullException("Predicate not valid");
                }

                return this.Context.Set<TEntity>().AsNoTracking().Where(predicate).FirstOrDefault(); ;
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Entity not valid");
                }

                this.Context.Set<TEntity>().Add(entity);
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// Without tracking method!
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Entity not valid");
                }

                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("Entities not valid");
                }

                this.Context.Set<TEntity>().AddRange(entities);
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// Without tracking method!
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Entitiy not valid");
                }

                this.Context.Entry(entity).State = EntityState.Deleted;
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// Without tracking method!
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("Entities not valid");
                }

                this.Context.Entry(entities).State = EntityState.Deleted;
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }




    }
}
