using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Framework.Enumerations
{
    public enum ProcedureParameterDirection
    {
        In,
        Out,
        InOut
    }

    public enum ProcedureParameterType
    {
        VarChar,
        Number,
        RefCursor
    }
}
