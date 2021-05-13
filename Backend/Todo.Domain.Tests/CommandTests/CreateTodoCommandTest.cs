using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        

        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            var command = new CreateTodoCommand("", DateTime.Now, "");
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            var command = new CreateTodoCommand("titulo da tarefa", DateTime.Now, "felipe alves");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}
