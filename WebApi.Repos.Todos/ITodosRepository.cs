using System;
using WebApi.Models.Todos;
using WebApi.Repos.Base;

namespace WebApi.Repos.Todos
{
    public interface ITodosRepository : IRepositoryBase<TodoInfo, Guid>
    {
    }
}