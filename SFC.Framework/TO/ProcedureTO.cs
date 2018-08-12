using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Framework.TO
{
    public class ProcedureTO
    {
        public string Name { get; set; }

        public int Index { get; set; }

        public ICollection<ProcedureParameterTO> Parameters { get; set; }
    }
}
