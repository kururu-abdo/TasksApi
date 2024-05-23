using System;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Abstractions;
using Tasks.Domain;

namespace Tasks.Infrastructure.Repositories
{
	public class TaskRepsitory
    : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepsitory(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<UserTask> AddTask(UserTask toCreate)
        {
            _context.Tasks.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<UserTask?> DeleteTask(int TaskId)
        {
            var Task = _context.Tasks
                .FirstOrDefault(p => p.Id == TaskId);

            if (Task is null) return null;

            _context.Tasks.Remove(Task);

            await _context.SaveChangesAsync();
            return Task;
        }

        public async Task<ICollection<UserTask>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<UserTask> GetTaskById(int TaskId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(p => p.Id == TaskId);
        }

        public async Task<UserTask> UpdateTask(int TaskId, string title, string desc)
        {
            var Task = await _context.Tasks
                .FirstOrDefaultAsync(p => p.Id == TaskId);

            Task.Title= title;
            Task.Description = desc;

            await _context.SaveChangesAsync();

            return Task;
        }
    };

}

