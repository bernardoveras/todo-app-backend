using Dominio.Entidades;
using Dominio.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestesUnitarios.Queries
{
    [TestClass]
    public class TodoQueriesTests
    {

        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "UsuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "bernardoveras", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "UsuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "bernardoveras", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "bernardoveras", DateTime.Now.AddDays(1)));
            _items[1].MarkAsDone();
        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_bernardoveras()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("bernardoveras"));
            Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_bernardoveras_no_dia_de_amanha()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("bernardoveras", DateTime.Now.AddDays(1), false));
            Assert.AreEqual(1, result.Count());
        }
        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_bernardoveras_marcadas_como_done()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("bernardoveras"));
            Assert.AreEqual(1, result.Count());
        }
        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_bernardoveras_desmarcadas_como_done()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("bernardoveras"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
