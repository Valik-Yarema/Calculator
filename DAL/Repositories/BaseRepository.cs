using Interface.InterfacesDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
       public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
       {
        protected readonly ApplicationDbContext context;
        private DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationDbContext mainDbContext)
        {
            context = mainDbContext;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
           return await dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(int page, int countOnPage)
        {
           
            return await dbSet.Skip((page - 1) * countOnPage).Take(countOnPage).ToListAsync();
        }

        //       public virtual async Task<TEntity> GetById(Guid id)
        public virtual async Task<TEntity> GetById(Guid id)

        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetFiltered(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetFiltered(int page, int countOnPage,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                var entity = orderBy(query);
               
                return await entity.Skip((page - 1) * countOnPage).Take(countOnPage).ToListAsync();
            }
            else
            {
               
                return await query.Skip((page - 1) * countOnPage).Take(countOnPage).ToListAsync();
            }
        }

        public virtual async Task Insert(TEntity entity)
        {
           await dbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
            }
            catch { }
            finally
            {
                dbSet.Update(entityToUpdate);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void SetStateModified(TEntity entity)
        {
            context.Entry<TEntity>(entity).State= EntityState.Modified;
        }

       
    }
}
