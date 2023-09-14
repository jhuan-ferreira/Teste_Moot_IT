using System.Collections.Generic;
using System.Web.Http;
using Data.Entity;
using Busines.Busines;
using System.Linq;

namespace API.Controllers
{
    public class LogradouroController : ApiController
    {
        public List<Logradouro> GetLogradouro(int? id, int? ClienteId)
        {
            var logradoroBusines = new LogradoroBusines();

            if (id != null)
            {
                var listaLogradouro = new List<Logradouro>();

                listaLogradouro.Add(logradoroBusines.GetById(id.Value));
                return listaLogradouro;
            }
            else
            {
                return logradoroBusines.GetAll().Where(x => x.ClienteId == ClienteId).ToList();
            }
        }

        public IHttpActionResult PostLogradouro(Logradouro logradouro)
        {
            var logradoroBusines = new LogradoroBusines();

            logradoroBusines.Save(logradouro);

            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteLogradouro(int id)
        {
            var logradoroBusines = new LogradoroBusines();

            var logradouro = logradoroBusines.GetById(id);

            logradoroBusines.Delete(logradouro);

            return Ok();
        }
    }
}