using Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace Dominio.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.User == user;

        }
        public static Expression<Func<TodoItem, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }
        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x => x.User == user &&
                   x.Done == done &&
                   x.Date.Date == date.Date;
        }
    }
}
