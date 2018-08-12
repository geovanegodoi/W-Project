using SFC.Framework.DAO.Interfaces;
using SFC.Framework.Enumerations;
using SFC.Framework.Extensions;
using SFC.Framework.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace SFC.Framework.DAO
{
    public abstract class BaseAdoDAO<TKey, TDomain> : IAdoDAO<TKey, TDomain>
        where TDomain : class
    {
        protected const string SchemaDB = "schema_name";

        private static bool TestConnection = false;

        public BaseAdoDAO()
        {
            if (TestConnection)
            {
                DbCommandSelect("SELECT SYSDATE FROM DUAL");
                TestConnection = false;
            }
        }

        public DbConnection CreateDbConnection()
        {
            // Assume failure.
            DbConnection connection = null;
            var connectionSettings = ConfigurationManager.ConnectionStrings["FXConnection"];
            var connectionString = connectionSettings.ConnectionString;
            var providerName = connectionSettings.ProviderName;

            // Create the DbProviderFactory and DbConnection.
            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(providerName))
            {
                try
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                throw new ApplicationException("Validar arquivo de configuração! ConnectionStrings e ProviderName");
            }
            return connection;
        }

        public DataTable DbCommandSelect(string queryString)
        {
            var dataTable = new DataTable();

            using (var connection = CreateDbConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = queryString;
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        dataTable = reader.ToDatatable();
                    }
                }
            }
            return dataTable;
        }

        public void DbCommandNonquery(string nonQueryString)
        {
            using (var connection = CreateDbConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = nonQueryString;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DbCommandProcedure(ProcedureTO to)
        {
            using (var connection = CreateDbConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "FXUSER." + to.Name;
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    foreach (var item in to.Parameters)
                    {
                        switch (item.Direction)
                        {
                            case ProcedureParameterDirection.In:
                                command.AddInputParameter(item.Name, item.Value, item.Type);
                                break;
                            case ProcedureParameterDirection.Out:
                                command.AddOutputParameter(item.Name, item.Type);
                                break;
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public abstract TDomain Get(TKey id);
        public abstract IEnumerable<TDomain> List();
        public abstract TKey Save(TDomain domain);
        public abstract void Delete(TKey id);
        public abstract void Delete(TDomain domain);
    }

    public abstract class BaseAdoDAO<TKey, TDomain, TCriteria> : BaseAdoDAO<TKey, TDomain>, IAdoDAO<TKey, TDomain, TCriteria>
        where TDomain : class
        where TCriteria : class
    {
        public abstract IEnumerable<TDomain> Search(TCriteria criteria);
    }
}
