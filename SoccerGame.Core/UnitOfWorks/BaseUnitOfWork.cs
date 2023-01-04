namespace Common
{
    using System.Linq.Expressions;

    public class BaseUnitOfWork<T> : IBaseUnitOfWork<T>
        where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repsitory;

        public BaseUnitOfWork(IBaseRepository<T> repsitory)
        {
            _repsitory = repsitory;
        }

        public virtual async Task<List<T>> ReadAsync()
        {
            return await _repsitory.GetAllAsync();
        }

        public virtual async Task<T> ReadByIdAsync(Guid id)
        {
            return await _repsitory.GetByIdAsync(id);
        }

        public virtual async Task<List<T>> ReadByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _repsitory.GetByExpressionAsync(expression);
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            return await ExecuteAsync(() => _repsitory.AddAsync(entity));
        }

        //public virtual async Task<T> UpdateAsync(T entity)
        //{
        //    return await ExecuteAsync(() => _repsitory.EditAsync(entity));
        //}
        public virtual async Task<T> UpdateAsync(Guid id)
        {
            return await ExecuteAsync(() => _repsitory.EditAsync(id));
        }

        public virtual async Task<T> DeleteAsync(Guid id)
        {
            return await ExecuteAsync(() => _repsitory.DeleteAsync(id));
        }

        protected virtual async Task<T> ExecuteAsync(Func<Task<T>> func)
        {
            T entity = await func();
            await SaveChangesAsync();
            return entity;
        }

        protected virtual async Task SaveChangesAsync()
        {
            await _repsitory.DbContext.SaveChangesAsync();
        }
    }
}