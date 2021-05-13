using System;
using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //fail fast validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Falha de validação com sua tarefa", command.Notifications);

            //Gera o todoItem
            var todo = new TodoItem(command.Title, command.Date, command.User);

            // Salva no banco
            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa concluída", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //fail fast validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Falha de validação com sua tarefa", command.Notifications);

            //Gera o todoItem
            var todo = new TodoItem(command.Title, DateTime.Now, command.User);

            // Salva no banco
            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa concluída", todo);
        }
    }
}