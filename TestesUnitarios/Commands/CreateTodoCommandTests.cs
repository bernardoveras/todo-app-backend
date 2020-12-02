using Dominio.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestesUnitarios.Commands
{
    [TestClass]
    public class CreateTodoCommandTests
    {

        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da Tarefa", "bernardoveras", DateTime.Now);


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
