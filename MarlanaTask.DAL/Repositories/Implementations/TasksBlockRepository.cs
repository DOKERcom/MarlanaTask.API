using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.DbContexts;
using Task.DAL.Entities;
using Task.DAL.Repositories.Interfaces;

namespace Task.DAL.Repositories.Implementations
{

    public class TasksBlockRepository : ITasksBlockRepository
    {

        private MarlanaTaskDbContext db;
        private ITaskRepository _taskRepository;
        public TasksBlockRepository(MarlanaTaskDbContext context, ITaskRepository taskRepository)
        {
            db = context;
            _taskRepository = taskRepository;
        }


        public async Task<int> CreateTasksBlockAsync(string name)
        {
            db.TasksBlocks.Add(new TasksBlockEntity { Name = name });

            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteTasksBlockAsync(string name)
        {
            if ((await GetTasksBlockByNameAsync(name)) != null)
            {
                db.TasksBlocks.Remove(await GetTasksBlockByNameAsync(name));

                return await db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> UpdateTasksBlockNameAsync(string name, string newName)
        {
            var tasksBlock = await GetTasksBlockByNameAsync(name);

            if (tasksBlock != null)
            {
                tasksBlock.Name = newName;

                db.TasksBlocks.Update(tasksBlock);

                return await db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> ClearTasksinTasksBlock(string name)
        {
            var tasksBlock = await GetTasksBlockByNameAsync(name);

            db.Tasks.RemoveRange(db.Tasks.Where(b => b.Id == tasksBlock.Id).ToList());

            return await db.SaveChangesAsync();
        }

        public async Task<List<TasksBlockEntity>> GetAllTasksBlocks()
        {
            return await db.TasksBlocks.Include(t => t.Tasks).ToListAsync();
        }

        public async Task<TasksBlockEntity?> GetTasksBlockByNameAsync(string name)
        {
            return await db.TasksBlocks.Include(t => t.Tasks).Where(t=>t.Name == name).FirstOrDefaultAsync();
        }

        public async Task<TasksBlockEntity?> GetTasksBlockByIdAsync(int id)
        {
            return await db.TasksBlocks.Include(t=>t.Tasks).Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddTaskAsync(string tasksBlockName, string taskName)
        {
            var tasksBlock = await GetTasksBlockByNameAsync(tasksBlockName);

            var task = await _taskRepository.GetTaskByNameAsync(taskName);

            tasksBlock.Tasks.Add(task);

            return await db.SaveChangesAsync();
        }

        public async Task<int> RemoveTaskAsync(string tasksBlockName, string taskName)
        {
            var tasksBlock = await GetTasksBlockByNameAsync(tasksBlockName);

            tasksBlock.Tasks.Remove(tasksBlock.Tasks.Where(t => t.Name == taskName).FirstOrDefault());

            return await db.SaveChangesAsync();
        }
    }
}
