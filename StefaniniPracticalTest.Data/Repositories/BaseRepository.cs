using Microsoft.EntityFrameworkCore;
using StefaniniPracticalTest.Data.Context;
using StefaniniPracticalTest.Domain.Entities;
using StefaniniPracticalTest.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace StefaniniPracticalTest.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(ApplicationDbContext database)
        {
            _context = database;
            _dbSet = database.Set<TEntity>();
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Finds an entity with the given primary key value.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        public virtual TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Finds an entity with the given primary key value asynchronously.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Inserts a new entity synchronously. 
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Inserts a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        public virtual async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified entity synchronously.
        /// </summary>
        /// <param name="entity">>The entity to delete.</param>
        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entity asynchronously.
        /// </summary>
        /// <param name="entity">>The entity to delete.</param>
        public virtual async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the entity by the specified primary key synchronously.
        /// </summary>
        /// <param name="id">The primary key value.</param>
        public virtual void Delete(int id)
        {
            TEntity entity = Find(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the entity by the specified primary key asynchronously.
        /// </summary>
        /// <param name="id">The primary key value.</param>
        public virtual async Task DeleteAsync(int id)
        {
            TEntity entity = Find(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified entity synchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
