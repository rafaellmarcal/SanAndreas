using System;

namespace SanAndreas.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
