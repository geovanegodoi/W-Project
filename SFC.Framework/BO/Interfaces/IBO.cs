using System.Collections.Generic;

namespace SFC.Framework.BO.Interfaces
{
    public interface IBO { }

    public interface IBO<TKey, TModel> : IBO
        where TModel : class
    {
        TModel Get(TKey id);
        IEnumerable<TModel> List();
        TKey Save(TModel model);
        void Delete(TModel model);
        void Delete(TKey id);
    }

    public interface IBO<TKey, TModel, TCriteria> : IBO<TKey, TModel>
        where TModel : class
        where TCriteria : class
    {
        IEnumerable<TModel> Search(TCriteria criteria);
    }
}
