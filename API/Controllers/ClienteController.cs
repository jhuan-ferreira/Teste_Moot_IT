using System.Collections.Generic;
using System.Web.Http;
using Data.Entity;
using Busines.Busines;

namespace API.Controllers
{
    public class ClienteController : ApiController
    {
        public List<Cliente> GetCliente(int? id)
        {
            var clienteBusines = new ClienteBusines();

            if (id != null)
            {
                var listaCliente = new List<Cliente>();
                listaCliente.Add(clienteBusines.GetById(id.Value));

                return listaCliente;
            }
            else
            {
                return clienteBusines.GetAll();
            }
        }

        public IHttpActionResult PostCliente(Cliente cliente)
        {
            new ClienteBusines().Save(cliente);

            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCliente(int id)
        {
            var clienteBusines = new ClienteBusines();
            var cliente = clienteBusines.GetById(id);

            clienteBusines.Delete(cliente);

            return Ok();
        }

    }
}