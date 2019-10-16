using System;
using System.Threading.Tasks;
using WebApi.Models.Base;
using WebApi.Repos.Base;

namespace WebApi.Repos.User
{
    public interface IUserRepository : IRepositoryBase<Models.User.User, Guid>
    {
        Task<PostResult<Guid>> CheckAuth(Models.User.User entity);
    }
}