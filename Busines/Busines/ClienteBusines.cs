using Data.Infraesture;
using System.Collections.Generic;
using Data.Entity;

namespace Busines.Busines
{
    public class ClienteBusines
    {
        public List<Cliente> GetAll()
        {
            using (var _db = new SqlUnityOfWork())
            {
                return _db.ClienteRepository.GetAll();
            }
        }

        public Cliente GetById(int id)
        {
            using (var _db = new SqlUnityOfWork())
            {
                return _db.ClienteRepository.GetById(id);
            }
        }

        public bool Save(Cliente cliente)
        {
            using (var _db = new SqlUnityOfWork())
            {
                return _db.ClienteRepository.Save(cliente);
            }
        }

        public bool Delete(Cliente cliente)
        {
            using (var _db = new SqlUnityOfWork())
            {
                var logradoros = _db.LogradouroRepository.GetAll();
                var listaLogradoros = logradoros;

                foreach (var item in logradoros)
                {
                    _db.LogradouroRepository.Delete(item);
                }

                return _db.ClienteRepository.Delete(cliente);
            }
        }
    }
}
