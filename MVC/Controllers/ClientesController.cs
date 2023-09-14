using System.Linq;
using System.Web.Mvc;
using Data.Entity;
using API.Command;

namespace MVC.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Index()
        {
            return View(new ClienteApi().GetCliente(null));
        }

        public ActionResult Cliente(int? id, bool? novoCliente)
        {
            if (novoCliente.GetValueOrDefault())
                return View();
            else
                return View(new ClienteApi().GetCliente(id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Cliente(Cliente cliente)
        {
            new ClienteApi().SaveCliente(cliente);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new ClienteApi().DeleteCliente(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult _logradouro(int? idLogradouro, int? clienteId)
        {
            var lista = new LogradouroApi().GetLogradouro(idLogradouro, clienteId);
            return PartialView(lista);
        }

        [HttpPost]
        public ActionResult _logradouro(int logradouroId, string LogradouroNome, int? clienteId)
        {
            if (!string.IsNullOrEmpty(LogradouroNome) && clienteId != null)
            {
                var logradouro = new Logradouro() { LogradouroId = logradouroId, ClienteId = clienteId.Value, LogradouroNome = LogradouroNome };

                new LogradouroApi().SaveLogradouro(logradouro);
            }

            return Json("Ok");
        }

        [HttpGet]
        public ActionResult DeleteLogradoro(int id, int clienteId)
        {
            new LogradouroApi().DeleteLogradoro(id);

            return RedirectToAction("Cliente", new { id = clienteId });
        }

    }
}