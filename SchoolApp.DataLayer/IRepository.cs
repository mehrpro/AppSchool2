using System.Collections.Generic;

namespace SchoolApp.DataLayer
{
    public interface IRepository<TEntity>
    
    {
        int Add(TEntity entity);
        int Remove(TEntity entity);
        int Update(TEntity entity);
        TEntity Find(params object[] keys);
        List<TEntity> All();

    }
}