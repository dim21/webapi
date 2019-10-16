using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Base;
using WebApi.Repos.Base;

namespace WebApi.Repos.User
{
    public class UserRepository : RepositoryBase<Models.User.User, Guid>, IUserRepository
    {
        public UserRepository(IDbContext<Models.User.User, Guid> context) : base(context)
        {
        }

        /// <inheritdoc />
        public override async Task<PostResult<Guid>> PostAsync(Models.User.User entity)
        {
            var list = await GetAsync();
            if (list.Any(u => u.Email == entity.Email))
            {
                return await Task.FromResult(new PostResult<Guid> {Error = "Email exists"});
            }
            return await base.PostAsync(entity);
        }

        /// <inheritdoc />
        public async Task<PostResult<Guid>> CheckAuth(Models.User.User entity)
        {
            var list = await GetAsync();
            var currentUser = list.FirstOrDefault(u => u.Email == entity.Email && u.Password == entity.Password);
            if (currentUser == null)
            {
                return await Task.FromResult(new PostResult<Guid> { Error = "Invalid email or password" });
            }
            return await Task.FromResult(new PostResult<Guid> { Id = currentUser.Id });
        }
    }
}