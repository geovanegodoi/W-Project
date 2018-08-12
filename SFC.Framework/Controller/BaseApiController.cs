using SFC.Framework.BO.Interfaces;
using SFC.Framework.Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SFC.Framework.Controller
{
    public abstract class BaseApiController<TKey, TModel, TBO> : ApiController, IApiController<TKey, TModel>
        where TModel : class
        where TBO : IBO<TKey, TModel>
    {
        public TBO DefaultBO { get; set; }

        [HttpGet]
        public IHttpActionResult Get(TKey id)
        {
            IHttpActionResult httpResult = NotFound();
            try
            {
                httpResult = Ok(DefaultBO.Get(id));
            }
            catch (KeyNotFoundException)
            {
                httpResult = NotFound();
            }
            return httpResult;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            IHttpActionResult httpResult = NotFound();
            try
            {
                httpResult = Ok(DefaultBO.List());
            }
            catch (KeyNotFoundException)
            {
                httpResult = NotFound();
            }
            return httpResult;
        }

        [HttpPost]
        [HttpPut]
        public IHttpActionResult Save(TModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = DefaultBO.Save(model);

            return Created(new Uri(Request.RequestUri + "/" + result), result);
        }

        [HttpDelete]
        public void Delete(TKey id)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                DefaultBO.Delete(id);
            }
            catch (KeyNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}
