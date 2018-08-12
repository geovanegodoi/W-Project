using SFC.Framework.DAO.Interfaces;

namespace SFC.Tunning.Interfaces
{
    public interface ITunningDAO : IAdoDAO<long, Domain.Tunning>
    {
        void DoCheckIn(Wip.Domain.Wip domain);

        void DoCheckOut(Wip.Domain.Wip domain);
    }
}
