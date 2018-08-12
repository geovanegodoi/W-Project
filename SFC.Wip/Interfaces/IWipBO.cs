using SFC.Station.TO;
using SFC.Wip.TO;
using SFC.Framework.BO.Interfaces;

namespace SFC.Wip.Interfaces
{
    public interface IWipBO : IBO<long, WipTO>
    {
        bool CheckNextStation(long id, StationTO station);
    }
}
