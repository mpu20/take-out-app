using Microsoft.EntityFrameworkCore;
using TakeOutApp.API.Models;
using TakeOutApp.API.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace TakeOutApp.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly TakeOutAppDbContext context;
        public BaseRepository(TakeOutAppDbContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            var existEntity = await context.Set<T>().FindAsync(entity);

            if (existEntity != null)
            {
                throw new ArgumentException();
            }

            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }

            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            var existEntity = await context.Set<T>().FindAsync(entity);

            if (existEntity == null)
            {
                throw new NullReferenceException();
            }

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
