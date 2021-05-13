using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.QueryTest
{
    [TestClass]
    public class TodoQueriesTest
    {   
        private List<TodoItem> _items;

        public TodoQueriesTest()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Titulo 1", DateTime.Now, "Usuario 1"));
            _items.Add(new TodoItem("Titulo 2", DateTime.Now, "Usuario 2"));
            _items.Add(new TodoItem("Titulo 3", DateTime.Now, "Usuario 2"));
            _items.Add(new TodoItem("Titulo 4", DateTime.Now, "Usuario 3"));
            _items.Add(new TodoItem("Titulo 5", DateTime.Now, "Usuario 5"));
            _items.Add(new TodoItem("Titulo 6", DateTime.Now, "Usuario 5"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_felipealves()
        {
            var result = _items.AsQueryable().Where(Queries.TodoQueries.GetAll("Usuario 5"));
            Assert.AreEqual(2, result.Count());
        }
    }
}