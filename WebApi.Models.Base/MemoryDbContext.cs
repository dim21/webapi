using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Base
{
    public class MemoryDbContext<TEntity, TId> : IDbContext<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        private readonly IList<TEntity> _items;

        public MemoryDbContext()
        {
            _items = new List<TEntity>();
        }

        /// <inheritdoc />
        public Task<IList<TEntity>> GetAsync()
        {
            return Task.FromResult(_items);
        }

        /// <inheritdoc />
        public Task<TId> PostAsync(TEntity entity)
        {
            entity.SetNewId();
            _items.Add(entity);
            return Task.FromResult(entity.Id);
        }

        /// <inheritdoc />
        public Task<bool> PatchAsync(TId id, TEntity entity)
        {
            var itemToPatch = _items.FirstOrDefault(i => Equals(i.Id, id));
            if (itemToPatch != null)
            {
                itemToPatch.Patch(entity);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(TId id)
        {
            var item = _items.FirstOrDefault(i => Equals(i.Id, id));
            if (item != null)
            {
                _items.Remove(item);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
