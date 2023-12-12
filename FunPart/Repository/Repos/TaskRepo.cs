using AutoMapper;
using FunPart.Entities;
using FunPart.Repository.IRepos;
using Microsoft.EntityFrameworkCore;

namespace FunPart.Repository.Repos
{
    public class TaskRepo : ITaskRepo
    {
        protected internal Context context;
        protected internal DbSet<Tasks> dbSet;
        public readonly ILogger logger;
        public readonly IMapper mapper;

        public TaskRepo(Context context, ILogger logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            dbSet = context.Set<Tasks>();
        }

        public async Task<Tasks> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Add(Tasks entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tasks>> All()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var entitieToDelete = await dbSet.FindAsync(id);

            dbSet.Remove(entitieToDelete);
            return true;
        }

        public async Task<bool> Update(Tasks entity)
        {
            var entityToUpsert = await dbSet.FindAsync(entity.Id);

            entityToUpsert.Id = entity.Id;
            entityToUpsert.User = entity.User;
            entityToUpsert.TaskCategory = entity.TaskCategory;

            return true;
        }

    }
}
