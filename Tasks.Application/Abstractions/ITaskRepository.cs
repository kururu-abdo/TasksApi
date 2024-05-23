using System;
using Tasks.Domain;

namespace Tasks.Application.Abstractions
{
	public interface ITaskRepository
	{
        Task<ICollection<UserTask>> GetAll();

        Task<UserTask> GetTaskById(int taskId);

        Task<UserTask> AddTask(UserTask toCreate);

        Task<UserTask> UpdateTask(int taskId, string title, string desc);

        Task<UserTask?> DeleteTask(int taskId);
    }
}

