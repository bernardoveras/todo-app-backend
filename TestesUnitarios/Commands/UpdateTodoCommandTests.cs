using Dominio.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestesUnitarios.Commands
{
    [TestClass]
    public class UpdateTodoCommandTests
    {

        private readonly UpdateTodoCommand _invalidCommand = new UpdateTodoCommand(Guid.Empty, "", "");
        private readonly UpdateTodoCommand _validCommand = new UpdateTodoCommand(Guid.NewGuid(), "Titulo", "bernardoveras");


        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Invalid, true);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
