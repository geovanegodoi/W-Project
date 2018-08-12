using SFC.Route.DAO;
using SFC.Framework.DAO.Interfaces;

namespace SFC.Route.Interfaces
{
    public interface IRouteDAO : IEntityDAO<RouteContext, long, Domain.Route>
    {
    }
}
