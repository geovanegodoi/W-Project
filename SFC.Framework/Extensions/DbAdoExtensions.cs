using SFC.Framework.Enumerations;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SFC.Framework.Extensions
{
    internal static class DbAdoExtensions
    {
        public static void AddInputParameter(this DbCommand command, string name, object value, ProcedureParameterType type)
        {
            var parameter           = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value         = value;
            parameter.Direction     = ParameterDirection.Input;
            command.Parameters.Add(parameter);
        }
        
        public static void AddOutputParameter(this DbCommand command, string name, ProcedureParameterType type)
        {
            if (command.GetType().FullName.Contains("OracleCommand"))
            {
                OracleParameter parameter = (OracleParameter)command.CreateParameter();
                parameter.ParameterName   = name;
                parameter.Direction       = ParameterDirection.Output;
                if (type == ProcedureParameterType.VarChar)
                {
                    //parameter.OracleDbType = OracleDbType.Varchar2;
                    parameter.Size         = 255;
                }
                else if (type == ProcedureParameterType.RefCursor)
                {
                    parameter.OracleDbType = OracleDbType.RefCursor;
                }                
                command.Parameters.Add(parameter);

            }
            else if (command.GetType().FullName.Contains("SqlCommand"))
            {
                SqlParameter parameter    = (SqlParameter)command.CreateParameter();
                parameter.ParameterName   = name;
                parameter.Direction       = ParameterDirection.Output;
                command.Parameters.Add(parameter);
            }
        }

        public static DataTable ToDatatable(this DbDataReader reader)
        {
            DataTable tbReference = reader.GetSchemaTable();
            DataTable tbResult    = new DataTable();

            foreach (DataRow row in tbReference.Rows)
            {
                if (!tbResult.Columns.Contains(row["ColumnName"].ToString()))
                {
                    DataColumn col = new DataColumn()
                    {
                        ColumnName = row["ColumnName"].ToString(),
                    };
                    tbResult.Columns.Add(col);
                }
            }
            while (reader.Read())
            {
                DataRow newLine = tbResult.NewRow();
                for (int i = 0; i < tbResult.Columns.Count; i++)
                {
                    newLine[i] = reader.GetValue(i);
                }
                tbResult.Rows.Add(newLine);
            }
            return tbResult;
        }
    }
}