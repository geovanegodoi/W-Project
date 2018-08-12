using SFC.Wip.Interfaces;
using SFC.Wip.TO;
using SFC.Framework.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFC.Station.TO;

namespace SFC.Wip.BO
{
    public class WipBO : BaseBO<long, WipTO, Domain.Wip, IWipDAO>, IWipBO
    {
        public bool CheckNextStation(long id, StationTO station)
        {
            throw new NotImplementedException();
        }
    }
}
