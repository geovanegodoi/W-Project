using SFC.Wip.Interfaces;
using SFC.Framework.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFC.Wip.Domain;

namespace SFC.Wip.DAO
{
    public class WipDAO : BaseAdoDAO<long, Domain.Wip>, IWipDAO
    {
        public override Domain.Wip Get(long id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Domain.Wip> List()
        {
            throw new NotImplementedException();
        }

        public override long Save(Domain.Wip domain)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Domain.Wip domain)
        {
            throw new NotImplementedException();
        }

        public override void Delete(long id)
        {
            throw new NotImplementedException();
        }

    }
}
