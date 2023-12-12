using AutoMapper;
using FunPart.Entities;
using FunPart.Repository.IRepos;
using Microsoft.EntityFrameworkCore;

namespace FunPart.Repository.Repos
{
    public class TaskCategoryRepo : ITaskCategoryRepo
    {
        protected internal Context context;
        protected internal DbSet<TaskCategories> dbSet;
        public readonly ILogger logger;
        public readonly IMapper mapper;

        public TaskCategoryRepo(Context context, ILogger logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            dbSet = context.Set<TaskCategories>();
        }

        public async Task<TaskCategories> GetById(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Add(TaskCategories entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TaskCategories>> All()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<bool> Delete(string id)
        {
            var entitieToDelete = await dbSet.FindAsync(id);

            dbSet.Remove(entitieToDelete);
            return true;
        }

        public async Task<bool> Update(TaskCategories entity)
        {
            var entityToUpsert = await dbSet.FindAsync(entity.Name);

            entityToUpsert.Name = entity.Name;

            return true;
        }
    }
}
