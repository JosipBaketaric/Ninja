using Ninja.Domain;
using Ninja.View;

namespace Ninja.Repository.Repositories
{
    public interface IClansRepository : IGenericRepository<Clan>
    {
        ClanWithNinjasView GetClanWithNinjas(int id);
    }
}
