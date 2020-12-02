using Dominio.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestesUnitarios.Commands
{
    [TestClass]
    public class MarkTodoAsDoneCommandTests
    {

        private readonly MarkTodoAsDoneCommand _invalidCommand = new MarkTodoAsDoneCommand();
        private readonly MarkTodoAsDoneCommand _validCommand = new MarkTodoAsDoneCommand(Guid.NewGuid());


        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
