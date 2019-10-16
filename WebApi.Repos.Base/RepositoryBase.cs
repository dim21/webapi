using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models.Base;

namespace WebApi.Repos.Base
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : IEntityBase<TId>
    {
        private readonly IDbContext<TEntity, TId> _context;

        public RepositoryBase(IDbContext<TEntity, TId> context)
        {
            _context = context;
        }

        public async Task<IList<TEntity>> GetAsync()
        {
            return await _context.GetAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual async Task<PostResult<TId>> PostAsync(TEntity entity)
        {
            var error = entity.CheckPost();
            var id = default(TId);
            if (string.IsNullOrEmpty(error))
            {
                id = await _context.PostAsync(entity).ConfigureAwait(false);
            }

            return await Task.FromResult(new PostResult<TId> {Id = id, Error = error});
        }

        public async Task<bool> PatchAsync(TId id, TEntity entity)
        {
            return await _context.PatchAsync(id, entity).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            return await _context.DeleteAsync(id).ConfigureAwait(false);
        }
    }
}