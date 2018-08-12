using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SFC.Framework.Controller.Interfaces
{
    public interface IApiController<TKey, TModel>
    {
        IHttpActionResult Get(TKey id);
        IHttpActionResult Get();
        IHttpActionResult Save(TModel model);
        void Delete(TKey id);
    }
}
