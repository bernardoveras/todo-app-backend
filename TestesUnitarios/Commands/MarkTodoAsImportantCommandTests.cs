using Dominio.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestesUnitarios.Commands
{
    [TestClass]
    public class MarkTodoAsImportantCommandTests
    {

        private readonly MarkTodoAsImportantCommand _invalidCommand = new MarkTodoAsImportantCommand();
        private readonly MarkTodoAsImportantCommand _validCommand = new MarkTodoAsImportantCommand(Guid.NewGuid());


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
