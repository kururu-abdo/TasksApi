using System;
using MediatR;
using Tasks.Domain;

namespace Tasks.Application.Task.Queries
{
	public class GetTaskById:

    IRequest<UserTask>
{
    public int Id { get; set; }
}
	}


