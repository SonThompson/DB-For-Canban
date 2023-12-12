using AutoMapper;
using FunPart.Entities;
using FunPart.Repository.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FunPart.Repository.Repos
{
    public class UserRepo : IUserRepo
    {
        protected internal Context context;
        protected internal DbSet<Users> dbSet;
        public readonly ILogger logger;
        public readonly IMapper mapper;

        public UserRepo(Context context, ILogger logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            dbSet = context.Set<Users>();
        }

        public async Task<IEnumerable<Users>> All()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Users> GetById(string id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
