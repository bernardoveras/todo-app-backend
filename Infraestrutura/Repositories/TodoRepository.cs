using Dominio.Entidades;
using Dominio.Queries;
using Dominio.Repositories;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestrutura.Repositories
{
    public class TodoRepository : ITodoRepository
    {

        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TodoItem GetById(Guid id)
        {
            return _context.Todos.FirstOrDefault(TodoQueries.GetById(id));
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAll(user)).OrderBy(x => x.Important).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(user)).OrderBy(x => x.Important).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAllUndone(user)).OrderBy(x => x.Important).OrderBy(x => x.Date);
        }
        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Important).OrderBy(x => x.Date);
        }
    }
}
