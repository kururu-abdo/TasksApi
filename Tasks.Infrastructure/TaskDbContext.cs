using System;
using Microsoft.EntityFrameworkCore;
using Tasks.Domain;

namespace Tasks.Infrastructure
{
	public class TaskDbContext:DbContext
	{
        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserTask> Tasks { get; set; }
    }
}

