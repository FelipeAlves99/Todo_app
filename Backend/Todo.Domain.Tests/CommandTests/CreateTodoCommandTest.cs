using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("titulo da tarefa", DateTime.Now, "felipe alves");

        public CreateTodoCommandTest()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_comando_invalido()
            => Assert.AreEqual(_invalidCommand.Valid, false);

        [TestMethod]
        public void Dado_um_comando_valido()
            => Assert.AreEqual(_validCommand.Valid, true);
    }
}
