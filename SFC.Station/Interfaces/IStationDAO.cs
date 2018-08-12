using SFC.Station.DAO;
using SFC.Framework.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Station.Interfaces
{
    public interface IStationDAO : IEntityDAO<StationContext, long, Domain.Station>
    {

    }
}