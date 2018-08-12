using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Framework.DAO.Interfaces
{
    public interface IEntityDAO<TContext, TKey, TDomain> : IDAO<TKey, TDomain>
        where TContext : DbContext
        where TDomain : class
    {
        TDomain GetReference(TKey id);
    }

    public interface IEntityDAO<TContext, TKey, TDomain, TCriteria> : IEntityDAO<TContext, TKey, TDomain>, IDAO<TKey, TDomain, TCriteria>
        where TContext : DbContext
        where TDomain : class
        where TCriteria : class
    {

    }
}
