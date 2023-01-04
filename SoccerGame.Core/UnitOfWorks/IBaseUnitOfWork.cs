namespace Common
{
    using System.Linq.Expressions;

    public interface IBaseUnitOfWork<T>
        where T : BaseEntity
    {
        Task<List<T>> ReadAsync();
        Task<T> ReadByIdAsync(Guid productId);
        Task<List<T>> ReadByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T product);
        //Task<T> UpdateAsync(T product);
        Task<T> UpdateAsync(Guid id);
        Task<T> DeleteAsync(Guid id);
    }
}