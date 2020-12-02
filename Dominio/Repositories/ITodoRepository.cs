using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todo);
        void Update(TodoItem todo);
        TodoItem GetById(Guid id);
        IEnumerable<TodoItem> GetAll(string user);
        IEnumerable<TodoItem> GetAllDone(string user);
        IEnumerable<TodoItem> GetAllUndone(string user);
        IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
    }
}
