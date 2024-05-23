using System;
using MediatR;
using Tasks.Domain;

namespace Tasks.Application.Task.Commands
{
	public class CreateTask :IRequest<UserTask>
	{
        public string Title { get; set; }
        public string Description { get; set; }

      
        public DateTime DueDate { get; set; }

       
    }
}

