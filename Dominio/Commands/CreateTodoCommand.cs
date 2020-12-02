using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

namespace Dominio.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {

        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMaxLen(Title, 50, "Title", "Por favor, descreva a tarefa em um tamanho menor!")
                .IsNotNullOrEmpty(Title, "Title", "Informe um título menor")
                .IsNotNullOrEmpty(User, "User", "Informe um usuário válido"));
        }
    }
}
