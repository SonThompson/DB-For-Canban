using FunPart.Entities;

namespace FunPart.Repository.IRepos
{
    public interface ITaskCategoryRepo
    {
        Task<TaskCategories> GetById(string id);
        Task<IEnumerable<TaskCategories>> All();
        Task<bool> Add(TaskCategories entity);
        Task<bool> SaveAsync();
        Task<bool> Delete(string id);
        Task<bool> Update(TaskCategories entity);
    }
}
