using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

namespace Dominio.Commands
{
    public class MarkTodoAsImportantCommand : Notifiable, ICommand
    {
        public MarkTodoAsImportantCommand() { }

        public MarkTodoAsImportantCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
                            .IsNotNullOrEmpty(Id.ToString(), "Id", "Informe um id válido")
                            .AreNotEquals(Id, Guid.Empty, "Id", "Informe um ID válido"));
        }
    }
}
