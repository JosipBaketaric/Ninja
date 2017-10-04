
namespace Ninja.Repository.Repositories
{
    public interface INinjasRepository : IGenericRepository<Ninja.Domain.Ninja>
    {
        int IsUserLogedIn(int id);
        Ninja.Domain.Ninja LoginNinja(string Name, string password, string token);
    }
}
