using SFC.Tunning.Interfaces;
using SFC.Tunning.TO;
using SFC.Framework.BO;
using System;
using SFC.Wip.TO;
using SFC.Wip.Interfaces;
using AutoMapper;

namespace SFC.Tunning.BO
{
    public class TunningBO : BaseBO<long, TunningTO, Domain.Tunning, ITunningDAO>, ITunningBO
    {
        public IWipBO WipBO { get; set; }

        public void DoCheckIn(long wipId)
        {
            var wip = WipBO.Get(wipId);
            var domain = Mapper.Map<Wip.Domain.Wip>(wip);
            DefaultDAO.DoCheckIn(domain);
        }

        public void DoCheckOut(long wipId)
        {
            var wip = WipBO.Get(wipId);
            var domain = Mapper.Map<Wip.Domain.Wip>(wip);
            DefaultDAO.DoCheckIn(domain);
        }
    }
}
