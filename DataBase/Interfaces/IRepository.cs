using System;
namespace DataBase.Interfaces
{
	public interface IRepository<T> where T : IBaseDbModel
    {
        public Task<IEnumerable<T>> ReadAll();
        public Task<T> ReadById(long Id);
        public Task<bool> Create(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(long Id);
    }
}

