using System;
using System.Collections.Generic;
using System.Text;
using Task.DAL.Entities;

namespace Task.DAL.Repositories.Interfaces
{
    public interface ITasksBlockRepository
    {
        public Task<int> CreateTasksBlockAsync(string name);

        public Task<int> DeleteTasksBlockAsync(string name);

        public Task<int> ClearTasksinTasksBlock(string name);

        public Task<int> UpdateTasksBlockNameAsync(string name, string newName);

        public Task<List<TasksBlockEntity>> GetAllTasksBlocks();

        public Task<TasksBlockEntity?> GetTasksBlockByNameAsync(string name);

        public Task<TasksBlockEntity?> GetTasksBlockByIdAsync(int id);

        public Task<int> AddTaskAsync(string tasksBlockName, string taskName);

        public Task<int> RemoveTaskAsync(string tasksBlockName, string taskName);
    }
}
