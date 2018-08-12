using SFC.Tunning.Interfaces;
using SFC.Framework.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFC.Tunning.Domain;

namespace SFC.Tunning.DAO
{
    public class TunningDAO : BaseAdoDAO<long, Domain.Tunning>, ITunningDAO
    {
        public override Domain.Tunning Get(long id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Domain.Tunning> List()
        {
            throw new NotImplementedException();
        }

        public override long Save(Domain.Tunning domain)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Domain.Tunning domain)
        {
            throw new NotImplementedException();
        }

        public override void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void DoCheckIn(Wip.Domain.Wip domain)
        {
            throw new NotImplementedException();
        }

        public void DoCheckOut(Wip.Domain.Wip domain)
        {
            throw new NotImplementedException();
        }
    }
}
