using FunPart.Entities;

namespace FunPart.Repository.IRepos
{
    public interface IUserRepo
    {
        Task<Users> GetById(string id);
        Task<IEnumerable<Users>> All();
    }
}
