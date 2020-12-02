using Dominio.Commands;
using Dominio.Entidades;
using Dominio.Handlers.Contracts;
using Dominio.Repositories;
using Flunt.Notifications;
using System;
using Todo.Domain.Commands.Contracts;

namespace Dominio.Handlers
{
    public class TodoHandler : Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>,
        IHandler<MarkTodoAsImportantCommand>,
        IHandler<MarkTodoAsNotImportantCommand>
    {

        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = new TodoItem(command.Title, command.User, command.Date);

            _repository.Create(todo);

            return new CommandResult(true, "Sua tarefa foi salva!", todo);
        }
        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id);

            todo.UpdateTitle(command.Title);

            _repository.Update(todo);

            return new CommandResult(true, "Sua tarefa foi salva!", todo);
        }
        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id);

            todo.MarkAsDone();

            _repository.Update(todo);

            return new CommandResult(true, "Sua tarefa foi salva!", todo);
        }
        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id);

            todo.MarkAsUndone();

            _repository.Update(todo);

            return new CommandResult(true, "Sua tarefa foi salva!", todo);
        }
        public ICommandResult Handle(MarkTodoAsImportantCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id);

            todo.MarkAsImportant();

            _repository.Update(todo);

            return new CommandResult(true, "Sua tarefa foi salva!", todo);
        }
        public ICommandResult Handle(MarkTodoAsNotImportantCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id);

            todo.MarkAsNotImportant();

            _repository.Update(todo);

            return new CommandResult(true, "Sua tarefa foi salva!", todo);
        }
    }
}
