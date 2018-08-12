using SFC.Framework.Enumerations;
using System.Data;

namespace SFC.Framework.Extensions
{
    internal static class EnumExtensions
    {        
        public static DbType ToDbType(this ProcedureParameterType value)
        { 
            switch(value)
            {
                case ProcedureParameterType.VarChar : return DbType.String;
                case ProcedureParameterType.Number  : return DbType.Int32;
                default                             : return DbType.Object;
            }
        }

        public static ParameterDirection ToDbDirection(this ProcedureParameterDirection value)
        {
            switch(value)
            {
                case ProcedureParameterDirection.In  : return ParameterDirection.Input;
                case ProcedureParameterDirection.Out : return ParameterDirection.Output;
                default                              : return ParameterDirection.InputOutput;
            }
        }

        public static ProcedureParameterType ToParameterType(this string value)
        {
            if (value.Equals("VARCHAR2"))
                return ProcedureParameterType.VarChar;
            else if (value.Equals("NUMBER"))
                return ProcedureParameterType.Number;
            else
                return ProcedureParameterType.RefCursor;
        }

        public static ProcedureParameterDirection ToParameterDirection(this string value)
        {
            if (value.ToUpper().Equals("IN"))
                return ProcedureParameterDirection.In;
            else if (value.ToUpper().Equals("OUT"))
                return ProcedureParameterDirection.Out;
            else
                return ProcedureParameterDirection.InOut;
        }
    }
}