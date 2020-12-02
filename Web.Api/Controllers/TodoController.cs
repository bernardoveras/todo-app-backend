using Dominio.Commands;
using Dominio.Entidades;
using Dominio.Handlers;
using Dominio.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            return repository.GetAll("bernardoveras");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone("bernardoveras");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllUndone("bernardoveras");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("bernardoveras", DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("bernardoveras", DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("bernardoveras", DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("bernardoveras", DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public CommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "bernardoveras";
            return (CommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public CommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "bernardoveras";
            return (CommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public CommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            return (CommandResult)handler.Handle(command);
        }


        [Route("mark-as-undone")]
        [HttpPut]
        public CommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            return (CommandResult)handler.Handle(command);
        }
    }
}
