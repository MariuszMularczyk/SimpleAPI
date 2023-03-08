using System.Linq.Expressions;

namespace SimpleAPI
{
    public class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : class where TDbContext : DbContext
    {
        protected readonly DbSet<TEntity> _dbset;
        protected readonly TDbContext Context;



        public Repository(TDbContext context)
        {
            Context = context;
            _dbset = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }
        public virtual void AddRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbset.Add(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            _dbset.Remove(entity);
        }
        public virtual void DeleteRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Entry(entity).State = EntityState.Deleted;
                _dbset.Remove(entity);
            }
        }
        public void DeleteWhere(Expression<Func<TEntity, bool>> whereCondition)
        {
            Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>().Where(whereCondition));
        }

        protected IQueryable<TEntity> GetQueryable()
        {
            return _dbset.AsQueryable();
        }


        public IList<TEntity> GetAll()
        {
            return _dbset.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }


        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _dbset.Where(whereCondition).ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await _dbset.Where(whereCondition).ToListAsync();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _dbset.Where(whereCondition).FirstOrDefault();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await _dbset.Where(whereCondition).FirstOrDefaultAsync();
        }

        public void Attach(TEntity entity)
        {
            _dbset.Attach(entity);
        }

        public void Detach(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public IQueryable<TEntity> GetQueryable(bool tracking = false)
        {
            if (tracking == false)
            {
                return _dbset.AsNoTracking();
            }
            return _dbset.AsQueryable();

        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _dbset.AsQueryable().Where(whereCondition);
        }

        public int Count()
        {
            return _dbset.Count();
        }
        public async Task<int> CountAsync()
        {
            return await _dbset.CountAsync();
        }
        public bool Any()
        {
            return _dbset.Any();
        }
        public async Task<bool> AnyAsync()
        {
            return await _dbset.AnyAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await _dbset.FirstOrDefaultAsync(whereCondition);
        }

        public int Count(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _dbset.Where(whereCondition).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await _dbset.Where(whereCondition).CountAsync();
        }
        public bool Any(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _dbset.Any(whereCondition);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await _dbset.AnyAsync(whereCondition);
        }

        public void Edit(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Added)
            {
                Context.Entry(entity).State = EntityState.Modified; 
            }
        }

        public void EditRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Edit(entity);
            }
        }

        public int Save()
        {
            return Context.SaveChanges();
        }


        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }


        public TEntity Find(int id)
        {
            return _dbset.Find(id);
        }

    }

}
