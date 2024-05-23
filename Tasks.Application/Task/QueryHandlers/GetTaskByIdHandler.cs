using System;
using MediatR;
using Tasks.Application.Abstractions;
using Tasks.Application.Task.Queries;
using Tasks.Domain;

namespace Tasks.Application.Task.QueryHandlers
{
	public class GetTaskByIdHandler
    : IRequestHandler<GetTaskById, UserTask>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<UserTask> Handle(GetTaskById request,
            CancellationToken cancellationToken)
        {
            return await _taskRepository.GetTaskById(request.Id);
        }
    }
}

