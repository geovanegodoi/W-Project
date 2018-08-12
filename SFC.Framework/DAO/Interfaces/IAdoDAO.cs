using SFC.Framework.TO;
using System.Data;
using System.Data.Common;

namespace SFC.Framework.DAO.Interfaces
{
    public interface IAdoDAO<TKey, TDomain> : IDAO<TKey, TDomain>
        where TDomain : class
    {
        DbConnection CreateDbConnection();
        DataTable DbCommandSelect(string query);
        void DbCommandNonquery(string nonQuery);
        void DbCommandProcedure(ProcedureTO to);
    }

    public interface IAdoDAO<TKey, TDomain, TCriteria> : IAdoDAO<TKey, TDomain>, IDAO<TKey, TDomain, TCriteria>
        where TDomain : class
        where TCriteria : class
    {

    }
}