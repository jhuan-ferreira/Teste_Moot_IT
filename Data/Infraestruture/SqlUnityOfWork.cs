using System;
using Data.Repository;
using Data.IRepository;
using Data.Infraestruture;

namespace Data.Infraesture
{
    public class SqlUnityOfWork : IDisposable
    {
        private readonly Mootit_DbContext _dbContext = new Mootit_DbContext();

        #region Repository
        private IClienteRepository _clienteRepository;
        private ILogradouroRepository _logradouroRepository;
        #endregion

        #region Construtor Repository
        public IClienteRepository ClienteRepository
        {
            get { return _clienteRepository = new ClienteRepository(_dbContext); }
        }

        public ILogradouroRepository LogradouroRepository
        {
            get { return _logradouroRepository = new LogradouroRepository(_dbContext); }
        }
        #endregion

        #region Dispose Repository
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            if (_clienteRepository != null) { _clienteRepository.Dispose(); _clienteRepository = null; }
            if (_logradouroRepository != null) { _logradouroRepository.Dispose(); _logradouroRepository = null; }

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
