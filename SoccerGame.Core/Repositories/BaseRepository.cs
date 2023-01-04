namespace Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        public DbContext DbContext { get; }
        protected readonly DbSet<T> _table;

        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            _table = DbContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(Guid id) => await _table.FirstOrDefaultAsync(p => p.Id == id);
        public virtual async Task<List<T>> GetAllAsync() => await _table.ToListAsync();
        public virtual async Task<List<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
            => await _table.Where(expression).ToListAsync();

        public virtual async Task<T> AddAsync(T entity)
        {
            return (await _table.AddAsync(entity)).Entity;
        }

        //public virtual async Task<T> EditAsync(T entity)
        //{
        //    await EnsureEntityExists(entity);

        //    return _table.Update(entity).Entity;
        //}
        public virtual async Task<T> EditAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);

            await EnsureEntityExists(entity);

            _table.Update(entity);

            return entity;
        }
        public virtual async Task<T> DeleteAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);

            await EnsureEntityExists(entity);

            _table.Remove(entity);
            return entity;
        }

        protected async Task EnsureEntityExists(T entity)
        {
            if (!await IsExists(entity))
                throw new Exception("Entity dosn't exist in database");
        }
        protected async Task<bool> IsExists(T entity)
        {
            return await _table.AnyAsync(p => p.Id == entity.Id);
        }
    }
}