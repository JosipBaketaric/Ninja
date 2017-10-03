using Ninja.Repository.Repositories;
using System;

namespace Ninja.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        INinjasRepository Ninjas { get; }
        IClansRepository Clans { get; }
        IEquipmentRepository Equipment { get; }

        int Complete();
    }
}
