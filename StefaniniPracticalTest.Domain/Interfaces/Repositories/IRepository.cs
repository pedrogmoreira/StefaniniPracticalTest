using StefaniniPracticalTest.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace StefaniniPracticalTest.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Finds an entity with the given primary key value.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        TEntity Find(int id);

        /// <summary>
        /// Finds an entity with the given primary key value asynchronously.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        Task<TEntity> FindAsync(int id);

        /// <summary>
        /// Inserts a new entity synchronously. 
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Inserts a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Deletes the specified entity synchronously.
        /// </summary>
        /// <param name="entity">>The entity to delete.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes the specified entity asynchronously.
        /// </summary>
        /// <param name="entity">>The entity to delete.</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Deletes the entity by the specified primary key synchronously.
        /// </summary>
        /// <param name="id">The primary key value.</param>
        void Delete(int id);

        /// <summary>
        /// Deletes the entity by the specified primary key asynchronously.
        /// </summary>
        /// <param name="id">The primary key value.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Updates the specified entity synchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates the specified entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task UpdateAsync(TEntity entity);

    }
}
