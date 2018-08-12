using SFC.Framework.BO.Interfaces;
using SFC.Tunning.TO;
using SFC.Wip.Interfaces;
using SFC.Wip.TO;

namespace SFC.Tunning.Interfaces
{
    public interface ITunningBO : IBO<long, TunningTO>
    {
        void DoCheckIn(long wipId);

        void DoCheckOut(long wipId);
    }
}
