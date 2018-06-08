
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Pluralsight.Crypto
{
    [StructLayout(LayoutKind.Sequential)]
    public abstract class DisposeableObject : IDisposable
    {
        private bool disposed = false;

        ~DisposeableObject()
        {
            CleanUp(false);
        }

        public void Dispose()
        {
            
            if (!disposed)
            {
                CleanUp(true);

                disposed = true;

                GC.SuppressFinalize(this);
            }
        }

        protected abstract void CleanUp(bool viaDispose);

        protected void ThrowIfDisposed()
        {
            ThrowIfDisposed(this.GetType().FullName);
        }

        protected void ThrowIfDisposed(string objectName)
        {
            if (disposed)
                throw new ObjectDisposedException(objectName);
        }
    }
}
