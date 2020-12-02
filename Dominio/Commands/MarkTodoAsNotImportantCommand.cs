using Todo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands
{
    public class MarkTodoAsNotImportantCommand : Notifiable, ICommand
    {
        public MarkTodoAsNotImportantCommand() { }

        public MarkTodoAsNotImportantCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
                           .IsNotNullOrEmpty(Id.ToString(), "Id", "Informe um ID válido")
                           .AreNotEquals(Id, Guid.Empty, "Id", "Informe um ID válido"));
        }
    }
}
