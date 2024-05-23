using System;
using MediatR;
using Tasks.Application.Abstractions;
using Tasks.Application.Task.Commands;
using Tasks.Domain;

namespace Tasks.Application.Task.CommandHandlers
{
	public class CreateTaskHandler : IRequestHandler<CreateTask, UserTask>
    {

        private readonly ITaskRepository _taskRepository;
        public CreateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task<UserTask> Handle(CreateTask request,
            CancellationToken cancellationToken)
        {
            var task = new UserTask
            {
                Title = request.Title,
                Description = request.Description,
                DueDate= request.DueDate,
                DateCreated= DateTime.Now,
                DateUpdated =DateTime.Now
            };

            return await _taskRepository.AddTask(task);
        }
    }
}

