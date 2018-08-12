using AutoMapper;
using SFC.Framework.BO.Interfaces;
using SFC.Framework.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFC.Framework.BO
{
    public abstract class BaseBO<TKey, TModel, TDomain, TDAO> : IBO<TKey, TModel>
        where TModel : class
        where TDomain : class
        where TDAO : IDAO<TKey, TDomain>
    {
        public TDAO DefaultDAO { get; set; }

        public TModel Get(TKey id)
        {
            var domain = DefaultDAO.Get(id);

            if (domain == null)
                throw new KeyNotFoundException();

            return Mapper.Map<TModel>(domain);
        }

        public IEnumerable<TModel> List()
        {
            var domain = DefaultDAO.List();

            if (domain == null)
                throw new KeyNotFoundException();

            return Mapper.Map<IEnumerable<TModel>>(domain);
        }

        public TKey Save(TModel model)
        {
            TDomain domain = Mapper.Map<TDomain>(model);
            return DefaultDAO.Save(domain);
        }

        public void Delete(TKey id)
        {
            DefaultDAO.Delete(id);
        }

        public void Delete(TModel model)
        {
            var domain = Mapper.Map<TDomain>(model);
            DefaultDAO.Delete(domain);
        }

    }

    public abstract class BaseBO<TKey, TModel, TDomain, TCriteria, TDAO> : BaseBO<TKey, TModel, TDomain, TDAO>, IBO<TKey, TModel, TCriteria>
        where TModel : class
        where TDomain : class
        where TCriteria : class
        where TDAO : IDAO<TKey, TDomain, TCriteria>
    {
        public IEnumerable<TModel> Search(TCriteria criteria)
        {
            var domain = DefaultDAO.Search(criteria);
            return Mapper.Map<IEnumerable<TModel>>(domain);
        }
    }
}
