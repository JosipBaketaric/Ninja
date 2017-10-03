using Ninja.Data;
using Ninja.Repository.Repositories;
using Ninja.Repository.UnitOfWork;
using Ninject.Modules;

namespace Ninja.Repository.NinjectBindings
{
    //Author: josipba
    //Machine: P004794
    //Created: 10/2/2017 12:09:21 PM
    public class Bindings : NinjectModule
    {

        public override void Load()
        {
            Bind<IClansRepository>().To<ClansRepository>();
            Bind<IEquipmentRepository>().To<EquipmentRepository>();
            Bind<INinjasRepository>().To<NinjasRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork.UnitOfWork>();
            Bind<NinjaContext>().To<NinjaContext>();
        }

    }
}
