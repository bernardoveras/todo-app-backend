using Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesUnitarios.Entities
{
    [TestClass]
    public class CreateTodoCommandTests
    {

        private readonly TodoItem _validTodo = new TodoItem("Titulo", "bernardoveras", DateTime.Now);

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }


    }
}
