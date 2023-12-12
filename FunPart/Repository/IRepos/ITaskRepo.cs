using FunPart.Entities;

namespace FunPart.Repository.IRepos
{
    public interface ITaskRepo
    {
        Task<Tasks> GetById(int id);
        Task<IEnumerable<Tasks>> All();
        Task<bool> Add(Tasks entity);
        Task<bool> SaveAsync();
        Task<bool> Delete(int id);
        Task<bool> Update(Tasks entity);
    }
}
