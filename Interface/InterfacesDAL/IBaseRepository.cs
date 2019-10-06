using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfacesDAL
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(int page, int countOnPage);
        // Task<TEntity> GetById(Guid id);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetFiltered(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<IEnumerable<TEntity>> GetFiltered(int page, int countOnPage,
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>,
               IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");
        Task Insert(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        void SetStateModified(TEntity entity);
    }
}
