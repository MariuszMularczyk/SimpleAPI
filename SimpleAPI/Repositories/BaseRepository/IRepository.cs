using System.Linq.Expressions;

namespace SimpleAPI
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> whereCondition);
        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        void DeleteWhere(Expression<Func<TEntity, bool>> whereCondition);
        void Attach(TEntity entity);
        void Detach(TEntity entity);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> whereCondition);
        IList<TEntity> GetAll();
        int Count(Expression<Func<TEntity, bool>> whereCondition);
        int Count();
        bool Any(Expression<Func<TEntity, bool>> whereCondition);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereCondition);
        bool Any();
        TEntity GetSingle(Expression<Func<TEntity, bool>> whereCondition);
        void Edit(TEntity entity);
        void EditRange(List<TEntity> entities);

        int Save();
        Task<int> SaveAsync();
        TEntity Find(int id);
    }
    
    public interface IRepository
    {
    }
}
