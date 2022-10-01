using System;
using System.Collections.Generic;
using System.Text;
using NSE.Core.DomainObjects;

namespace NSE.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        //Apenas 1 repositório por agregação
        IUnitOfWork UnitOfWork { get; }

    }
}
