
namespace Ninja.Repository.Repositories
{
    public interface INinjasRepository : IGenericRepository<Ninja.Domain.Ninja>
    {
        bool LoginNinja(string Name, string password, string token);
        bool RefreshToken(int id);
        bool IsUserLogedIn(int id);
    }
}
