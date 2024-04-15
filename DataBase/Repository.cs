using System;
using DataBase.Interfaces;

namespace DataBase
{
    public class Repository<T> : IRepository<T> where T : class, IBaseDbModel
    {
        protected readonly NotesContext _context;

        public Repository(NotesContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public virtual async Task<bool> Delete(long Id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == Id);
            if (entity == null)
            {
                return false;
            }
            _context.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public virtual async Task<IEnumerable<T>> ReadAll()
        {
            var entities = _context.Set<T>().ToList();
            return entities;
        }

        public virtual async Task<T> ReadById(long Id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == Id);
            return await Task.FromResult(entity);
        }

        public virtual async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}

