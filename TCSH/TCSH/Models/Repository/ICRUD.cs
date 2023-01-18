using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCSH.Models.Repository
{
    public interface ICRUD<TEntity>
    {
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        TEntity find(int id);
        List<TEntity> List();
    }
}
