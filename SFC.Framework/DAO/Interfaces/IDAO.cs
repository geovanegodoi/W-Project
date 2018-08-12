using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Framework.DAO.Interfaces
{
    public interface IDAO
    {
    }

    public interface IDAO<TKey, TDomain>
        where TDomain : class
    {
        TDomain Get(TKey id);
        IEnumerable<TDomain> List();
        TKey Save(TDomain domain);
        void Delete(TDomain domain);
        void Delete(TKey id);
    }

    public interface IDAO<TKey, TDomain, TCriteria> : IDAO<TKey, TDomain>
        where TDomain : class
        where TCriteria : class
    {
        IEnumerable<TDomain> Search(TCriteria criteria);
    }
}
