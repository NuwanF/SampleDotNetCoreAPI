using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> GetAll();
        TEntity GetFirstOrDefault(object id);
    }
}
