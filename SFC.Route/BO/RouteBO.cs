using SFC.Route.Interfaces;
using SFC.Route.TO;
using SFC.Station.Interfaces;
using SFC.Wip.Interfaces;
using SFC.Framework.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Route.BO
{
    public class RouteBO : BaseBO<long, RouteTO, Domain.Route, IRouteDAO>, IRouteBO
    {
        public IWipBO WipBO { get; set; }
        public IStationBO StationBO { get; set; }

        public RouteBO()
        {
            var wip = WipBO.Get(1);
            
            foreach (var station in StationBO.List())
            {
                WipBO.CheckNextStation(wip.Id, station);
            }
        }
    }
}
