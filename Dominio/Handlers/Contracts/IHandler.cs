using Dominio.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands.Contracts;

namespace Dominio.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
