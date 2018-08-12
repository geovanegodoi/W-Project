using SFC.Route.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFC.Route.Domain;
using SFC.Framework.DAO;

namespace SFC.Route.DAO
{
    public class RouteDAO : BaseEntityDAO<RouteContext, long, Domain.Route>, IRouteDAO
    {
        
    }
}
