namespace MartianRobots.Domain.Repository.Contracts
{
    /// <summary>
    /// The IRepository interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get inventory item by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(Guid id);
              
        /// <summary>
        /// Get all inventory items
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();
             
        /// Create a inventory Item
        /// </summary>
        /// <param name="entity"></param>
        Task CreateAsync(T entity);

        /// <summary>
        /// Update a inventory Item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        Task UpdateAsync(Guid id, T entity);
               
        /// <summary>
        /// Delete a inventory Item 
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAsync(Guid id);
    }
}