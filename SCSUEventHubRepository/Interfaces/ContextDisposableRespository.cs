using SCSUEventHubRepository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubRepository.Interfaces
{
    abstract public class ContextDisposableRespository
    {
        protected EventHubDBEntities DBContext { get; private set; }
        protected bool disposed = false;

        public ContextDisposableRespository()
        {
            DBContext = new EventHubDBEntities();
        }

        public ContextDisposableRespository(EventHubDBEntities contextParam)
        {
            DBContext = contextParam;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                DBContext.Dispose();
            }

            disposed = true;
        }
    }
}
