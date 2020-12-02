using Todo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), "Id", "Informe um id válido")
                .AreNotEquals(Id, Guid.Empty, "Id", "Informe um ID válido")
                .HasMaxLen(Title, 50, "Title", "Por favor, descreva a tarefa em um tamanho menor!")
                .IsNotNullOrEmpty(Title, "Title", "Informe um título menor")
                .IsNotNullOrEmpty(User, "User", "Informe um usuário válido"));
        }
    }
}
