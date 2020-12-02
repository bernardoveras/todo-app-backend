using Dominio.Commands;
using Dominio.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestesUnitarios.Repositories;

namespace TestesUnitarios.Handlers
{
    [TestClass]
    public class MarkTodoAsDoneHandlerTests
    {

        private readonly MarkTodoAsDoneCommand _invalidCommand = new MarkTodoAsDoneCommand();
        private readonly MarkTodoAsDoneCommand _validCommand = new MarkTodoAsDoneCommand(Guid.NewGuid());
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private CommandResult _result = new CommandResult();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (CommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }
        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            var _result = (CommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
