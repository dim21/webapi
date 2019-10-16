using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models.Base;

namespace WebApi.Repos.Base
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        Task<IList<TEntity>> GetAsync();

        Task<PostResult<TId>> PostAsync(TEntity entity);

        Task<bool> PatchAsync(TId id, TEntity entity);

        Task<bool> DeleteAsync(TId id);
    }
}