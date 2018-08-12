using SFC.Station.Domain;
using SFC.Station.Interfaces;
using SFC.Station.TO;
using SFC.Framework.BO;

namespace SFC.Station.BO
{
    public class StationBO : BaseBO<long, StationTO, Domain.Station, IStationDAO>, IStationBO
    {
        public StationBO()
        {
            
        }
    }
}
