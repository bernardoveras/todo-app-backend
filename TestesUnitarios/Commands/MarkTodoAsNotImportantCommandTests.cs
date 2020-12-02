using Dominio.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestesUnitarios.Commands
{
    [TestClass]
    public class MarkTodoAsNotImportantCommandTests
    {

        private readonly MarkTodoAsNotImportantCommand _invalidCommand = new MarkTodoAsNotImportantCommand();
        private readonly MarkTodoAsNotImportantCommand _validCommand = new MarkTodoAsNotImportantCommand(Guid.NewGuid());


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
