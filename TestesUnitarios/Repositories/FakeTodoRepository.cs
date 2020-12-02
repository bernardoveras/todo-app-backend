using Dominio.Entidades;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesUnitarios.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
        }
        public void Update(TodoItem todo)
        {
        }
        public TodoItem GetById(Guid id)
        {
            return new TodoItem("Titulo", "bernardoveras", DateTime.Now);
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }
    }
}
