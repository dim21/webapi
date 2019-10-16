using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Models.Base
{
    public interface IDbContext<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        Task<IList<TEntity>> GetAsync();

        Task<TId> PostAsync(TEntity entity);

        Task<bool> PatchAsync(TId id, TEntity entity);

        Task<bool> DeleteAsync(TId id);
    }
}