using Ninja.Data;
using Ninja.Domain;

namespace Ninja.Repository.Repositories
{
    public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
    {

        public EquipmentRepository(NinjaContext context)
            : base(context)
        {
        }

        //Casts a DbContext from generic repository to PersonEntities Context
        private NinjaContext NinjaContext
        {
            get { return Context as NinjaContext; }
        }




        //CUSTOM QUERIES GOES BELLOW



    }
}
