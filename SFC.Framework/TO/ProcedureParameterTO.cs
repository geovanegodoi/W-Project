using SFC.Framework.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Framework.TO
{
    public class ProcedureParameterTO
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public ProcedureParameterType Type { get; set; }

        public ProcedureParameterDirection Direction { get; set; }
    }
}
