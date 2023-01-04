namespace Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        DbContext DbContext { get; }
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        //Task<T> EditAsync(T entity);
        Task<T> EditAsync(Guid id);
        Task<T> DeleteAsync(Guid id);
    }
}