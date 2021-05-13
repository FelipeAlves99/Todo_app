using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.Entity
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todo = new TodoItem("Titulo", DateTime.Now, "Felipe Alves");
        
        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_todo.Done, false);
        }
    }
}