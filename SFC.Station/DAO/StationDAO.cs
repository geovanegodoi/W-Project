using SFC.Station.Interfaces;
using SFC.Framework.DAO;
using SFC.Framework.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Station.DAO
{
    public class StationDAO : BaseEntityDAO<StationContext, long, Domain.Station>, IStationDAO
    {
        // New specific DAO logic        
    }
}