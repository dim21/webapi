using System;
using WebApi.Models.Base;
using WebApi.Models.Todos;
using WebApi.Repos.Base;

namespace WebApi.Repos.Todos
{
    public class TodosRepository : RepositoryBase<TodoInfo, Guid>, ITodosRepository
    {
        public TodosRepository(IDbContext<TodoInfo, Guid> context) : base(context)
        {
        }
    }
}