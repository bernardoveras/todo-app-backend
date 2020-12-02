using Dominio.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestesUnitarios.Commands
{
    [TestClass]
    public class MarkTodoAsUndoneCommandTests
    {

        private readonly MarkTodoAsUndoneCommand _invalidCommand = new MarkTodoAsUndoneCommand(); //Id é um Guid.Empty
        private readonly MarkTodoAsUndoneCommand _validCommand = new MarkTodoAsUndoneCommand(Guid.NewGuid());


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
