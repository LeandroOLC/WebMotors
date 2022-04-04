using System;
using WM.WebAPI.Core.Data;

namespace WM.Vitrine.API.Data.Repository
{
    public interface IRepository<T> : IDisposable 
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
