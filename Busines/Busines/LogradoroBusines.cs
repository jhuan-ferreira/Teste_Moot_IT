using System.Collections.Generic;
using Data.Entity;
using Data.Infraesture;

namespace Busines.Busines
{
    public class LogradoroBusines
    {
        public List<Logradouro> GetAll()
        {
            using (var _db = new SqlUnityOfWork())
            {
                return _db.LogradouroRepository.GetAll();
            }
        }

        public Logradouro GetById(int id)
        {
            using (var _db = new SqlUnityOfWork())
            {
                return _db.LogradouroRepository.GetById(id);
            }
        }

        public bool Save(Logradouro logradouro)
        {
            using (var _db = new SqlUnityOfWork())
            {
                return _db.LogradouroRepository.Save(logradouro);
            }
        }

        public bool Delete(Logradouro logradouro)
        {
            using (var _db = new SqlUnityOfWork())
            {
                return _db.LogradouroRepository.Delete(logradouro);
            }
        }
    }
}
